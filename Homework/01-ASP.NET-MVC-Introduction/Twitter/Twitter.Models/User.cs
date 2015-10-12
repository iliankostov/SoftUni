namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<User> followers;

        private ICollection<User> following;

        private ICollection<Notification> notifications;

        private ICollection<Message> messages;

        public User()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.notifications = new HashSet<Notification>();
            this.messages = new HashSet<Message>();
        }

        public virtual ICollection<User> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<User> Following
        {
            get
            {
                return this.following;
            }

            set
            {
                this.following = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one 
            // defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}