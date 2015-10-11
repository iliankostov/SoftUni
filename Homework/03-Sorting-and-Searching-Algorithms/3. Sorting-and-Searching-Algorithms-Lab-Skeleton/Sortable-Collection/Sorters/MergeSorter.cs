namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;

                this.MergeSort(collection, start, middle);
                this.MergeSort(collection, middle + 1, end);

                // Merge
                T[] leftArray = new T[middle - start + 1];
                T[] rightArray = new T[end - middle];

                Array.Copy(collection.ToArray(), start, leftArray, 0, middle - start + 1);
                Array.Copy(collection.ToArray(), middle + 1, rightArray, 0, end - middle);

                int i = 0;
                int j = 0;
                for (int k = start; k < end + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        collection[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        collection[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i].CompareTo(rightArray[j]) <= 0)
                    {
                        collection[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        collection[k] = rightArray[j];
                        j++;
                    }
                }
            }
        }
    }
}