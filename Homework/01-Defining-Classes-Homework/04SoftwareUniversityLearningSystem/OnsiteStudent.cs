namespace SoftwareUniversityLearningSystem
{
    using System;
    public class OnsiteStudent : CurrentStudent
    {
        // Create field
        private int numberOfVisits;

        // Create constructor for class OnsiteStudent
        public OnsiteStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, 
            string currentCourse, int numberOfVisits)
            : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        // Create and validate property NumberOfVisits
        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The number of visits cannot be negative.");
                }
                this.numberOfVisits = value;
            }
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\nStudent number: {3}\nAverage grade: {4}\nCurrent course: {5}\nNumber of visits: {6}\n",
                FirstName, LastName, Age, StudentNumber, AverageGrade, CurrentCourse, numberOfVisits);
        }
    }
}
