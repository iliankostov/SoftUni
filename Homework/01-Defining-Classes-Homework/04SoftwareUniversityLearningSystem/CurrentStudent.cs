namespace SoftwareUniversityLearningSystem
{
    using System;
    public class CurrentStudent : Student
    {
        // Create field
        private string currentCourse;

        // Create constructor for class CurrentStudent
        public CurrentStudent(string firstName, string lastName, int age, int studentNumber, 
            double averageGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        // Create and validate property CurrentCourse
        public string CurrentCourse
        {
            get
            {
                return this.currentCourse;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The current course cannot be empty.");
                }
                this.currentCourse = value;
            }
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\nStudent number: {3}\nAverage grade: {4}\nCurrent course: {5}\n", 
                FirstName, LastName, Age, StudentNumber, AverageGrade, CurrentCourse);
        }

    }
}
