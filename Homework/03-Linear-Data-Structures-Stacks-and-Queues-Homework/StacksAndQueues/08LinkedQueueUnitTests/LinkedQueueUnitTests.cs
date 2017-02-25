namespace QueuesAndQueues
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using StacksAndQueues;

    [TestClass]
    public class LinkedQueueUnitTests
    {
        private LinkedQueue<int> linkedQueueInt;

        private LinkedQueue<string> linkedQueueString;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedQueueInt = new LinkedQueue<int>();
            this.linkedQueueString = new LinkedQueue<string>();
        }

        [TestMethod]
        public void EmptyIntQueueShouldHaveZeroCount()
        {
            Assert.AreEqual(0, this.linkedQueueInt.Count);
        }

        [TestMethod]
        public void QueueWithOneElementShouldHaveCountOne()
        {
            this.linkedQueueInt.Enqueue(15);

            Assert.AreEqual(1, this.linkedQueueInt.Count);
        }

        [TestMethod]
        public void TestEnqueueDequeueCountLinkedQueueShouldWork()
        {
            this.linkedQueueInt.Enqueue(15);
            int result = this.linkedQueueInt.Dequeue();

            Assert.AreEqual(0, this.linkedQueueInt.Count);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void EmptyStringQueueShouldHaveZeroCount()
        {
            Assert.AreEqual(0, this.linkedQueueString.Count);
        }

        [TestMethod]
        public void EnqueueOneThousandElementsAndCheckCount()
        {
            for (int i = 0; i < 1000; i++)
            {
                this.linkedQueueString.Enqueue("a");
            }

            Assert.AreEqual(1000, this.linkedQueueString.Count);
        }

        [TestMethod]
        public void TestEnqueueDequeueCountStringLinkedQueueShouldWork()
        {
            this.linkedQueueString.Enqueue("check");

            for (int i = 0; i < 999; i++)
            {
                this.linkedQueueString.Enqueue("error");
            }

            string result = this.linkedQueueString.Dequeue();

            for (int i = 0; i < 999; i++)
            {
                this.linkedQueueString.Dequeue();
            }
            
            Assert.AreEqual(0, this.linkedQueueString.Count);
            Assert.AreEqual("check", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Queue is empty.")]
        public void CheckExeptionWhenPopFromEmptyLinkedQueue()
        {
            this.linkedQueueInt.Dequeue();
        }

        [TestMethod]
        public void TestEnqueueDequeueCountAssertWorkingCorrectly()
        {
            this.linkedQueueInt.Enqueue(1);
            Assert.AreEqual(1, this.linkedQueueInt.Count);

            this.linkedQueueInt.Enqueue(2);
            Assert.AreEqual(2, this.linkedQueueInt.Count);

            var result1 = this.linkedQueueInt.Dequeue();
            Assert.AreEqual(1, result1);
            Assert.AreEqual(1, this.linkedQueueInt.Count);

            var result2 = this.linkedQueueInt.Dequeue();
            Assert.AreEqual(2, result2);
            Assert.AreEqual(0, this.linkedQueueInt.Count);
        }

        [TestMethod]
        public void LinkedQueueToArrayShouldReturnReversedArray()
        {
            this.linkedQueueInt.Enqueue(7);
            this.linkedQueueInt.Enqueue(-2);
            this.linkedQueueInt.Enqueue(5);
            this.linkedQueueInt.Enqueue(3);

            int[] expected = { 7, -2, 5, 3 };
            int[] result = this.linkedQueueInt.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LinkedQueueOfDatesToArrayShouldReturnEmptyArray()
        {
            LinkedQueue<DateTime> linkedQueueDateTime = new LinkedQueue<DateTime>();
            int[] expected = { };
            DateTime[] result = linkedQueueDateTime.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
