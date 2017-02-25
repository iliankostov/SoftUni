namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InPlaceMergeSort(collection, 0, collection.Count - 1);
        }

        private void InPlaceMergeSort(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                this.InPlaceMergeSort(collection, start, mid);
                this.InPlaceMergeSort(collection, mid + 1, end);

                int leftIndex = start;
                int rightIndex = mid + 1;
                while (rightIndex <= end)
                {
                    if (collection[leftIndex].CompareTo(collection[rightIndex]) <= 0)
                    {
                        leftIndex++;
                        if (leftIndex == rightIndex)
                        {
                            break;
                        }
                    }
                    else
                    {
                        T tmp = collection[rightIndex];
                        for (int i = rightIndex; i > leftIndex; i--)
                        {
                            collection[i] = collection[i - 1];
                        }

                        collection[leftIndex] = tmp;

                        rightIndex++;
                        leftIndex++;
                    }
                }
            }
        }
    }
}