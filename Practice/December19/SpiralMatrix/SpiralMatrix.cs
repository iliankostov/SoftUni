using System;
using System.Linq;

class SpiralMatrix
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        char[] chars = new char[size*size];

        for (int a = 0, b = 0; a < size*size; a++, b++)
        {
            if (b > input.Length - 1)
            {
                b = 0;
            }
            chars[a] = input[b];

        }
        Console.WriteLine(string.Join(", ", chars.Select(v => v.ToString())));
    }
}
