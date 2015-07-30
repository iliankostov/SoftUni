namespace ProcessingJSON
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Product> soldProducts;

        private ICollection<Product> boughtProducts;

        private ICollection<User> friends; 
 
        public User()
        {
            this.soldProducts = new HashSet<Product>();
            this.boughtProducts = new HashSet<Product>();
            this.Friends = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        [InverseProperty("Seller")]
        public virtual ICollection<Product> SoldProduct
        {
            get
            {
                return this.soldProducts;
            }

            set
            {
                this.soldProducts = value;
            }
        }

        [InverseProperty("Buyer")]
        public virtual ICollection<Product> BoughtProduct
        {
            get
            {
                return this.boughtProducts;
            }

            set
            {
                this.boughtProducts = value;
            }
        }

        public virtual ICollection<User> Friends
        {
            get
            {
                return this.friends;
            }

            set
            {
                this.friends = value;
            }
        }
    }
}
