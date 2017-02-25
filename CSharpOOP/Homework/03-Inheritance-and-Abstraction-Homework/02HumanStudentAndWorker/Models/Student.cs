namespace HumanStudentAndWorker
{
    using System;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Faculty number cannot be empty.");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} has number {2}", this.FirstName, this.LastName, this.FacultyNumber);
        }
    }
}