using System;

public class Cat    // Beginning of class definition
{
    private string name;    // Field 1
    private string owner;   // Field 2

    public Cat(string name = null, string owner = null)   // Beginning of constructor definition.
    {                                                     // If we equal property to null it won't be required.
        this.name = name;       // Constructor's property 1
        this.owner = owner;     // Constructor's property 2
    }

    public string Name      // Create public property "Name"
    {
        get { return this.name; }       // get the name of the cat
        set
        {
            if (true)                   // Here we can validate the input.
            {
                this.name = value;      // set a string value to name property.
            }
            else
            {
                throw new IndexOutOfRangeException("The name is out of range");
            }
        }
    }

    public string Owner     // Create public property "Owner"
    {
        get { return this.owner; }      // get the owner of the cat
        set
        {
            if (true)                   // Here we can validate the input.
            {
                this.owner = value;     // set a string value to owner property. 
            }
            else
            {
                throw new IndexOutOfRangeException("The owner is out of range");
            }
        }
    }

    public void SayMiau()       // Create public method (function) for dinamic of the cat
    {
        Console.Write("Miauuuuuuu ");       // This is dinamic result
    }

}

class LetTheCatsSayMiau
{
    static void Main()
    {
        Cat catOne = new Cat();    // Create a new cat
        Cat catTwo = new Cat("Pursy", "Andrew");    // Create another cat

        catOne.Name = "Kitty";     // Change the name of the cat
        catOne.Owner = "George";   // Change the owner of the cat

        // Let the cat One says Miauuuuuu
        Console.WriteLine("{0}'s cat called {1} says:", catOne.Owner, catOne.Name);
        catOne.SayMiau();
        Console.WriteLine();

        // Let the cat Two say Miauuuuuuu twice
        Console.WriteLine("{0}'s cat called {1} says:", catTwo.Owner, catTwo.Name);
        catTwo.SayMiau();
        catTwo.SayMiau();
        Console.WriteLine();
    }
}