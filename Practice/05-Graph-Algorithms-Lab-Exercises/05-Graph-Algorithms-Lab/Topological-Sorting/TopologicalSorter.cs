namespace Topological_Sorting_DFS
{
    using System;
    using System.Collections.Generic;

    public class TopologicalSorter
    {
        private Dictionary<string, List<string>> graph;

        private HashSet<string> visitedNodes;

        private LinkedList<string> sortedNodes;

        private HashSet<string> cycleNodes;

        public TopologicalSorter(Dictionary<string, List<string>> graph)
        {
            this.graph = graph;
        }

        public ICollection<string> TopSort()
        {
            this.visitedNodes = new HashSet<string>();
            this.sortedNodes = new LinkedList<string>();
            this.cycleNodes = new HashSet<string>();

            foreach (var node in this.graph.Keys)
            {
                this.TopSortDFS(node);
            }

            return this.sortedNodes;
        }

        private void TopSortDFS(string node)
        {
            if (this.cycleNodes.Contains(node))
            {
                throw new InvalidOperationException("A cycle detected in the graph");
            }

            if (!this.visitedNodes.Contains(node))
            {
                this.visitedNodes.Add(node);
                this.cycleNodes.Add(node);

                foreach (var childNode in this.graph[node])
                {
                    if (this.graph.ContainsKey(childNode))
                    {
                        this.TopSortDFS(childNode);
                    }
                    else if (!this.visitedNodes.Contains(childNode))
                    {
                        this.visitedNodes.Add(childNode);
                        this.sortedNodes.AddFirst(childNode);
                    }
                }

                this.cycleNodes.Remove(node);
                this.sortedNodes.AddFirst(node);
            }
        }
    }
}