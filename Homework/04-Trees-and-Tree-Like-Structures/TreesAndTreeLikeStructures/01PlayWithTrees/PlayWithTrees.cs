namespace TreesAndTreeLikeStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayWithTrees
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subTreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine("Root node has value: {0}", FindRootNode().Value);
            Console.WriteLine("Leaf nodes are: {0}", string.Join(", ", FindLeafNodes().Select(ln => ln.Value)));
            Console.WriteLine("Middle nodes are: {0}", string.Join(", ", FindMiddleNodes().Select(mn => mn.Value)));
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values
                .FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(node => node.Children.Count == 0);
            return leafNodes;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var midleNodes = nodeByValue.Values
                .Where(node => node.Children.Count > 0 && node.Parent != null).ToList();
            return midleNodes;
        }
    }
}
