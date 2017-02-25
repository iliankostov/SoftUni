namespace TreeAndGraphTraversal
{
    using System;

    public class FindTheRoot
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[n + 1];
            int count = 0;
            int root = 0;

            for (int i = 0; i < n; i++)
            {
                var nums = Console.ReadLine().Split(' ');
                var toNode = int.Parse(nums[1]);
                hasParent[toNode] = true;
            }

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    count++;
                    root = i;
                }
            }

            if (count == 1)
            {
                Console.WriteLine("Root = " + root);
            }
            else if (count > 1)
            {
                Console.WriteLine("Forest is not a tree!");
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }
    }
}
