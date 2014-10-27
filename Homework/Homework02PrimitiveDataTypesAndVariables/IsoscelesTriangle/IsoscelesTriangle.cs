using System;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int height = int.Parse(Console.ReadLine());
        int width = 2 * height - 1;
        char copyright = '©';
        char empty = ' ';

        int outEmpty = (width - 1) / 2;
        int inEmpty = 0;

        for (int i = 1; i <= height; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(new String(empty, outEmpty) + copyright + new String(empty, outEmpty));
                outEmpty--;
                inEmpty++;
            }
            else if (i > 1 && i < height)
            {
                Console.WriteLine(new String(empty, outEmpty) + copyright + new String(empty, inEmpty) + copyright + new String(empty, outEmpty));
                outEmpty--;
                inEmpty += 2;
            }
            else if (i == height)
            {
                Console.Write(copyright);
                for (int j = 0; j < width/2; j++)
                {
                    Console.Write(empty);
                    Console.Write(copyright);
                }
            }
        }
        Console.WriteLine();
    }
}