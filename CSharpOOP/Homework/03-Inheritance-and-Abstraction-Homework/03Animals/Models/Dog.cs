namespace Animals
{
    using System;
    using Contracts;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("bark bark bark");
        }
    }
}