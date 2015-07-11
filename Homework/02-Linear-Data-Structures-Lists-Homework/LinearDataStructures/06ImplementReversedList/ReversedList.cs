namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;

    public class ReversedList<T>
    {
        private const int DefaultCapacity = 16;

        private T[] items;

        public int Counter { get; private set; }

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.items = new T[capacity];
        }

        public void Add(T item)
        {
            if (this.items.Length - this.Counter <= 0)
            {
                this.Grow();
            }

            this.Counter++;

            throw new NotImplementedException();
        }

        public int Count()
        {
            return this.Counter;
        }

        public int Capacity()
        {
            return this.items.Length;
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
        } 

        public void Remove(int index)
        {
            var tempList = new List<T>(this.items);
            tempList.RemoveAt(index);
            this.items = tempList.ToArray();
            this.Counter--;
        }

        private void Grow()
        {
            throw new NotImplementedException();
        }
    }
}
