﻿namespace GenericList
{
    using System;
    using System.Text;
    using GenericListVersion;

    [GenericListVersion(1, 1001)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] array;
        private int count;

        public GenericList()
        {
            this.array = new T[DefaultCapacity];
            this.Count = 0;
        }

        public GenericList(int length)
        {
            this.array = new T[length];
            this.Count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);
                return this.array[index];
            }
        }

        public void Add(T value)
        {
            this.EnsureCapacity();
            this.array[this.Count] = value;
            this.Count++;
        }

        public void Remove(int index)
        {
            this.CheckIndex(index);
            T[] buffer = new T[this.Capacity];
            for (int i = 0, position = 0; i < this.array.Length; i++, position++)
            {
                if (i == index)
                {
                    position--;
                    continue;
                }
                else
                {
                    buffer[position] = this.array[i];
                }
            }

            this.array = buffer;
            this.Count--;
        }

        public void InsertAt(T value, int index)
        {
            this.CheckIndex(index);
            T[] buffer = new T[this.Capacity + 1];
            for (int i = 0, position = 0; i < this.array.Length - 1; position++)
            {
                if (position == index)
                {
                    buffer[position] = value;
                    continue;
                }
                else
                {
                    buffer[position] = this.array[i];
                    i++;
                }
            }

            this.array = buffer;
            this.Count++;
        }

        public void Clear()
        {
            T[] buffer = new T[this.Capacity];
            this.array = buffer;
            this.Count = 0;
        }

        public int Find(T element)
        {
            return Array.BinarySearch<T>(this.array, 0, this.Count, element);
        }

        public T Min()
        {
            dynamic min = this.array[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = (dynamic)this.array[i];
                if (listItem.CompareTo(min) < 0)
                {
                    min = this.array[i];
                }
            }

            return min;
        }

        public T Max()
        {
            dynamic max = this.array[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = (dynamic)this.array[i];
                if (listItem.CompareTo(max) > 0)
                {
                    max = this.array[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                builder.AppendFormat("{0} -> {1}\n", index, this.array[index]);
            }

            return builder.ToString();
        }

        private void CheckIndex(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new IndexOutOfRangeException("The index must be nonnegative and less than the size of the GenericList");
            }
        }

        private void EnsureCapacity()
        {
            if (this.Count == this.Capacity)
            {
                T[] buffer = new T[this.Capacity * 2];
                for (int index = 0; index < this.array.Length; index++)
                {
                    buffer[index] = this.array[index];
                }

                this.array = buffer;
            }
        }
    }
}