using System;
class CheatSheet
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        long vStart = int.Parse(Console.ReadLine());
        long hStart = int.Parse(Console.ReadLine());

        for (long i = vStart; i < vStart + rows; i++)
        {
            for (long j = hStart; j < hStart + cols; j++)
            {
                Console.Write(i * j);
                if (j < hStart + cols - 1)
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}