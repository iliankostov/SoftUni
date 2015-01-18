using System;

class Person
{
    // Create fields
    private string name;
    private int age;
    private string email;  

    // Create first constructor
    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    // Create second constructor
    public Person(string name, int age)
            : this(name, age, null)
    {
    }

    // Create and validate property Name
    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("The name can't be empty");
            }
            this.name = value;
        }
    }

    // Create and Validate property Age
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new IndexOutOfRangeException("The age can be in range [1...100]");
            }
            this.age = value;
        }
    }

    // Create and validate property Email
    public string Email
    {
        get { return this.email; }
        set
        {
            if (value == null || value.Contains("@"))
            {
                this.email = value;
            }
            else
            {
                throw new Exception("The email is not valid");
            }
        }
    }

    // Implementing the ToString() method to enable printing persons at the console
    public override string ToString()
    {
        if (Email != null)
        {
            return string.Format("Name: {0}\nAge: {1}\nEmail: {2}\n", Name, Age, Email);
        }
        else
        {
            return string.Format("Name: {0}\nAge: {1}\n", Name, Age);
        }
        
    }

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

// Why VS2015 wants to remove "this" from constructors and properties ?