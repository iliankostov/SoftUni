using System;
using System.Collections.Generic;
using System.Linq;
using Animals;

internal class AnimalsMain
{
    internal static void Main()
    {
        List<Dog> dogs = new List<Dog>()
            {
                new Dog("sharo", 5, Gender.M),
                new Dog("lisa", 10, Gender.F),
                new Dog("rex", 1, Gender.M)
            };
        Console.WriteLine("Average age of dogs is: {0:0.00}", dogs.Average(a => a.Age));

        List<Frog> frogs = new List<Frog>()
            {
                new Frog("prince", 20, Gender.M),
                new Frog("Diana", 18, Gender.F)
            };
        Console.WriteLine("Average age of frogs is: {0:0.00}", frogs.Average(b => b.Age));

        List<Kitten> kittens = new List<Kitten>()
            {
                new Kitten("Mira", 1),
                new Kitten("Ginka", 5)
            };
        Console.WriteLine("Average age of kittens is: {0:0.00}", kittens.Average(c => c.Age));

        List<Tomcat> tomcats = new List<Tomcat>()
            {
                new Tomcat("Spas", 6),
                new Tomcat("KitKat", 2)
            };
        Console.WriteLine("Average age of tomcats is: {0:0.00}", tomcats.Average(d => d.Age));
    }
}