using System;

class NewHouse
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char underline = '-';
        char wall = '|';

        int roofHeight = (height + 1) / 2;
        int outRoof = (height - 1) / 2;
        int roof = 1;

        for (int i = 1; i <=  height + roofHeight; i++)
        {
            if (i <= roofHeight)
            {
                Console.WriteLine(new String(underline, outRoof) + new String(asterisk, roof) + new String(underline, outRoof));
                outRoof--;
                roof += 2;
            }
            else
            {
                Console.WriteLine(new String(wall, 1) + new String(asterisk, height - 2) + new String(wall, 1));
            }
        }
    }
}