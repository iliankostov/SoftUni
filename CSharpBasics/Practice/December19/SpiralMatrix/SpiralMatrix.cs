using System;
using System.Collections.Generic;

class SpiralMatrix
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        char[] chars = new char[size * size];       
        List<int> spiral = new List<int>();

        // Create char array
        for (int a = 0, b = 0; a < size * size; a++, b++)
        {
            if (b > input.Length - 1)
            {
                b = 0;
            }
            chars[a] = input[b];
        }

        // Create spiral array
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                spiral.Add( spiralMatrix(size, size, x, y) );  
            }
        }
        int[] matrix = spiral.ToArray();

        // Calculate weight by rows

        int rowSum = 0;
        int maxSum = 0;
        int rowNum = 0;
        int maxNum = 0;
        for (int c = 0, d = 0; c < size*size; c++, d++)
        {
            if (d == size)
            {
                if (rowSum > maxSum)
                {
                    maxSum = rowSum;
                    maxNum = rowNum;
                }
                rowNum++;
                rowSum = 0;
                d = 0;
            }
            int rowIndex = (char.ToLower(chars[matrix[c]]) - 96) * 10;
            rowSum += rowIndex;
                       
        }
        Console.WriteLine(maxNum + " - " + maxSum);
    }

    private static int spiralMatrix(int width, int heigth, int x, int y)
    {
        return (y != 0) ? width + spiralMatrix(heigth - 1, width, y - 1, width - x - 1) : x;
    }
}

