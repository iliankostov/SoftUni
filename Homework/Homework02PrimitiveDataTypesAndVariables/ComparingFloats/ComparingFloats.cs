using System;

class ComparingFloats
{
    static void Main()
    {
        Console.Write("Please enter number 1: ");
        double dOne = double.Parse(Console.ReadLine());
        Console.Write("Please enter number 2: ");
        double dTwo = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        string question = "Are the numbers equal with precision 0.000001: ";
        if (dOne > dTwo)
        {
            if (dOne - dTwo > eps)
            {
                Console.Write(question);
                Console.WriteLine(false);
            }
            else
            {
                Console.Write(question);
                Console.WriteLine(true);
            }
            
        }
        else if (dTwo > dOne)
        {
            if (dTwo - dOne > eps)
            {
                Console.Write(question);
                Console.WriteLine(false);
            }
            else
            {
                Console.Write(question);
                Console.WriteLine(true);
            }
            
        }      
    }
}