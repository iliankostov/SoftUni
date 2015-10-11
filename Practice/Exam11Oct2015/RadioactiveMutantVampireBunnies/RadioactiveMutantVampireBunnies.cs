namespace RadioactiveMutantVampireBunnies
{
    using System;

    internal class RadioactiveMutantVampireBunnies
    {
        private static int cols;

        private static char[,] matrix;

        private static int rows;

        private static string ExpandBunies()
        {
            string output = null;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row != 0)
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                output = string.Format("dead {0} {1}", row - 1, col);
                            }

                            matrix[row - 1, col] = 'B';
                        }

                        if (row != rows - 1)
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                output = string.Format("dead {0} {1}", row + 1, col);
                            }

                            matrix[row + 1, col] = 'B';
                        }

                        if (col != 0)
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                output = string.Format("dead {0} {1}", row, col - 1);
                            }

                            matrix[row, col - 1] = 'B';
                        }

                        if (col != cols - 1)
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                output = string.Format("dead {0} {1}", row, col + 1);
                            }

                            matrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return output;
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        private static void Main()
        {
            var dimensions = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            rows = int.Parse(dimensions[0]);
            cols = int.Parse(dimensions[1]);
            matrix = new char[rows, cols];

            FillMatrix();

            var directions = Console.ReadLine();

            var result = ProcessTurn(directions);

            if (result != null)
            {
                PrintMatrix();
                Console.WriteLine(result);
            }
        }

        private static string MovePlayer(char direction)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        switch (direction)
                        {
                            case 'U':
                                if (row == 0)
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("won {0} {1}", row, col);
                                }

                                if (matrix[row - 1, col] == 'B')
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("dead {0} {1}", row, col);
                                }

                                matrix[row, col] = '.';
                                matrix[row - 1, col] = 'P';
                                break;
                            case 'L':
                                if (col == 0)
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("won {0} {1}", row, col);
                                }

                                if (matrix[row, col - 1] == 'B')
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("dead {0} {1}", row, col);
                                }

                                matrix[row, col] = '.';
                                matrix[row, col - 1] = 'P';
                                break;
                            case 'D':
                                if (row == rows - 1)
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("won {0} {1}", row, col);
                                }

                                if (matrix[row + 1, col] == 'B')
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("dead {0} {1}", row, col);
                                }

                                matrix[row, col] = '.';
                                matrix[row + 1, col] = 'P';
                                break;
                            case 'R':
                                if (col == cols - 1)
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("won {0} {1}", row, col);
                                }

                                if (matrix[row, col + 1] == 'B')
                                {
                                    matrix[row, col] = '.';
                                    return string.Format("dead {0} {1}", row, col);
                                }

                                matrix[row, col] = '.';
                                matrix[row, col + 1] = 'P';

                                break;
                        }
                    }
                }
            }

            return null;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static string ProcessTurn(string directions)
        {
            for (int turn = 0; turn < directions.Length; turn++)
            {
                var player = MovePlayer(directions[turn]);
                var bunies = ExpandBunies();

                if (player != null)
                {
                    return player;
                }

                if (bunies != null)
                {
                    return bunies;
                }
            }

            return null;
        }
    }
}