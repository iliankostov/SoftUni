namespace TestBinaryHeap
{
    using System.Collections.Generic;
    using System.Linq;

    using ImplementBinaryHeap;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestBinaryHeap
    {
        [TestMethod]
        public void TestAddAndCount()
        {
            var minHeap = new MinHeap<long>();
            minHeap.Add(9999999999);
            Assert.AreEqual(1, minHeap.Count);
        }

        [TestMethod]
        public void TestExtractAndCount()
        {
            var maxHeap = new MaxHeap<string>();
            maxHeap.Add("Ivan");
            maxHeap.Add("George");
            var expected = "Pesho";
            maxHeap.Add(expected);
            var actual = maxHeap.ExtractDominating();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2, maxHeap.Count);
        }

        [TestMethod]
        public void TestHeapBySortingInts()
        {
            var minHeap = new MinHeap<int>(new[] { 9, 8, 4, 1, 6, 2, 7, 4, 1, 2 });
            AssertHeapSortInts(minHeap, minHeap.OrderBy(i => i).ToArray());

            minHeap = new MinHeap<int> { 7, 5, 1, 6, 3, 2, 4, 1, 2, 1, 3, 4, 7 };
            AssertHeapSortInts(minHeap, minHeap.OrderBy(i => i).ToArray());

            var maxHeap = new MaxHeap<int>(new[] { 1, 5, 3, 2, 7, 56, 3, 1, 23, 5, 2, 1 });
            AssertHeapSortInts(maxHeap, maxHeap.OrderBy(d => -d).ToArray());

            maxHeap = new MaxHeap<int> { 2, 6, 1, 3, 56, 1, 4, 7, 8, 23, 4, 5, 7, 34, 1, 4 };
            AssertHeapSortInts(maxHeap, maxHeap.OrderBy(d => -d).ToArray());
        }

        [TestMethod]
        public void TestHeapBySortingStrings()
        {
            var minHeap = new MinHeap<string>(new[] { "do", "re", "mi", "fa", "sol", "la", "si", "do" });
            AssertHeapSortStrings(minHeap, minHeap.OrderBy(i => i).ToArray());

            minHeap = new MinHeap<string> { "a", "d", "b", "e", "c", "k", "o", "l", "p", "m", "q", "n", "r" };
            AssertHeapSortStrings(minHeap, minHeap.OrderBy(i => i).ToArray());
        }

        [TestMethod]
        public void TestHeapBySortingObjects()
        {
            var productOne = new TestProduct("ProductOne", 100M);
            var productTwo = new TestProduct("ProductTwo", 1000M);
            var productThree = new TestProduct("ProductOne", 20M);
            var productSame = new TestProduct("ProductOne", 20M);
            var productFour = new TestProduct("ProductOne", 200M);
            var productFive = new TestProduct("ProductOne", 500M);

            var minHeap = new MinHeap<TestProduct> { productOne, productTwo, productThree, productSame, productFour, productFive };
            var actual = minHeap.ExtractDominating();
            Assert.AreEqual(productThree, actual);
        }

        private static void AssertHeapSortInts(Heap<int> heap, IEnumerable<int> expected)
        {
            var sorted = new List<int>();
            while (heap.Count > 0)
            {
                sorted.Add(heap.ExtractDominating());
            }

            Assert.IsTrue(sorted.SequenceEqual(expected));
        }

        private static void AssertHeapSortStrings(Heap<string> heap, IEnumerable<string> expected)
        {
            var sorted = new List<string>();
            while (heap.Count > 0)
            {
                sorted.Add(heap.ExtractDominating());
            }

            Assert.IsTrue(sorted.SequenceEqual(expected));
        }
    }
}