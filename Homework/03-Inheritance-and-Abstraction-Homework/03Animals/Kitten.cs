namespace Animals
{
    using System;

    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age) 
            : base(name, age, Gender.F)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("miauuuuuuuu mrrr");
        }
    }
}