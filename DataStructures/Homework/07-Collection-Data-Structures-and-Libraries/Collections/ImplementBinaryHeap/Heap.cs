namespace ImplementBinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Heap<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 0;

        private const int GrowFactor = 2;

        private const int MinGrow = 1;

        private int capacity = InitialCapacity;

        private T[] heap = new T[InitialCapacity];

        private int tail;

        protected Heap()
            : this(Comparer<T>.Default)
        {
        }

        protected Heap(Comparer<T> comparer)
            : this(Enumerable.Empty<T>(), comparer)
        {
        }

        protected Heap(IEnumerable<T> collection)
            : this(collection, Comparer<T>.Default)
        {
        }

        protected Heap(IEnumerable<T> collection, Comparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            this.Comparer = comparer;

            foreach (var item in collection)
            {
                if (this.Count == this.Capacity)
                {
                    this.Grow();
                }

                this.heap[this.tail++] = item;
            }

            for (int i = Parent(this.tail - 1); i >= 0; i--)
            {
                this.BubbleDown(i);
            }
        }

        public int Count
        {
            get
            {
                return this.tail;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        protected Comparer<T> Comparer { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.heap.Take(this.Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Grow();
            }

            this.heap[this.tail++] = item;
            this.BubbleUp(this.tail - 1);
        }

        public T GetMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            return this.heap[0];
        }

        public T ExtractDominating()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            T ret = this.heap[0];
            this.tail--;
            this.Swap(this.tail, 0);
            this.BubbleDown(0);
            return ret;
        }

        protected abstract bool Dominates(T x, T y);

        private static int Parent(int i)
        {
            return ((i + 1) / 2) - 1;
        }

        private static int YoungChild(int i)
        {
            return ((i + 1) * 2) - 1;
        }

        private static int OldChild(int i)
        {
            return YoungChild(i) + 1;
        }

        private void BubbleUp(int i)
        {
            if (i == 0 || this.Dominates(this.heap[Parent(i)], this.heap[i]))
            {
                return; // correct domination (or root)
            }

            this.Swap(i, Parent(i));
            this.BubbleUp(Parent(i));
        }

        private void BubbleDown(int i)
        {
            int dominatingNode = this.Dominating(i);
            if (dominatingNode == i)
            {
                return;
            }

            this.Swap(i, dominatingNode);
            this.BubbleDown(dominatingNode);
        }

        private int Dominating(int i)
        {
            int dominatingNode = i;
            dominatingNode = this.GetDominating(YoungChild(i), dominatingNode);
            dominatingNode = this.GetDominating(OldChild(i), dominatingNode);

            return dominatingNode;
        }

        private int GetDominating(int newNode, int dominatingNode)
        {
            if (newNode < this.tail && !this.Dominates(this.heap[dominatingNode], this.heap[newNode]))
            {
                return newNode;
            }

            return dominatingNode;
        }

        private void Swap(int i, int j)
        {
            T tmp = this.heap[i];
            this.heap[i] = this.heap[j];
            this.heap[j] = tmp;
        }

        private void Grow()
        {
            int newCapacity = (this.capacity * GrowFactor) + MinGrow;
            var newHeap = new T[newCapacity];
            Array.Copy(this.heap, newHeap, this.capacity);
            this.heap = newHeap;
            this.capacity = newCapacity;
        }
    }
}