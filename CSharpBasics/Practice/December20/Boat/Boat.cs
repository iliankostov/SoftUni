using System;
class Boat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char dot = '.';

        int bodyheight = (n - 1) / 2;
        int leftDots = n - 1;
        int leftAsterisk = 1;
        int body = n;
        int outDot = 0;

        for (int i = 0; i <= n + bodyheight; i++)
        {
            if (i < bodyheight)
            {
                Console.WriteLine(new String(dot, leftDots) + new String(asterisk, leftAsterisk) + new String(dot, n));
                leftDots -= 2;
                leftAsterisk += 2;
            }
            if (i == bodyheight + 1)
            {
                Console.WriteLine(new String(asterisk, n) + new String(dot, n));
            }
            if (i > bodyheight + 1 && i <= n)
            {
                leftDots += 2;
                leftAsterisk -= 2;
                Console.WriteLine(new String(dot, leftDots) + new String(asterisk, leftAsterisk) + new String(dot, n));
            }
            if (i > n)
            {
                Console.WriteLine(new String(dot, outDot) + new String(asterisk, body*2) + new String(dot, outDot));
                outDot++;
                body --;
            }
        }
    }
}