using System;

class Sunglasses
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char dash = '/';
        char bridge = '|';
        char empty = ' ';

        Console.WriteLine(new String(asterisk, height * 2) + new String(empty, height) + new String(asterisk, height * 2));

        for (int i = 1; i <= height - 2; i++)
        {
            if (i == height/2)
            {
                Console.WriteLine(asterisk + new String(dash, height * 2 - 2) + asterisk + new String(bridge, height) + asterisk + new String(dash, height * 2 - 2) + asterisk);             
            }
            else
            {
                Console.WriteLine(asterisk + new String(dash, height * 2 - 2) + asterisk + new String(empty, height) + asterisk + new String(dash, height * 2 - 2) + asterisk);
            }
        }

        Console.WriteLine(new String(asterisk, height * 2) + new String(empty, height) + new String(asterisk, height * 2));
    }
}