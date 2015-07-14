namespace StacksAndQueues
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedStackUnitTests
    {
        private LinkedStack<int> linkedStackInt;

        private LinkedStack<string> linkedStackString;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedStackInt = new LinkedStack<int>();
            this.linkedStackString = new LinkedStack<string>();
        }

        [TestMethod]
        public void EmptyIntStackShouldHaveZeroCount()
        {
            Assert.AreEqual(0, this.linkedStackInt.Count);
        }

        [TestMethod]
        public void StackWithOneElementShouldHaveCountOne()
        {
            this.linkedStackInt.Push(15);

            Assert.AreEqual(1, this.linkedStackInt.Count);
        }

        [TestMethod]
        public void TestPushPopCountLinkedStackShouldWork()
        {
            this.linkedStackInt.Push(15);
            int result = this.linkedStackInt.Pop();

            Assert.AreEqual(0, this.linkedStackInt.Count);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void EmptyStringStackShouldHaveZeroCount()
        {
            Assert.AreEqual(0, this.linkedStackString.Count);
        }

        [TestMethod]
        public void PushOneThousandElementsAndCheckCount()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.linkedStackString.Push("a");
            }

            Assert.AreEqual(1000, this.linkedStackString.Count);
        }

        [TestMethod]
        public void TestPushPopCountStringLinkedStackShouldWork()
        {
            this.linkedStackString.Push("check");

            for (int i = 0; i < 999; i++)
            {
                this.linkedStackString.Push("error");
            }

            for (int i = 0; i < 999; i++)
            {
                this.linkedStackString.Pop();
            }

            string result = this.linkedStackString.Pop();

            Assert.AreEqual(0, this.linkedStackString.Count);
            Assert.AreEqual("check", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The linked stack is empty.")]
        public void CheckExeptionWhenPopFromEmptyLinkedStack()
        {
            this.linkedStackInt.Pop();
        }

        [TestMethod]
        public void AssertInnitialCapacytyNotChangeCount()
        {
            Assert.AreEqual(0, this.linkedStackInt.Count);
        }

        [TestMethod]
        public void TestPushPopCountAssertWorkingCorrectly()
        {
            this.linkedStackInt.Push(1);
            Assert.AreEqual(1, this.linkedStackInt.Count);

            this.linkedStackInt.Push(2);
            Assert.AreEqual(2, this.linkedStackInt.Count);

            var result1 = this.linkedStackInt.Pop();
            Assert.AreEqual(2, result1);
            Assert.AreEqual(1, this.linkedStackInt.Count);

            var result2 = this.linkedStackInt.Pop();
            Assert.AreEqual(1, result2);
            Assert.AreEqual(0, this.linkedStackInt.Count);
        }

        [TestMethod]
        public void LinkedStackToArrayShouldReturnReversedArray()
        {
            this.linkedStackInt.Push(3);
            this.linkedStackInt.Push(5);
            this.linkedStackInt.Push(-2);
            this.linkedStackInt.Push(7);

            int[] expected = { 7, -2, 5, 3 };
            int[] result = this.linkedStackInt.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LinkedStackOfDatesToArrayShouldReturnEmptyArray()
        {
            LinkedStack<DateTime> linkedStackDateTime = new LinkedStack<DateTime>();
            int[] expected = { };
            DateTime[] result = linkedStackDateTime.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
