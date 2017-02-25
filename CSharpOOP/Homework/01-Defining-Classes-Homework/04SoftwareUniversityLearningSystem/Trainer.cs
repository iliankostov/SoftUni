namespace SoftwareUniversityLearningSystem
{
    using System;
    public class Trainer : Person
    {
        // Create constructor for class Trainer
        public Trainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        // Create method CreateCourse([courseName]) 
        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Course {0} has been created.", courseName);
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\n", FirstName, LastName, Age);
        }
    }
}
