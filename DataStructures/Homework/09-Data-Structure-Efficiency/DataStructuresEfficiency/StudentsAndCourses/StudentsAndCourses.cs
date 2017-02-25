namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class StudentsAndCourses
    {
        private static void Main()
        {
            var personsByCourses = new SortedDictionary<string, SortedSet<Person>>();

            var file = new StreamReader("../../input.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var personData = line.Split('|');
                var firstName = personData[0].Trim();
                var lastName = personData[1].Trim();
                var course = personData[2].Trim();

                var person = new Person
                    {
                        FirstName = firstName, 
                        LastName = lastName
                    };

                personsByCourses.EnsureKeyExists(course);
                personsByCourses[course].Add(person);
            }

            foreach (var personsByCourse in personsByCourses)
            {
                Console.Write(personsByCourse.Key + ": ");
                Console.WriteLine(string.Join(", ", personsByCourse.Value));
            }
        }
    }
}