using System;

class Car
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = 3 * n;
        int height = width + 2;
        char dot = '.';
        char asterisk = '*';

        int outDots = n;
        int inDots = n;
      
        for (int i = 1; i <= n / 2; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(new String(dot, n) + new String(asterisk, n) + new String(dot, n));
                outDots--;
            }
            else
            {
                Console.WriteLine(new String(dot, outDots) + asterisk + new String(dot, inDots) + asterisk + new String(dot, outDots));
                outDots--;
                inDots += 2;
            }
        }

        for (int i = 1; i <= n / 2; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(new String(asterisk, (n + 2)/2) + new String(dot, inDots) + new String(asterisk, (n + 2)/2));                
            }
            else if (i < n/2)
            {
                Console.WriteLine(asterisk + new String(dot, width - 2) + asterisk);              
            }
            else
            {
                Console.WriteLine(new String(asterisk, width));
            }
        }

        outDots = n/2;
        inDots = n - 2;
        int wheelsWidth = (n + 2) / 2;

        for (int i = 1; i <= n/2-1; i++)
        {
            if (i < n/2-1)
            {
                Console.WriteLine(new String(dot, outDots) + asterisk + 
                                new String(dot, wheelsWidth - 2) + asterisk +
                                new String(dot, inDots) + asterisk +
                                new String(dot, wheelsWidth - 2) + asterisk +
                                new String(dot, outDots));
            }
            else
            {
                Console.WriteLine(new String(dot, outDots) + new String(asterisk, wheelsWidth) + new String(dot, inDots) + new String(asterisk, wheelsWidth) + new String(dot, outDots));
            }
        }
    }
}