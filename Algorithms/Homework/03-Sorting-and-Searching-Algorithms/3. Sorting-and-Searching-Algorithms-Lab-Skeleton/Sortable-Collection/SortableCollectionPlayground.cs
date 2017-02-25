namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        public static void Main(string[] args)
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Console.WriteLine("Unshuffled");
            Console.WriteLine(string.Join(", ", collection));

            collection.Shuffle();

            Console.WriteLine("Shuffled");
            Console.WriteLine(string.Join(", ", collection));

            collection.Shuffle();

            Console.WriteLine("Shuffled");
            Console.WriteLine(string.Join(", ", collection));
        }
    }
}