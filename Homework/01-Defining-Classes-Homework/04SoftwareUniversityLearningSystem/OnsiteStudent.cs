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

        // TODO Overrite toString()
    }
}
