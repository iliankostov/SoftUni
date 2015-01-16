using System;
using System.Collections.Generic;

class SpiralMatrix
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        char[] inputs = new char[size * size];       
        List<int> spiral = new List<int>();

        // Create char array
        for (int a = 0, b = 0; a < size * size; a++, b++)
        {
            if (b > input.Length - 1)
            {
                b = 0;
            }
            inputs[a] = input[b];
        }

        // Create spiral array
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                spiral.Add(f(size, size, x, y));  
            }
        }
        int[] ma3x = spiral.ToArray();

        // Test print
        Console.WriteLine(String.Join(", ", ma3x));
                

    }

    private static int f(int width, int heigth, int x, int y)
    {
        return (y != 0) ? width + f(heigth - 1, width, y - 1, width - x - 1) : x;
    }
}

