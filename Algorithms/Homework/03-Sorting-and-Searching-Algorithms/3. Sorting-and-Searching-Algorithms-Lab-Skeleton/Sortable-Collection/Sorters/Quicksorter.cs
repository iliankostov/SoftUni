namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = array[start];
            int storeIndex = start + 1;
            T temp;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    temp = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = temp;

                    storeIndex++;
                }
            }

            storeIndex--;

            temp = array[start];
            array[start] = array[storeIndex];
            array[storeIndex] = temp;

            this.Quicksort(array, start, storeIndex);
            this.Quicksort(array, storeIndex + 1, end);
        }
    }
}