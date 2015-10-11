namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            int heapSize = collection.Count;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
            {
                this.MaxHeapify(collection, heapSize, p);
            }

            for (int i = collection.Count - 1; i > 0; i--)
            {
                T temp = collection[i];
                collection[i] = collection[0];
                collection[0] = temp;

                heapSize--;
                this.MaxHeapify(collection, heapSize, 0);
            }
        }

        private void MaxHeapify(List<T> collection, int heapSize, int index)
        {
            int left = ((index + 1) * 2) - 1;
            int right = (index + 1) * 2;
            int largest;

            if (left < heapSize && collection[left].CompareTo(collection[index]) > 0)
            {
                largest = left;
            }
            else
            {
                largest = index;
            }

            if (right < heapSize && collection[right].CompareTo(collection[largest]) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                T temp = collection[index];
                collection[index] = collection[largest];
                collection[largest] = temp;

                this.MaxHeapify(collection, heapSize, largest);
            }
        }
    }
}