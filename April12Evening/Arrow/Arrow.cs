using System;

class Arrow
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        char nSign = '#';
        char dots = '.';
        int height = width * 2 - 1;
        int outDashDots = (height - width) / 2;
        int outArrowDots = 1;
        int inArrowDots = height - 4;

        for (int i = 1; i <= height; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(new String(dots, outDashDots) + new String(nSign, width) + new String(dots, outDashDots));
            }
            else if (i > 1 && i < width)
            {
                Console.WriteLine(new String(dots, outDashDots) + nSign + new String(dots, width - 2) + nSign + new String(dots, outDashDots));
            }
            else if (i == width)
            {
                Console.WriteLine(new String(nSign, outDashDots + 1) + new String(dots, width - 2) + new String(nSign, outDashDots + 1));
            }
            else if (i > width && i < height)
            {
                Console.WriteLine(new String(dots, outArrowDots) + nSign + new String(dots, inArrowDots) + nSign + new String(dots, outArrowDots));
                outArrowDots++;
                inArrowDots -= 2;
            }
            else
            {
                Console.WriteLine(new String(dots, (height - 1)/2) + nSign + new String(dots, (height - 1)/2));
            }
        }
    }
}