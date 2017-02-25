namespace CustomLINQExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CustomLINQExtensionMethodsMain
    {
        internal static void Main()
        {
            IEnumerable<int> numbers = new List<int>() { 101, 202, 303, 404, 505, 606 };

            Console.WriteLine(string.Join(", ", numbers.WhereNot<int>(a => a == 404)));

            Console.WriteLine(string.Join(", ", numbers.Repeat<int>(2)));

            IEnumerable<string> stringItems = new List<string>() { "Hello", "my", "friend!", "How", "are", "you?" };
            IEnumerable<string> suffixes = new List<string>() { "lo", "my", "end!" };
            Console.WriteLine(string.Join(", ", stringItems.WhereEndsWith(suffixes)));
        }
    }
}