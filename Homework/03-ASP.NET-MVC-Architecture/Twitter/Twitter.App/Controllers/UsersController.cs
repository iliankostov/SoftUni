﻿namespace Twitter.App.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    using Twitter.App.Models;
    using Twitter.Data.Contracts;

    [Authorize]
    public class UsersController : BaseController
    {
        private ApplicationSignInManager signInManager;

        private ApplicationUserManager userManager;

        public UsersController()
        {
        }

        public UsersController(
            ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            ITwitterData data)
            : base(data)

        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return this.signInManager ?? this.HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                this.signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess
                                             ? "Your password has been changed."
                                             : message == ManageMessageId.SetPasswordSuccess
                                                   ? "Your password has been set."
                                                   : message == ManageMessageId.SetTwoFactorSuccess
                                                         ? "Your two-factor authentication provider has been set."
                                                         : message == ManageMessageId.Error
                                                               ? "An error has occurred."
                                                               : message == ManageMessageId.AddPhoneSuccess
                                                                     ? "Your phone number was added."
                                                                     : message == ManageMessageId.RemovePhoneSuccess
                                                                           ? "Your phone number was removed."
                                                                           : "";

            var userId = this.User.Identity.GetUserId();
            var model = new IndexViewModel
                {
                    HasPassword = this.HasPassword(),
                    PhoneNumber = await this.UserManager.GetPhoneNumberAsync(userId),
                    TwoFactor = await this.UserManager.GetTwoFactorEnabledAsync(userId),
                    Logins = await this.UserManager.GetLoginsAsync(userId),
                    BrowserRemembered = await this.AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
                };
            return this.View(model);
        }

        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result =
                await
                this.UserManager.RemoveLoginAsync(
                    this.User.Identity.GetUserId(),
                    new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, false, false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return this.RedirectToAction("ManageLogins", new { Message = message });
        }

        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), true);
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInManager.SignInAsync(user, false, false);
            }
            return this.RedirectToAction("Index", "Users");
        }

        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await this.UserManager.SetTwoFactorEnabledAsync(this.User.Identity.GetUserId(), false);
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.SignInManager.SignInAsync(user, false, false);
            }
            return this.RedirectToAction("Index", "Users");
        }

        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var result =
                await
                this.UserManager.ChangePasswordAsync(
                    this.User.Identity.GetUserId(),
                    model.OldPassword,
                    model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.SignInManager.SignInAsync(user, false, false);
                }
                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            this.AddErrors(result);
            return this.View(model);
        }

        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return this.View();
        }

        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                    if (user != null)
                    {
                        await this.SignInManager.SignInAsync(user, false, false);
                    }
                    return this.RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.RemoveLoginSuccess
                                             ? "The external login was removed."
                                             : message == ManageMessageId.Error ? "An error has occurred." : "";
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            if (user == null)
            {
                return this.View("Error");
            }
            var userLogins = await this.UserManager.GetLoginsAsync(this.User.Identity.GetUserId());
            var otherLogins =
                this.AuthenticationManager.GetExternalAuthenticationTypes()
                    .Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider))
                    .ToList();
            this.ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return this.View(new ManageLoginsViewModel { CurrentLogins = userLogins, OtherLogins = otherLogins });
        }

        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(
                provider,
                this.Url.Action("LinkLoginCallback", "Users"),
                this.User.Identity.GetUserId());
        }

        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo =
                await this.AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, this.User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await this.UserManager.AddLoginAsync(this.User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded
                       ? this.RedirectToAction("ManageLogins")
                       : this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,

            ChangePasswordSuccess,

            SetTwoFactorSuccess,

            SetPasswordSuccess,

            RemoveLoginSuccess,

            RemovePhoneSuccess,

            Error
        }

        #endregion
    }
}