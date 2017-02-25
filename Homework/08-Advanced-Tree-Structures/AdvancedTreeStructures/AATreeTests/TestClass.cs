namespace AATreeTests
{
    using System;
    using AATreeNamespace;

    internal class TestClass
    {
        public static void Test(int[] values)
        {
            AATree<int, int> tree = new AATree<int, int>();
            for (int i = 0; i < values.Length; i++)
            {
                if (!tree.Add(values[i], i + 1))
                {
                    Console.WriteLine("Failed to insert {0}", values[i]);
                }
            }

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tree[values[j]] != 0)
                    {
                        Console.WriteLine("Found deleted key {0}", values[j]);
                    }
                }

                for (int j = i; j < values.Length; j++)
                {
                    if (tree[values[j]] != (j + 1))
                    {
                        Console.WriteLine("Could not find key {0}", values[j]);
                    }
                }

                if (!tree.Remove(values[i]))
                {
                    Console.WriteLine("Failed to delete {0}", values[i]);
                }
            }
        }
    }
}