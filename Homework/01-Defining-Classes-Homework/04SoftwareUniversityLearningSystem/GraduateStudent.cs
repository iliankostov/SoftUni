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

        // TODO Overrite toString()
    }
}
