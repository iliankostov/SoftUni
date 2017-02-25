namespace EightQueens
{
    using System;

    internal class EightQueens
    {
        private const int Size = 8;

        private static int solutionFound;

        private static bool[,] chessboard = new bool[Size, Size];

        private static bool[] attackedColumns = new bool[Size];

        private static bool[] attackedLeftDiagonal = new bool[(2 * Size)];

        private static bool[] attackedRightDiagonal = new bool[(2 * Size)];

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied = attackedColumns[col] 
                || attackedLeftDiagonal[(col - row) + (Size - 1)]
                || attackedRightDiagonal[row + col];
            return !positionOccupied;
        }

        private static void Main()
        {
            PutQueens(0);
            Console.WriteLine(solutionFound);
        }

        private static void MarkAllAttackedPossition(int row, int col)
        {
            attackedColumns[col] = true;
            attackedLeftDiagonal[(col - row) + (Size - 1)] = true;
            attackedRightDiagonal[row + col] = true;
            chessboard[row, col] = true;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Console.Write(chessboard[row, col] ? "Q" : "-");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            solutionFound++;
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPossition(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPossition(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllAttackedPossition(int row, int col)
        {
            attackedColumns[col] = false;
            attackedLeftDiagonal[(col - row) + (Size - 1)] = false;
            attackedRightDiagonal[row + col] = false;
            chessboard[row, col] = false;
        }
    }
}