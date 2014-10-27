using System;

class ProgrammerDNA
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        char printChar = char.Parse(Console.ReadLine());
        char dots = '.';

        int width = 7;
        int mid = width / 2;
        int diff = 0;
        int counter = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j >= mid - diff && j <= mid + diff)
                {
                    Console.Write(printChar);
                    
                    if (printChar == 'G')
                    {
                        printChar = 'A';
                    }
                    else
                    {
                        printChar++;
                    }
                }
                else
                {
                    Console.Write(dots);
                }
            }

            if (counter >= mid)
            {
                diff--;
            }
            else
            {
                diff++;
            }

            counter++;   

            if (counter == width)
            {
                counter = 0;
                diff++;
            }

            Console.WriteLine();  
        }
    }
}
