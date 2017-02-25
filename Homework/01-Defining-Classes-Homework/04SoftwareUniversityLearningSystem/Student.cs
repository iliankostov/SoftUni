namespace SoftwareUniversityLearningSystem
{
    using System;
    public class Student : Person
    {
        // Create fields
        private int studentNumber;
        private double averageGrade;

        // Create constructor for class Student
        public Student(string firstName, string lastName, int age, int studentNumber, double averageGrade)
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        // Create and validate property StudentNumber
        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The student number cannot be negative.");
                }
                this.studentNumber = value;
            }
        }

        // Create and validate property AverageGrade
        public double AverageGrade
        {
            get
            {
                return this.averageGrade;
            }
            set
            {
                if (value < 2.0 || value > 6.0)
                {
                    throw new IndexOutOfRangeException("The average grade is out of range [2.0 ... 6.0].");
                }
                this.averageGrade = value;
            }
        }

        // Overrite toString()
        public override string ToString()
        {
            return String.Format("Student name: {0} {1}\nAge: {2}\nStudent number: {3}\nAverage grade: {4}\n",
                FirstName, LastName, Age, StudentNumber, AverageGrade);
        }
    }
}