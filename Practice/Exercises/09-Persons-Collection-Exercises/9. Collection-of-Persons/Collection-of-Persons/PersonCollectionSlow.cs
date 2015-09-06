﻿namespace Collection_of_Persons
{
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollectionSlow : IPersonCollection
    {
        private List<Person> persons = new List<Person>();

        public int Count
        {
            get
            {
                return this.persons.Count;
            }
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }

            var person = new Person
                {
                    Email = email, 
                    Name = name, 
                    Age = age, 
                    Town = town
                };
            this.persons.Add(person);
            return true;
        }

        public Person FindPerson(string email)
        {
            return this.persons.FirstOrDefault(p => p.Email == email);
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person != null)
            {
                this.persons.Remove(person);
                return true;
            }

            return false;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.persons
                .Where(p => p.Email.EndsWith("@" + emailDomain))
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.persons
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.persons
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            return this.persons
                .Where(p => p.Town == town)
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }
    }
}