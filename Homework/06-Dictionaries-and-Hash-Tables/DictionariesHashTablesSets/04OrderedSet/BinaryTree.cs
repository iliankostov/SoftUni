namespace DictionariesHashTablesSets
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTree<T> leftChild;

        private BinaryTree<T> rightChild;

        public T Value { get; set; }

        public BinaryTree<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                this.leftChild = value;
            }
        }

        public BinaryTree<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                this.rightChild = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var element in this.LeftChild)
                {
                    yield return element;
                }
            }

            yield return this.Value;

            if (this.RightChild != null)
            {
                foreach (var element in this.RightChild)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

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

                return this.LeftChild.Add(value);
            }

            if (this.Value.CompareTo(value) < 0)
            {
                if (this.RightChild == null)
                {
                    this.RightChild = new BinaryTree<T>();
                }

                return this.RightChild.Add(value);
            }

            return false;
        }

        public bool Contains(T value)
        {
            if (this.Value.Equals(value))
            {
                return true;
            }

            if (this.Value.CompareTo(value) > 0)
            {
                if (this.LeftChild != null)
                {
                    return this.LeftChild.Contains(value);
                }
            }

            if (this.Value.CompareTo(value) < 0)
            {
                if (this.RightChild != null)
                {
                    return this.RightChild.Contains(value);                    
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            if (this.Value.CompareTo(value) < 0)
            {
                return RemoveElement(value, ref this.rightChild);
            }

            if (this.Value.CompareTo(value) > 0)
            {
                return RemoveElement(value, ref this.leftChild);
            }

            return false;
        }

        public BinaryTree<T> FindElement()
        {
            if (this.LeftChild.LeftChild != null)
            {
                return this.LeftChild.FindElement();
            }

            var tempChild = this.LeftChild;
            this.LeftChild = null;
            return tempChild;
        }

        private static bool RemoveElement(T value, ref BinaryTree<T> element)
        {
            if (element == null)
            {
                return false;
            }

            if (element.Value.CompareTo(value) == 0)
            {
                if (element.RightChild == null)
                {
                    element = element.LeftChild;
                    return true;
                }

                if (element.RightChild.LeftChild == null)
                {
                    element.RightChild.LeftChild = element.LeftChild;
                    element = element.RightChild;
                    return true;
                }

                var replaceChild = element.RightChild.FindElement();

                element.Value = replaceChild.Value;

                return true;
            }

            return element.Remove(value);
        }
    }
}