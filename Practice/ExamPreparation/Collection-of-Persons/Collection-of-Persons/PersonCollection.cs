using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private OrderedDictionary<int, SortedSet<Person>> personsByAge =
        new OrderedDictionary<int, SortedSet<Person>>();

    private Dictionary<string, Person> personsByEmail =
        new Dictionary<string, Person>();

    private Dictionary<string, SortedSet<Person>> personsByEmailDomain =
        new Dictionary<string, SortedSet<Person>>();

    private Dictionary<Tuple<string, string>, SortedSet<Person>> personsByNameAndTown =
        new Dictionary<Tuple<string, string>, SortedSet<Person>>();

    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.personsByEmail.ContainsKey(email))
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

        this.personsByEmail[email] = person;

        this.personsByAge.AppendValueToKey(age, person);

        var emailDomain = email.Split('@')[1];
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        var nameAndTown = new Tuple<string, string>(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].EnsureKeyExists(age);
        this.personsByTownAndAge[town][age].Add(person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            return null;
        }

        return this.personsByEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            return false;
        }

        var person = this.personsByEmail[email];
        var emailDomain = email.Split('@')[1];
        var name = person.Name;
        var age = person.Age;
        var town = person.Town;

        this.personsByEmail.Remove(email);

        if (this.personsByAge.ContainsKey(age))
        {
            this.personsByAge[age].Remove(person);
            if (this.personsByAge[age].Count == 0)
            {
                this.personsByAge.Remove(age);
            }
        }

        if (this.personsByEmailDomain.ContainsKey(emailDomain))
        {
            this.personsByEmailDomain[emailDomain].Remove(person);
            if (this.personsByEmailDomain[emailDomain].Count == 0)
            {
                this.personsByEmailDomain.Remove(emailDomain);
            }
        }

        var nameAndTown = new Tuple<string, string>(name, town);
        if (this.personsByNameAndTown.ContainsKey(nameAndTown))
        {
            this.personsByNameAndTown[nameAndTown].Remove(person);
            if (this.personsByNameAndTown[nameAndTown].Count == 0)
            {
                this.personsByNameAndTown.Remove(nameAndTown);
            }
        }

        if (this.personsByTownAndAge.ContainsKey(town))
        {
            if (this.personsByTownAndAge[town].ContainsKey(age))
            {
                this.personsByTownAndAge[town][age].Remove(person);
            }

            if (this.personsByTownAndAge[town][age].Count == 0)
            {
                this.personsByTownAndAge[town].Remove(age);
            }

            if (this.personsByTownAndAge[town].Count == 0)
            {
                this.personsByTownAndAge.Remove(town);
            }
        }

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!this.personsByEmailDomain.ContainsKey(emailDomain))
        {
            yield break;
        }

        foreach (var person in this.personsByEmailDomain[emailDomain])
        {
            yield return person;
        }
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = new Tuple<string, string>(name, town);
        if (!this.personsByNameAndTown.ContainsKey(nameAndTown))
        {
            yield break;
        }

        foreach (var person in this.personsByNameAndTown[nameAndTown])
        {
            yield return person;
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsView = this.personsByAge.Range(startAge, true, endAge, true);
        if (personsView == null)
        {
            yield break;
        }

        foreach (var persons in personsView.Values)
        {
            foreach (var person in persons)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var personsView = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);
        if (personsView == null)
        {
            yield break;
        }

        foreach (var persons in personsView.Values)
        {
            foreach (var person in persons)
            {
                yield return person;
            }
        }
    }
}