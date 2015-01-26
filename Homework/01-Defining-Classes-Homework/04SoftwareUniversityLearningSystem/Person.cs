namespace SoftwareUniversityLearningSystem
{
    using System;
    class Person
    {
        // Create fields
        private string firstName;
        private string lastName;
        private int age;

        // Create constructor
        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        // Create and validate property FirstName
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
                    throw new ArgumentNullException("Please fill first name");
                }
                this.firstName = value;
            }
        }

        // Create and validate property LastName
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
                    throw new ArgumentNullException("Please fill last name");
                }
                this.lastName = value;
            }
        }

        // Create and validate property Age
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 5)
                {
                    throw new IndexOutOfRangeException("Your age cannot be under 5 years");
                }
                if (value == null)
                {
                    throw new ArgumentNullException("Please fill your age");
                }
                this.age = value;
            }
        }
    }
}