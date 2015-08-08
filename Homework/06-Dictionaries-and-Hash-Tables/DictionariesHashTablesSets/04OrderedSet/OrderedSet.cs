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
            // TODO in-order traversal
            throw new System.NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }
    }
}