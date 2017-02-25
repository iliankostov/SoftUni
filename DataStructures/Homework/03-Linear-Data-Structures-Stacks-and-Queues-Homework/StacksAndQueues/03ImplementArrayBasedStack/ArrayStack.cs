namespace StacksAndQueues
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;

        public int Count { get; private set; }

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The array stack is empty.");
            }

            T element = this.elements[this.Count - 1];

            var newElements = new T[this.elements.Length];

            for (int i = 0; i < this.Count - 1; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.elements = newElements;
            this.Count--;

            return element;
        }

        public T[] ToArray()
        {
            var elements = new T[this.Count];

            var count = this.Count - 1;
            for (int i = 0; i < this.Count; i++)
            {
                elements[i] = this.elements[count];
                count--;
            }

            return elements;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.elements.Length];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
