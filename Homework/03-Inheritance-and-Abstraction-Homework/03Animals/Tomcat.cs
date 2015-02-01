namespace Animals
{
    using System;

    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age) 
            : base(name, age, Gender.M)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("miau miau miau");
        }
    }
}