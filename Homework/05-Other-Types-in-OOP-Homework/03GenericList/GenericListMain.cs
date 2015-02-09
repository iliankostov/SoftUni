namespace GenericList
{
    using System;
    using GenericListVersion;

    public class GenericListTest
    {
        public static void Main()
        {
            GenericList<int> list = new GenericList<int>();

            Console.WriteLine("Adding");
            list.Add(123);
            list.Add(456);
            list.Add(789);
            Console.WriteLine(list);

            Console.WriteLine("Accessing " + list[2] + "\n");

            Console.WriteLine("Removing index 1");
            list.Remove(1);
            Console.WriteLine(list);

            Console.WriteLine("Inserting at index");
            list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.InsertAt(666, 2);
            Console.WriteLine(list);

            Console.Write("Finding " + list[2]);
            int index = list.Find(666);
            Console.WriteLine(". It was found at index " + index);
            Console.WriteLine();

            Console.WriteLine("Clearing");
            list.Clear();
            Console.WriteLine(list);

            Console.WriteLine("Auto-growing");
            list = new GenericList<int>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("List starts with " + list.Min());
            Console.WriteLine("List ends with " + list.Max());

            object[] genericListVersion = typeof(GenericList<int>).GetCustomAttributes(false);
            Console.WriteLine("\nVersion: {0}", genericListVersion[1]);
        }
    }
}