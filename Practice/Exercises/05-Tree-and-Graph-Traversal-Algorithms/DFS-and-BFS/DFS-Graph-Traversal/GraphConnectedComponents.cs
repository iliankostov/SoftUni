namespace Graph
{
    using System;
    using System.Collections.Generic;

    public class GraphConnectedComponents
    {
        private static List<int>[] graph;

        private static bool[] visited;

        public static void Main()
        {
            int graphSize = int.Parse(Console.ReadLine());
            graph = new List<int>[graphSize];
            visited = new bool[graphSize];

            for (int row = 0; row < graphSize; row++)
            {
                graph[row] = new List<int>();
                string[] neighbours = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string neighbour in neighbours)
                {
                    graph[row].Add(int.Parse(neighbour));
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    Console.Write("Connected component:");
                    DFS(i);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;
                foreach (int child in graph[node])
                {
                    DFS(child);
                }

                Console.Write(" " + node);
            }
        }
    }
}
