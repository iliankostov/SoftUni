namespace Customer
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Models;

    internal class CustomerMain
    {
        internal static void Main()
        {
            Customer thomas = new Customer("Thomas", "Anderson", "Rodriguez", "123456798", "America", "+1123456789", "thomas.rodriguez@gmail.com", new List<Payment>() { new Payment("Jacket", 99.99m), new Payment("Jeans", 49.99m) }, CustomerType.Diamond);

            Console.WriteLine("ToString()");          
            Console.WriteLine(thomas);

            Console.WriteLine("Clone()"); 
            Customer copy = thomas.Clone() as Customer;
            Console.WriteLine(copy);

            Console.WriteLine("Is copy deep?");
            copy.FirstName = "Lee";
            copy.Payments = new List<Payment>()
            {
                new Payment("Shoes", 29.99m)
            };
            copy.Id = "123456798";
            Console.WriteLine(copy);
            Console.WriteLine(thomas);

            Console.WriteLine("Equals()"); 
            Console.WriteLine(thomas.Equals(copy));
            Customer third = thomas.Clone() as Customer;
            Console.WriteLine(thomas.Equals(third));

            Console.WriteLine("== and !=");
            Console.WriteLine(thomas == copy);
            Console.WriteLine(thomas != copy);
            Console.WriteLine(thomas == third);
            Console.WriteLine(thomas != third);

            Console.WriteLine("CompareTo()"); 
            Console.WriteLine(thomas.CompareTo(copy));
            Console.WriteLine(thomas.CompareTo(third));
        }
    }
}