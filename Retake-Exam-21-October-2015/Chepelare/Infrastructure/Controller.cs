namespace Chepelare.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using Chepelare.Contracts;
    using Chepelare.Identity;
    using Chepelare.Models;
    using Chepelare.Models.Enumerations;
    using Chepelare.Utilities;
    using Chepelare.Views.Shared;

    /// <summary>
    /// Abstract Controller
    /// </summary>
    public class Controller
    {
        // BUG: change internal to public
        public Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        /// <summary>
        /// Currently logged in user
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// Check if there is currently logged in user
        /// </summary>
        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        /// <summary>
        /// Hold all repositories with objects data
        /// </summary>
        protected IHotelBookingSystemData Data { get; private set; }

        /// <summary>
        /// Using reflection instance new view with specific model provided
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Specific view with model in it</returns>
        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamesapceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamesapceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        /// <summary>
        /// Generate specific error message view
        /// </summary>
        /// <param name="message"></param>
        /// <returns>View with specific message in it</returns>
        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        /// <summary>
        /// Check if givven roles is authorized to action
        /// </summary>
        /// <param name="roles"></param>
        protected void Authorize(params Roles[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!roles.Any(role => this.CurrentUser.IsInRole(role)))
            {
                throw new AuthorizationFailedException(
                    "The currently logged in user doesn't have sufficient rights to perform this operation.",
                    this.CurrentUser);
            }
        }
    }
}