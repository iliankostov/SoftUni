namespace Persons
{
    using System;
    class PersonsMain
    {
        static void Main()
        {
            Person george = new Person("George", 25, "george@gmail.com");
            Person henry = new Person("Henry", 30, "@");
            Person michael = new Person("Michael", 35);

            Person[] persons = new Person[] { george, henry, michael };
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}