namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    internal class ConnectedAreasInMatrix
    {
        private static readonly SortedSet<Area> Areas = new SortedSet<Area>();

        private static readonly char[,] MatrixOne =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
                { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
                { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' }
            };

        private static readonly char[,] MatrixTwo =
            {
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
                { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' }
            };

        private static int currentAreaSize;

        private static char[,] matrix;

        private static int numCols;

        private static int numRows;

        private static void FindAreas()
        {
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        MarkArea(row, col);
                        Areas.Add(new Area { Size = currentAreaSize, Row = row, Col = col });
                        currentAreaSize = 0;
                    }
                }
            }
        }

        private static void Main()
        {
            SelectMatrix();
            FindAreas();
            Print();
        }

        private static void MarkArea(int row, int col)
        {
            if (row < 0 || col < 0 || row >= numRows || col >= numCols)
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            currentAreaSize++;

            matrix[row, col] = 'x';

            MarkArea(row, col + 1);
            MarkArea(row + 1, col);
            MarkArea(row, col - 1);
            MarkArea(row - 1, col);
        }

        private static void Print()
        {
            int count = 1;
            Console.WriteLine("Total areas found: {0}", Areas.Count);
            foreach (var area in Areas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", count, area.Row, area.Col, area.Size);
                count++;
            }
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