namespace List_of_Edges_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Edge
    {
        public int Parent { get; set; }

        public int Child { get; set; }
    }

    internal class ListOfEdgesGraph
    {
        private static List<Edge> graph = new List<Edge>()
            {
                new Edge() { Parent = 0, Child = 3 },
                new Edge() { Parent = 0, Child = 6 },
                new Edge() { Parent = 1, Child = 2 },
                new Edge() { Parent = 1, Child = 3 },
                new Edge() { Parent = 1, Child = 4 },
                new Edge() { Parent = 1, Child = 5 },
                new Edge() { Parent = 1, Child = 6 },
                new Edge() { Parent = 2, Child = 1 },
                new Edge() { Parent = 2, Child = 4 },
                new Edge() { Parent = 2, Child = 5 },
                new Edge() { Parent = 3, Child = 0 },
                new Edge() { Parent = 3, Child = 1 },
                new Edge() { Parent = 3, Child = 5 },
                new Edge() { Parent = 4, Child = 1 },
                new Edge() { Parent = 4, Child = 2 },
                new Edge() { Parent = 4, Child = 6 },
                new Edge() { Parent = 5, Child = 1 },
                new Edge() { Parent = 5, Child = 2 },
                new Edge() { Parent = 5, Child = 3 },
                new Edge() { Parent = 6, Child = 0 },
                new Edge() { Parent = 6, Child = 1 },
                new Edge() { Parent = 6, Child = 4 },
            };

        private static string[] nodeNames = { "Ruse", "Sofia", "Pleven", "Varna", "Bourgas", "Stara Zagora", "Plovdiv" };

        private static void Main()
        {
            PrintNodesWithChildren(graph);

            Console.WriteLine();

            PrintNodeNamesWithChildrenNames(graph, nodeNames);
        }

        private static void PrintNodesWithChildren(List<Edge> graph)
        {
            for (int node = 0; node < graph.Max(p => p.Parent); node++)
            {
                var childNodeNames = graph
                    .Where(e => e.Parent == node)
                    .Select(edge => edge.Child);
                Console.WriteLine(
                    "{0} --> {1}",
                    node,
                    string.Join(", ", childNodeNames));
            }
        }

        private static void PrintNodeNamesWithChildrenNames(List<Edge> graph, string[] nodeNames)
        {
            for (int node = 0; node < nodeNames.Length; node++)
            {
                var childNodeNames = graph
                    .Where(e => e.Parent == node)
                    .Select(edge => nodeNames[edge.Child]);
                Console.WriteLine(
                    "{0} --> {1}",
                    nodeNames[node],
                    string.Join(", ", childNodeNames));
            }
        }
    }
}