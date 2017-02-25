namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class BubleSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = collection.Count - 1; i >= 1; i--)
            {
                for (int h = 0; h <= i - 1; h++)
                {
                    if (collection[h].CompareTo(collection[h + 1]) > 0)
                    {
                        var temp = collection[h + 1];
                        collection[h + 1] = collection[h];
                        collection[h] = temp;
                    }
                }
            }
        }
    }
}