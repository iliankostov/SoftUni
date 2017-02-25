namespace StacksAndQueues
{
    using System;

    public class LinkedQueueMain
    {
        public static void Main()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();
            numbers.Enqueue(1);
            numbers.Enqueue(2);
            numbers.Enqueue(3);
            numbers.Enqueue(4);
            numbers.Enqueue(5);

            Console.WriteLine(string.Join(" ", numbers.ToArray()));
        }
    }
}
