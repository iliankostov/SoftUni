namespace StacksAndQueues
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayBasedStackUnitTests
    {
        [TestMethod]
        public void EmptyIntStackShouldHaveZeroCount()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();

            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void StackWithOneElementShouldHaveCountOne()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            arrayStack.Push(15);

            Assert.AreEqual(1, arrayStack.Count);
        }

        [TestMethod]
        public void TestPushPopCountArrayStackShouldWork()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            arrayStack.Push(15);
            int result = arrayStack.Pop();

            Assert.AreEqual(0, arrayStack.Count);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void EmptyStringStackShouldHaveZeroCount()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();

            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void PushOneThousandElementsAndCheckCount()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();
            for (int i = 0; i < 1000; i++)
            {
                arrayStack.Push("a");
            }

            Assert.AreEqual(1000, arrayStack.Count);
        }

        [TestMethod]
        public void TestPushPopCountStringArrayStackShouldWork()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();
            arrayStack.Push("check");

            for (int i = 0; i < 999; i++)
            {
                arrayStack.Push("error");
            }

            for (int i = 0; i < 999; i++)
            {
                arrayStack.Pop();
            }

            string result = arrayStack.Pop();

            Assert.AreEqual(0, arrayStack.Count);
            Assert.AreEqual("check", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The array stack is empty.")]
        public void CheckExeptionWhenPopFromEmptyArrayStack()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();
            arrayStack.Pop();
        }

        [TestMethod]
        public void AssertInnitialCapacytyNotChangeCount()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>(1);

            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void TestPushPopCountAssertWorkingCorrectly()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>(1);

            arrayStack.Push(1);
            Assert.AreEqual(1, arrayStack.Count);

            arrayStack.Push(2);
            Assert.AreEqual(2, arrayStack.Count);

            var result1 = arrayStack.Pop();
            Assert.AreEqual(2, result1);
            Assert.AreEqual(1, arrayStack.Count);

            var result2 = arrayStack.Pop();
            Assert.AreEqual(1, result2);
            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void ArrayBasedStackToArrayShouldReturnReversedArray()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            arrayStack.Push(3);
            arrayStack.Push(5);
            arrayStack.Push(-2);
            arrayStack.Push(7);

            int[] expected = { 7, -2, 5, 3 };
            int[] result = arrayStack.ToArray();
            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ArrayBasedStackDatesToArrayShouldReturnEmptyArray()
        {
            ArrayStack<DateTime> arrayStack = new ArrayStack<DateTime>();

            int[] expected = { };
            DateTime[] result = arrayStack.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
