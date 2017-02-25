namespace LinearDataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] items;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.items = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.items.Length;
            }
        }   
        
        public T this[uint index]
        {
            get
            {
                this.IsEmpty();
                return this.items[index - 1 - index];
            }

            set
            {
                this.items[this.Count - 1 - index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.items.Length - this.Count <= 0)
            {
                this.Grow();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public void Remove(uint index)
        {
            this.IsEmpty();
            for (long i = this.Count - 1 - index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow()
        {
            var newElements = new T[2 * this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.items[i];
            }

            this.items = newElements;
        }

        private void IsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
        }
    }
}
