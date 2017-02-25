namespace DictionariesHashTablesSets
{
    using System;

    public class OrderedSet
    {
        public static void Main()
        {
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(17);

            // Console.WriteLine(set.Contains(12));
            // set.Remove(17);
            // set.Remove(25);
            Console.WriteLine(string.Join(", ", set));
        }
    }
}