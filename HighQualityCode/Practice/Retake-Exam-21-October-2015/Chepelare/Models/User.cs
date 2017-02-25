namespace Chepelare.Models
{
    using System;
    using System.Collections.Generic;

    using Chepelare.Contracts;
    using Chepelare.Models.Enumerations;
    using Chepelare.Utilities;

    public class User : IDbEntity
    {
        private string username;

        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The username must be at least 5 symbols long.");
                }
                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException("The password must be at least 6 symbols long.");
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}