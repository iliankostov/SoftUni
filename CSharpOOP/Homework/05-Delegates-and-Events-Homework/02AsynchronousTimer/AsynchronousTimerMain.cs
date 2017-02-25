namespace AsynchronousTimer
{
    using System;

    internal class AsynchronousTimerMain
    {
        public static void WriteSeconds(string str)
        {
            Console.WriteLine(str);
        }

        internal static void Main()
        {
            AsyncTimer at = new AsyncTimer(WriteSeconds, 1000, 0);
            at.Run();

            Console.WriteLine("Press the Enter key to exit the program... ");
            Console.ReadLine();
            Console.WriteLine("Terminating the application...");
        }
    }
}