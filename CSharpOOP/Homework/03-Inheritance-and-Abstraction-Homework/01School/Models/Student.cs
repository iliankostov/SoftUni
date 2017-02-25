namespace School.Models
{
    using System;
    using Contracts;

    public class Student : Person, IDetails
    {
        private int uniqueClassNumber;

        public Student(string name, int uniqueClassNumber, string detail = null)
            : base(name)
        {
            this.Name = name;
            this.UniqueClassNumber = uniqueClassNumber;
            this.Detail = detail;
        }

        public int UniqueClassNumber
        {
            get
            {
                return this.uniqueClassNumber;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The number of lectures cannot be empty.");
                }

                this.uniqueClassNumber = value;
            }
        }

        public string Detail { get; set; }
    }
}