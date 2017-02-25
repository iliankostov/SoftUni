namespace SoftwareUniversityLearningSystem
{
    using System;
    public class GraduateStudent : Student
    {
        // Create constuctor for class GraduateStudent
        public GraduateStudent(string firstName, string lastName, int age, int studentNumber, double averageGrade)
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\nStudent number: {3}\nAverage grade: {4}\n",
                FirstName, LastName, Age, StudentNumber, AverageGrade);
        }
    }
}
