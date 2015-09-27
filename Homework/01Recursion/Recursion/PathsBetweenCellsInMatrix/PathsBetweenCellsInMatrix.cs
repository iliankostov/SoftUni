namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    internal class PathsBetweenCellsInMatrix
    {
        private static int exitFound;

        private static char[,] matrix =
            {
                { 's', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '*', '*', ' ', '*', ' ' },
                { ' ', '*', '*', ' ', '*', ' ' }, 
                { ' ', '*', 'e', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ' }
            };

        private static int numCols = matrix.GetLength(1);

        private static int numRows = matrix.GetLength(0);

        private static List<char> path = new List<char>();

        private static void FindExit(int row, int col, char dir)
        {
            if (row < 0 || col < 0 || row >= numRows || col >= numCols)
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                exitFound++;
                Print(dir);
                return;
            }

            if (matrix[row, col] != ' ' && matrix[row, col] != 's')
            {
                return;
            }

            matrix[row, col] = 'x';
            path.Add(dir);

            FindExit(row, col + 1, 'R');
            FindExit(row - 1, col, 'U');
            FindExit(row, col - 1, 'L');
            FindExit(row + 1, col, 'D');

            matrix[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void Main()
        {
            FindExit(0, 0, 's');
            Console.WriteLine("Total paths found: {0}", exitFound);
        }

        private static void Print(char dir)
        {
            for (int i = 1; i < path.Count; i++)
            {
                Console.Write(path[i]);
            }

            Console.WriteLine(dir);
        }
    }
}