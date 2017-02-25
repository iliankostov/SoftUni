using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssertionsUnitTest
{
    [TestClass]
    public class AssertionsTest
    {
        [TestMethod]
        public void TestSelectionSort()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Assertions.SelectionSort(arr);
            string afterSortActual = string.Join(", ", arr);
            string afterSortExpected = "-1, 0, 2, 3, 4, 15, 17, 33";

            Assert.AreEqual(afterSortExpected, afterSortActual);
        }

        [TestMethod]
        public void TestSortingSingleElementArray()
        {
            int[]arr = new int[1]{1};
            Assertions.SelectionSort(arr);
            Assert.AreEqual(1,1);
        }

        [TestMethod]
        public void TestBinarySearchForNonExistingElement()
        {
            int[] arr = new int[] { -1, 0, 2, 3, 4, 15, 17, 33 };
            int num = Assertions.BinarySearch(arr, -1000);
            Assert.AreEqual(-1, num);
        }

        [TestMethod]
        public void TestBinarySearchForExistingElementOnLeftSide()
        {
            int[] arr = new int[] { -1, 0, 2, 3, 4, 15, 17, 33 };
            int num = Assertions.BinarySearch(arr, 0);
            Assert.AreEqual(1, num);
        }

        [TestMethod]
        public void TestBinarySearchForExistingElementOnRightSide()
        {
            int[] arr = new int[] { -1, 0, 2, 3, 4, 15, 17, 33 };
            int num = Assertions.BinarySearch(arr, 17);
            Assert.AreEqual(6, num);
        }
    }
}