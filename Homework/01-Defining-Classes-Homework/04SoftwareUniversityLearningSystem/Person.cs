namespace SoftwareUniversityLearningSystem
{
    using System;
    public class Person
    {
        // Create fields
        private string firstName;
        private string lastName;
        private int age;

        // Create constructor for class Person
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
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
                    throw new ArgumentNullException("Your first name cannot be empty.");
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
                    throw new ArgumentNullException("Your last name cannot be empty.");
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
                    throw new IndexOutOfRangeException("Your age cannot be under 5 years.");
                }
                this.age = value;
            }
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\n", FirstName, LastName, Age);
        }

    }
}