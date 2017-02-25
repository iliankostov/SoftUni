namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class SULSTest
    {
        static void Main()
        {
            try
            {
                Person dimitar = new Person("Dimitar", "Dimitrov", 26);

                Trainer georgi = new Trainer("Georgi", "Ivanov", 31);
                SeniorTrainer ivan = new SeniorTrainer("Ivan", "Georgiev", 26);
                JuniorTrainer krum = new JuniorTrainer("Krum", "Grigorov", 21);

                Student aleksandar = new Student("Aleksandar", "Georgiev", 20, 2015010001, 4.86);
                GraduateStudent kalin = new GraduateStudent("Kalin", "Yordanov", 25, 2014010001, 5.09);
                CurrentStudent spas = new CurrentStudent("Spas", "Grigorov", 19, 2014090001, 4.65, "Java Basics");
                OnlineStudent vasil = new OnlineStudent("Vasil", "Vasilev", 35, 2014090002, 3.70, "Java Basics");
                OnsiteStudent maria = new OnsiteStudent("Maria", "Hristova", 33, 2014090003, 5.50, "Java Basics", 12);
                DropoutStudent nikolay = new DropoutStudent("Nikolay", "Harizanov", 18, 2014010002, 2.75, "low average grade");

                List<Person> allPersons = new List<Person>
                {
                    dimitar, georgi, ivan, krum, aleksandar, kalin, spas, vasil, maria, nikolay
                };

                var currentStudents =
                    from person in allPersons
                    where person is CurrentStudent
                    select (CurrentStudent)person;

                currentStudents = currentStudents.OrderByDescending(c => c.AverageGrade);

                foreach (var currentStudent in currentStudents)
                {
                    Console.WriteLine(currentStudent);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The data cannot be null or empty.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The data cannot be negative.");
            }           
        }
    }
}
