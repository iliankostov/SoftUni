namespace StudentClass
{
    using System;

    internal class StudentClassMain
    {
        public static void Main()
        {
            Student firstStudent = new Student("Slavin", 25);
            Student secondStudent = new Student("Nevena", 22);

            firstStudent.PropertyChanged += (sender, eventArgs) => Console.WriteLine("Property  cnaged: {0} (from {1} to {2})", eventArgs.Property, eventArgs.OldValue, eventArgs.NewValue);

            secondStudent.PropertyChanged += (sender, eventArgs) => Console.WriteLine("Property  cnaged: {0} (from {1} to {2})", eventArgs.Property, eventArgs.OldValue, eventArgs.NewValue);

            firstStudent.Name = "Slavcho faktora";
            firstStudent.Age = 26;
            secondStudent.Name = "Nevi stana vtora";
            secondStudent.Age = 23;

            Console.WriteLine();

            firstStudent.Name = "Slavin";
            firstStudent.Age = 27;
            secondStudent.Name = "Nevena";
            secondStudent.Age = 24;
        }
    }
}