namespace SoftwareUniversityLearningSystem
{
    using System;
    class DropoutStudent : Student
    {
        // Create fields
        private string dropoutReason;

        // Create constuctor for class DropoutStudent
        public DropoutStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string dropoutReason)
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

        // Create and validate property DropoutReason
        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The dropout reason cannot be empty.");
                }
                this.dropoutReason = value;
            }
        }

        // Create method Reapply()
        public void Reapply()
        {
            Console.WriteLine("All the information and dropout reason");
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\nStudent number: {3}\nAverage grade: {4}\n",
                FirstName, LastName, Age, StudentNumber, AverageGrade);
        }
    }
}
