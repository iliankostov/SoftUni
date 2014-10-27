using System;

class WineGlass
{
    static void Main()
    {
        int heigth = int.Parse(Console.ReadLine());

        int outDots = 0;
        int inAsterisk = heigth - 2;

        for (int i = 1; i <= heigth; i++)
        {
            if (i <= heigth / 2)
            {
                Console.WriteLine(new String('.', outDots) + '\\' + new String('*', inAsterisk) + '/' + new String('.', outDots));
                outDots++;
                inAsterisk -= 2;
            }
            else if (heigth < 12)
            {
                outDots = (heigth - 2) / 2;
                if (i > heigth / 2 && i < heigth)
                {
                    Console.WriteLine(new String('.', outDots) + "||" + new String('.', outDots));
                }
                else
                {
                    Console.WriteLine(new String('-', heigth));
                }
            }
            else
            {
                outDots = (heigth - 2) / 2;
                if (i > heigth / 2 && i < heigth - 1)
                {
                    Console.WriteLine(new String('.', outDots) + "||" + new String('.', outDots));
                }
                else
                {
                    Console.WriteLine(new String('-', heigth));                   
                }
            }
        }
    }
}