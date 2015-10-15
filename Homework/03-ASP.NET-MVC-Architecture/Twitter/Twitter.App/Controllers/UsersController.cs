namespace Twitter.App.Controllers
{
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;

    using Twitter.App.Models;
    using Twitter.App.Models.BindingModels;
    using Twitter.App.Models.ViewModels;
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

        // GET: /Users/Index
        public ActionResult Index(string user)
        {


            return this.View();
        }

        // GET: /Users/Profile
        public async Task<ActionResult> Profile(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess
                                             ? "Your password has been changed."
                                             : message == ManageMessageId.SetPasswordSuccess
                                                   ? "Your password has been set."
                                                   : message == ManageMessageId.EditProfileSucess
                                                         ? "Your profile has been changed."
                                                         : message == ManageMessageId.Error
                                                         ? "Incorrect data. Please try again."
                                                         : "";

            var userId = this.User.Identity.GetUserId();
            var model = new ProfileViewModel
                {
                    HasPassword = this.HasPassword(),
                    TwoFactor = await this.UserManager.GetTwoFactorEnabledAsync(userId),
                    Logins = await this.UserManager.GetLoginsAsync(userId),
                    BrowserRemembered = await this.AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
                };
            return this.View(model);
        }

        // GET: /Users/EditProfile
        public async Task<ActionResult> EditProfile(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.Error
                                                         ? "Incorrect data. Please try again."
                                                         : "";

            var userId = this.User.Identity.GetUserId();

            var model = new EditProfileViewModel()
                {
                    Username = this.User.Identity.GetUserName(),
                    Email = await this.UserManager.GetEmailAsync(userId),
                };

            return this.View(model);
        }

        // POST: /Users/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(EditProfileBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("EditProfile", new { Message = ManageMessageId.Error });
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            if (user == null)
            {
                return this.RedirectToAction("EditProfile", new { Message = ManageMessageId.Error });
            }

            user.UserName = model.Username;
            user.Email = model.Email;
            this.Data.SaveChanges();

            model.Username = user.UserName;
            model.Email = user.Email;

            return this.RedirectToAction("Profile", new { Message = ManageMessageId.EditProfileSucess });
        }

        // GET: /Users/ChangePassword
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Users/ChangePassword
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

                return this.RedirectToAction("Profile", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            this.AddErrors(result);
            return this.View(model);
        }

        // GET: /Users/SetPassword
        public ActionResult SetPassword()
        {
            return this.View();
        }

        // POST: /Users/SetPassword
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
                    return this.RedirectToAction("Profile", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
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

        public enum ManageMessageId
        {
            EditProfileSucess,

            ChangePasswordSuccess,

            SetPasswordSuccess,

            Error
        }

        #endregion
    }
}