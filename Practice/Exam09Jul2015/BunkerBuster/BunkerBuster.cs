namespace BunkerBuster
{
    using System;
    using System.Linq;

    internal class BunkerBuster
    {
        private static int cols;

        private static int[,] matrix;

        private static int rows;

        private static void FireBomb(int targetRow, int targetCol, int power)
        {
            var halfPower = (int)Math.Ceiling(power / 2.0);
            int startRow = Math.Max(0, targetRow - 1);
            int endRow = Math.Min(rows - 1, targetRow + 1);
            int startCol = Math.Max(0, targetCol - 1);
            int endCol = Math.Min(cols - 1, targetCol + 1);

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (row == targetRow && col == targetCol)
                    {
                        matrix[row, col] -= power;
                    }
                    else
                    {
                        matrix[row, col] -= halfPower;
                    }
                }
            }
        }

        private static int GetDestroyedBunckers()
        {
            int count = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] <= 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static void Main()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = dimensions[0];
            cols = dimensions[1];
            matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            var command = Console.ReadLine();
            while (command != "cease fire!")
            {
                var commandArgs = command.Split(' ');
                int targetRow = int.Parse(commandArgs[0]);
                int targetCol = int.Parse(commandArgs[1]);
                int power = char.Parse(commandArgs[2]);

                FireBomb(targetRow, targetCol, power);

                command = Console.ReadLine();
            }

            int destroyedBunkers = GetDestroyedBunckers();
            double percentage = ((destroyedBunkers * 1.0) / (rows * cols)) * 100;

            Console.WriteLine("Destroyed bunkers: {0}", destroyedBunkers);
            Console.WriteLine("Damage done: {0:F1} %", percentage);
        }
    }
}