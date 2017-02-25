namespace SoftwareUniversityLearningSystem
{
    using System;
    public class SeniorTrainer : Trainer
    {
        // Create constructor for class SeniorTrainer
        public SeniorTrainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        // Create method DeleteCourse([courseName]) 
        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("Course {0} has been deleted.", courseName);
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\n", FirstName, LastName, Age);
        }
    }
}
