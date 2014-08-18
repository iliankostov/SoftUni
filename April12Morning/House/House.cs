using System;

class House
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char dot = '.';
        int outDots = (width - 1) / 2;
        int inDots = 1;
        int botDots = (int)(width / 4);

        for (int i = 1; i <= width; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(new String(dot, outDots) + asterisk + new String(dot, outDots));
                outDots--;
            }
            else if (i < (width + 1) / 2)
            {
                Console.WriteLine(new String(dot, outDots) + asterisk + new String(dot, inDots) + asterisk + new String(dot, outDots));
                outDots--;
                inDots += 2;
            }
            else if (i == (width + 1) / 2)
            {
                Console.WriteLine(new String(asterisk, width));
            }
            else if (i > (width + 1) / 2 && i < width)
            {
                Console.WriteLine(new String(dot, botDots) + asterisk + new String(dot, width - (botDots + 1) * 2) + asterisk + new String(dot, botDots));
            }
            else
            {
                Console.WriteLine(new String(dot, botDots) + new String(asterisk, width - botDots * 2) + new String(dot, botDots));
            }
        }
    }
}