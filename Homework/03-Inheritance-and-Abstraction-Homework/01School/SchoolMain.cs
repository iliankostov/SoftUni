namespace School
{
    using System;
    using System.Collections.Generic;
    using Models;

    internal class ShoolMain
    {
        internal static void Main()
        {
            Student ivan = new Student("Ivan", 1001);
            Student georgi = new Student("Georgi", 1002, "good man");
            Student vasil = new Student("Vasil", 1003, "bad man");
            List<Student> students = new List<Student>() { ivan, georgi, vasil };

            Discipline math = new Discipline("Math", 150, students);
            Discipline phisics = new Discipline("Physics", 100, students, "Base");
            List<Discipline> disciplines = new List<Discipline>() { math, phisics };

            Teacher ivanov = new Teacher("Ivanov", disciplines, "teacher");
            Teacher nakov = new Teacher("Nakov", disciplines, "inspirator");
            List<Teacher> teachers = new List<Teacher>() { ivanov, nakov };
            List<Teacher> inspirators = new List<Teacher>() { nakov };

            ClassOfStudents groupA = new ClassOfStudents("Group A", teachers, "good class");
            ClassOfStudents groupB = new ClassOfStudents("Group B", inspirators, "bad class");
        }
    }
}