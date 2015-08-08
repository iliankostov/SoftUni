namespace DictionariesHashTablesSets
{
    using System;

    public class BinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value = default(T), BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public bool Add(T value)
        {
            if (this.Value.Equals(default(T)))
            {
                this.Value = value;
                return true;
            }

            if (this.Value.CompareTo(value) > 0)
            {
                if (this.LeftChild == null)
                {
                    this.LeftChild = new BinaryTree<T>();
                }

                if (this.LeftChild.Add(value))
                {
                    return true;
                }
            }

            if (this.Value.CompareTo(value) < 0)
            {
                if (this.RightChild == null)
                {
                    this.RightChild = new BinaryTree<T>();
                }

                if (this.RightChild.Add(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}