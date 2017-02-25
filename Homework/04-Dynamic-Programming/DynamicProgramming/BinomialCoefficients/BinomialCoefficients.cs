namespace BinomialCoefficients
{
    using System;
    using System.Collections.Generic;

    internal class BinomialCoefficients
    {
        private static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            var k = int.Parse(Console.ReadLine());

            var matrix = new List<List<int>>
                {
                    new List<int> { 1 },
                    new List<int> { 1, 1, 0 }
                };

            for (int row = 2; row <= n; row++)
            {
                matrix.Add(new List<int>() { 1 });
                for (int col = 1; col <= row; col++)
                {
                    var num = matrix[row - 1][col - 1] + matrix[row - 1][col];
                    matrix[row].Add(num);
                }

                matrix[row].Add(0);
            }

            Console.WriteLine(matrix[n][k]);
        }
    }
}