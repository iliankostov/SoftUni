namespace DFSRecursiveOOPGraph
{
    using System;
    using System.Collections.Generic;

    public class RecursiveDFSExample
    {
        private static string[] nodeNames = { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };

        private static List<int>[] childNodes = new[]
            {
                new List<int> { 3, 6 }, // children of node 0 (Ruse)
                new List<int> { 2, 3, 4, 5, 6 }, // successors of node 1 (Sofia)
                new List<int> { 1, 4, 5 }, // successors of node 2 (Pleven)
                new List<int> { 0, 1, 5 }, // successors of node 3 (Varna)
                new List<int> { 1, 2, 6 }, // successors of node 4 (Bourgas)
                new List<int> { 1, 2, 3 }, // successors of node 5 (Stara Zagora)
                new List<int> { 0, 1, 4 } // successors of node 6 (Plovdiv)
            };

        private static HashSet<int> visited;

        private static void RecursiveDFS(int node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                Console.WriteLine("{0} ({1})", node, nodeNames[node]);

                for (int i = 0; i < childNodes[node].Count; i++)
                {
                    RecursiveDFS(childNodes[node][i]);
                }
            }
        }

        public static void Main()
        {
            visited = new HashSet<int>();

            // Start DFS from node 4 (Bourgas)
            RecursiveDFS(4);
        }
    }
}