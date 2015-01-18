using System;

public class Cat    // Beginning of class definition
{
    private string name;    // Field 1
    private string owner;   // Field 2

    public Cat(string name, string owner)   // Beginning of constructor definition
    {
        this.name = name;       // Constructor's property 1
        this.owner = owner;     // Constructor's property 2
    }

    public string Name      // Create template for property "Name"
    {
        get { return this.name; }       // get the name of the cat template
        set { this.name = value; }      // set it a string value
    }

    public string Owner     // Create template for property "Owner"
    {
        get { return this.owner; }      // get the owner of the cat template
        set { this.owner = value; }     // set it a string value
    }

    public void SayMiau()       // Create method (function) for dinamic of the cat
    {
        Console.Write("Miauuuuuuu ");       // This is the dinamic result
    }

}

class LetTheCatsSayMiau
{
    static void Main()
    {
        Cat catOne = new Cat("", "");    // Create a new cat
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