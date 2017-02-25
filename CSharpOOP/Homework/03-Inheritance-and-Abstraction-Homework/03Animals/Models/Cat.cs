namespace Animals
{
    using System;

    public abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
    }
}