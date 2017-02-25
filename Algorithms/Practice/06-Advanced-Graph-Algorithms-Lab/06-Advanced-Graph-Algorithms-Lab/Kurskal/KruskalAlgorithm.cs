namespace Kurskal
{
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    parent[rootEndNode] = rootStartNode;
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            if (parent[node] == node)
            {
                return node;
            }

            parent[node] = FindRoot(parent[node], parent);
            return parent[node];
        }
    }
}