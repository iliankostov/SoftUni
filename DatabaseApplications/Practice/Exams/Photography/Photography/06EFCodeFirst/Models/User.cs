namespace Photography.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Channel> channels;

        private ICollection<UserMessages> sendUserMessageses;

        private ICollection<UserMessages> recivedUserMessageses;

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.sendUserMessageses = new HashSet<UserMessages>();
            this.recivedUserMessageses = new HashSet<UserMessages>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Channel> Chanels
        {
            get
            {
                return this.channels;
            }

            set
            {
                this.channels = value;
            }
        }

        public virtual ICollection<UserMessages> SendUserMessageses
        {
            get
            {
                return this.sendUserMessageses;
            }

            set
            {
                this.sendUserMessageses = value;
            }
        }

        public virtual ICollection<UserMessages> RecievedUserMessageses
        {
            get
            {
                return this.recivedUserMessageses;
            }

            set
            {
                this.recivedUserMessageses = value;
            }
        }
    }
}
