namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Discipline : IDetails
    {
        private string name;
        private int numberOfLectures;
        private List<Student> students;

        public Discipline(string name, int numberOfLectures, List<Student> students, string detail = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.students = students;
            this.Detail = detail;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the discipline cannot be empty.");
                }

                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The number of lectures cannot be empty.");
                }

                this.numberOfLectures = value;
            }
        }

        public string Detail { get; set; }
    }
}