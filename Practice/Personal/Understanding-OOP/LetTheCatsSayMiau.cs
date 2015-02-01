using System;

class LetTheCatsSayMiau
{
    static void Main()
    {
        // The arguments which I give on the new object depend from the constructors.
        // After that the constructor put the data in properties which validate it.
        // After that the properties set the value to the field of the class.

        Cat catOne = new Cat("a");    // Create a new cat. It's name is required.
        
        Cat catTwo = new Cat("Pursy", "Andrew");    // Create another cat

        catOne.Name = "Kitty";     // Change the name of the cat
        catOne.Owner = "George";   // Change the owner of the cat

        Cat[] cats = new Cat[] { catOne, catTwo };

        // Let the cats say Miauuuuuu
        foreach (Cat cat in cats)
        {
            Console.WriteLine("{0}'s cat called {1} says:", cat.Owner, cat.Name);
            cat.SayMiau();
            cat.SayMiau();
            Console.WriteLine();
        }
    }
}