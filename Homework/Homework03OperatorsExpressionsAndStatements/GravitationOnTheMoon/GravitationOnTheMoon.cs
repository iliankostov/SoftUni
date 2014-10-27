using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Plese enter man's weight: ");
        double earthManWeight = double.Parse(Console.ReadLine());
        double moonManWeight = earthManWeight * 17.0 / 100.0;
        Console.WriteLine("His weight on the moon will be " + moonManWeight + " kg.");
    }
}