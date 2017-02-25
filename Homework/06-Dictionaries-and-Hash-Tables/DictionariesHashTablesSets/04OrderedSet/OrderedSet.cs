namespace DictionariesHashTablesSets
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTree<T> binaryTree;

        public OrderedSet()
        {
            this.binaryTree = new BinaryTree<T>();
            this.Count = 0;
        }

        public int Count { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.binaryTree.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Add(T value)
        {
            if (this.binaryTree.Add(value))
            {
                this.Count++;
                return true;
            }

            return false;
        }

        public bool Contains(T value)
        {
            return this.binaryTree.Contains(value);
        }

        public bool Remove(T element)
        {
            if (this.RemoveElement(element))
            {
                this.Count--;
                return true;
            }

            return false;
        }

        private bool RemoveElement(T value)
        {
            if (this.binaryTree == null)
            {
                return false;
            }

            if (this.binaryTree.Value.CompareTo(value) == 0)
            {
                if (this.binaryTree.RightChild == null)
                {
                    this.binaryTree = this.binaryTree.LeftChild;
                    return true;
                }

                if (this.binaryTree.RightChild.LeftChild == null)
                {
                    this.binaryTree.RightChild.LeftChild = this.binaryTree.LeftChild;
                    this.binaryTree = this.binaryTree.RightChild;
                    return true;
                }

                BinaryTree<T> replaceNode = this.binaryTree.RightChild.FindElement();

                this.binaryTree.Value = replaceNode.Value;

                return true;
            }

            return this.binaryTree.Remove(value);
        }
    }
}