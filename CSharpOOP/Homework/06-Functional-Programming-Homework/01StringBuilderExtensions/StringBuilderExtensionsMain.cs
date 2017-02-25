namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StringBuilderExtensionsMain
    {
        internal static void Main()
        {
            StringBuilder sb = new StringBuilder("Hi! How are you? ");
            IEnumerable<string> words = new List<string>() { "Are", "you", "alright?" };

            Console.WriteLine(sb.Substring(0, 3));
            Console.WriteLine(sb.RemoveText("Hi! "));
            Console.WriteLine(sb.AppendAll<string>(words));
        }
    }
}