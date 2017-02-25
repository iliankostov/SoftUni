namespace CompanyHierarchy
{
    using System;

    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The id cannot be negative.");
                }

                this.id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The first name cannot be empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Full name: {0} {1}\nID: {2}", this.FirstName, this.LastName, this.Id);
        }
    }
}