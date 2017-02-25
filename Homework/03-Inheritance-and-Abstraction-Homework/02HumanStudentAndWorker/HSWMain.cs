namespace HumanStudentAndWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class HSWMain
    {
        internal static void Main()
        {
            List<Student> students = new List<Student>() 
            {
                new Student("Ivanka", "Petrova", "abc101"),
                new Student("Maria", "Hristova", "abc1002"),
                new Student("Asen", "Hristov", "abc1003"),
                new Student("Maria", "Kostova", "2001abc"),
                new Student("Biser", "Kostov", "2002abc"),
                new Student("Georgi", "Ivanov", "abv5005"),
                new Student("Evgeni", "Minchev", "haha666"),
                new Student("Rosen", "Elenkov", "9001lpf"),
                new Student("Ivan", "Georgiev", "abv96"),
                new Student("Kalin", "Mandaliev", "007")
            };
            List<Student> ascendingStudents = students.OrderBy(a => a.FacultyNumber).ToList();
            Console.WriteLine("Ascending ordered students by faculty number:\n");
            foreach (var student in ascendingStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>() 
            {
                new Worker("Veselin", "Hristov", 250M, 8),
                new Worker("Maria", "Hristova", 200M, 10),
                new Worker("Asen", "Kostov", 300M, 10),
                new Worker("Ivaylo", "Angelov", 150M, 7.5),
                new Worker("Biser", "Hristov", 188M, 6.75),
                new Worker("Georgi", "Georgiev", 2000M, 5.25),
                new Worker("Evgeni", "Minchev", 10000M, 2.5),
                new Worker("Rosen", "Mandaliev", 50M, 1),
                new Worker("Ivan", "Ivanov", 60M, 2),
                new Worker("Kalin", "Elenkov", 400M, 8)
            };
            List<Worker> descendingWorkers = workers.OrderByDescending(b => b.MoneyPerHour()).ToList();
            Console.WriteLine("Descending ordered workers by payment per hour:\n");
            foreach (var worker in descendingWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine();

            List<Human> allHuman = new List<Human>();
            allHuman.AddRange(students);
            allHuman.AddRange(workers);
            Console.WriteLine("Sorted humans by first name and last name:\n");
            List<Human> sortedHuman = allHuman.OrderBy(c => c.FirstName).ThenBy(d => d.LastName).ToList();
            foreach (var human in sortedHuman)
            {
                Console.WriteLine(human);
            }
        }
    }
}