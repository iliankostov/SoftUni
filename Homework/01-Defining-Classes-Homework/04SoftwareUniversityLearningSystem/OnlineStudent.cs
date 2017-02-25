namespace SoftwareUniversityLearningSystem
{
    using System;
    public class OnlineStudent : CurrentStudent
    {
        // Create constructor for class OnlineStudent
        public OnlineStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
        {
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\nStudent number: {3}\nAverage grade: {4}\nCurrent course: {5}\n",
                FirstName, LastName, Age, StudentNumber, AverageGrade, CurrentCourse);
        }
    }
}
