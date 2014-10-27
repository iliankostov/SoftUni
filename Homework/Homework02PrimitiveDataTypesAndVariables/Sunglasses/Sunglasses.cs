using System;

class Sunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char frames = '*';
        char lenses = '/';
        char bridge = '|';

        string upDownLine = new string(frames, n * 2) + new string(' ', n) + new string(frames, n * 2);
        string middleLenses = "";

        Console.WriteLine(upDownLine);

        for (int i = 1; i <= n - 2; i++)
        {
            if (i == n/2)
            {
                middleLenses = new string(frames, n / n) + new string(lenses, (n - 1) * 2) + new string(frames, n / n) + new string(bridge, n) + new string(frames, n / n) + new string(lenses, (n - 1) * 2) + new string(frames, n / n);
                Console.WriteLine(middleLenses);
            }
            else
            {
                middleLenses = new string(frames, n / n) + new string(lenses, (n - 1) * 2) + new string(frames, n / n) + new string(' ', n) + new string(frames, n / n) + new string(lenses, (n - 1) * 2) + new string(frames, n / n);
                Console.WriteLine(middleLenses);
            }
            
        }
               
        Console.WriteLine(upDownLine);

    }
}