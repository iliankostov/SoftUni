namespace SoftwareUniversityLearningSystem
{
    using System;
    public class JuniorTrainer : Trainer
    {
        // Create constructor for class JuniorTrainer
        public JuniorTrainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\n", FirstName, LastName, Age);
        }
    }
}
