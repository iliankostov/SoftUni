using System;

class HouseWithAWindow
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        char dots = '.';
        char asterisk = '*';

        int inDots = 1;
        int outDots = (height - 1);
        int windowHeight = height / 2;
        int windowWidth = height - 3;

        for (int i = 1; i <= height; i++)
        {
            if (i == 1)
	        {
		        Console.WriteLine(new String(dots, outDots) + asterisk + new String(dots, outDots));
                outDots--;
	        }
            else
	        {
                Console.WriteLine(new String(dots, outDots) + asterisk + new String(dots, inDots) + asterisk + new String(dots, outDots));
                outDots--;
                inDots += 2;
	        }            
        }
        Console.WriteLine(new String(asterisk, 2*height - 1));
        for (int i = 1; i <= height; i++)
        {
            if (i >= 1 && i <= height / 4)
            {
                Console.WriteLine(asterisk + new String(dots, 2 * height - 3) + asterisk);
            }
            else if (i > height / 4 && i <= (height / 2 + height / 4))
            {
                Console.WriteLine(asterisk + new String(dots, (height - 1 - (windowWidth + 1) /2)) +
                                            new String(asterisk, windowWidth) + 
                                            new String(dots, (height- 1 - (windowWidth + 1) / 2)) + asterisk);
            }
            else
            {
                Console.WriteLine(asterisk + new String(dots, 2 * height - 3) + asterisk);
            }
        }
        Console.WriteLine(new String(asterisk, 2 * height - 1));
    }
}