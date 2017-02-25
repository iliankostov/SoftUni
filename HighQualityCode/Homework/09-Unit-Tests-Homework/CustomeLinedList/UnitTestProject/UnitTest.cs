namespace UnitTestProject
{
    using System;

    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetingElementAtCorrectPositionFromNoneEmptyDynamicListOfIntsShouldReturnCorrectElement()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            Assert.AreEqual(3, dynamicListOfInts[2], "Obtained value of getting a element whit operator \"[]\" is not as expected\nNote that position couting should start from 0!");
        }           

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void SettingElementAtOutOfRangePositionInNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            dynamicListOfInts[4] = 4;
        } 

        [TestMethod]
        public void RemovingElementAtCorrectPositionFromNoneEmptyDynamicListOfIntsShouldReturnCorrectObject()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(0);
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            int startingCount = dynamicListOfInts.Count;

            dynamicListOfInts.RemoveAt(1);
            bool isRemovedAtPositionCorrect =
                dynamicListOfInts[0] == 0 &&
                dynamicListOfInts[1] == 2 &&
                dynamicListOfInts.Count == startingCount - 1;

            Assert.AreEqual(true, isRemovedAtPositionCorrect, string.Format("The method \"RemoveAt\" does not work correctly!"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "That Exception is not expected")]
        public void RemovingElementAtOutOfRangePositionFromNoneEmptyDynamicListOfIntsShouldThrowException()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);
            dynamicListOfInts.Add(2);
            dynamicListOfInts.Add(3);

            dynamicListOfInts.RemoveAt(4);
        }

        [TestMethod]
        public void RemovingNoneExistingElementFromNoneEmptyDynamicListOfIntsShouldReturnMinusOne()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            var returnedValue = dynamicListOfInts.Remove(9);

            Assert.AreEqual(-1, returnedValue, string.Format("The method \"Remove\" does not work correctly when removing none existing number.\nShould return -1!" + string.Format("returned value is {0}", returnedValue)));
        }

        [TestMethod]
        public void GettingIndexOfNoneExistingElementFromNoneEmptyDynamicListOfIntsShouldReturnMinusOne()
        {
            var dynamicListOfInts = new DynamicList<int>();
            dynamicListOfInts.Add(1);

            var returnedValue = dynamicListOfInts.IndexOf(9);

            Assert.AreEqual(-1, returnedValue, string.Format("The method \"IndexOf\" does not work correctly when tring to get none existing number." + string.Format("\nShould return -1 it returns {0}!", returnedValue)));
        }

        [TestMethod]
        public void CreateEmtyListWithZeroElemements()
        {
            var numbers = new DynamicList<int>();
            Assert.AreEqual(0, numbers.Count, "Number of elements is not equal to zero.");
        }

        [TestMethod]
        public void ConstructingListWithFewElementsChangeValueInSomePosition()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(0);
            numbers.Add(1);
            numbers.Add(-4);
            numbers[0] = 100;

            Assert.AreEqual(100, numbers[0], "Value is not equal of expected.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AgainstIndexGreaterThanTheNumberOfElementsShouldThrowArgumentOutOfRangeException()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            var number = numbers[numbers.Count];
        }

        [TestMethod]
        public void FoundingElementInListShouldReturnIndexOfElement()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            numbers.Add(12);
            numbers.Add(-14);
            var index = numbers.IndexOf(-14);

            Assert.AreEqual(2, index, "Invalid index.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldRemoveElementOfList()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(15);
            numbers.Add(10);
            var number = numbers.RemoveAt(0);
            var result = numbers.IndexOf(0);

            Assert.AreEqual(-1, result, "The elements is founded.");
            Assert.AreEqual(10, numbers[0], "Do not reorders the elements.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldReturnElement()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(15);
            var number = numbers.RemoveAt(0);

            Assert.AreEqual(15, number, "Value is not equal of expected.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldDecreaseCount()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(15);
            var number = numbers.RemoveAt(0);

            Assert.AreEqual(0, numbers.Count, "The count does not decrease.");
        }

        [TestMethod]
        public void FoundingElementInListShouldNotFoundIt()
        {
            var numbers = new DynamicList<int>();

            numbers.Add(10);
            numbers.Add(12);
            numbers.Add(-14);

            var initialCount = numbers.Count;
            var index = numbers.Remove(12);

            Assert.IsFalse(numbers.Contains(12), "The element is not removed.");
            Assert.IsTrue(numbers.Count < initialCount, "The count does not decrease.");
            Assert.AreEqual(1, index, "Return invalid index.");
        }
    }
}