namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    internal class PathsBetweenCellsInMatrix
    {
        private static readonly char[,] MatrixOne =
            {
                { 's', ' ', ' ', ' ' }, 
                { ' ', '*', '*', ' ' },
                { ' ', '*', '*', ' ' }, 
                { ' ', '*', 'e', ' ' },
                { ' ', ' ', ' ', ' ' }
            };

        private static readonly char[,] MatrixTwo =
            {
                { 's', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '*', '*', ' ', '*', ' ' },
                { ' ', '*', '*', ' ', '*', ' ' }, 
                { ' ', '*', 'e', ' ', ' ', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ' }
            };

        private static readonly List<char> Path = new List<char>();

        private static int exitFound;

        private static char[,] matrix;

        private static int numCols;

        private static int numRows;

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
            Path.Add(dir);

            FindExit(row, col + 1, 'R');
            FindExit(row - 1, col, 'U');
            FindExit(row, col - 1, 'L');
            FindExit(row + 1, col, 'D');

            matrix[row, col] = ' ';
            Path.RemoveAt(Path.Count - 1);
        }

        private static void Main()
        {
            SelectMatrix();
            FindExit(0, 0, 's');
            Console.WriteLine("Total paths found: {0}", exitFound);
        }

        private static void Print(char dir)
        {
            for (int i = 1; i < Path.Count; i++)
            {
                Console.Write(Path[i]);
            }

            Console.WriteLine(dir);
        }

        private static void SelectMatrix()
        {
            Console.Write("Select matrix 1 or 2: ");
            int matrixNumber = int.Parse(Console.ReadLine());
            if (matrixNumber == 1)
            {
                matrix = MatrixOne;
            }
            else if (matrixNumber == 2)
            {
                matrix = MatrixTwo;
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid matrix number");
            }

            numRows = matrix.GetLength(0);
            numCols = matrix.GetLength(1);
        }
    }
}