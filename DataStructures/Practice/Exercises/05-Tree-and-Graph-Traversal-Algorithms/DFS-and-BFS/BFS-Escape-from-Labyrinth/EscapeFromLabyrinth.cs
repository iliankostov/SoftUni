namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EscapeFromLabyrinth
    {
        private const char StartCell = 's';

        private static int width;

        private static int height;

        private static char[,] labyrinth;

        public static void Main()
        {
            PopulateLabyrinth();

            string shortestPathToExit = FindShortesPathToExit();

            if (shortestPathToExit == null)
            {
                Console.WriteLine("No exit!");
            }
            else if (shortestPathToExit == string.Empty)
            {
                Console.WriteLine("Start is at the exit.");
            }
            else
            {
                Console.WriteLine("Shortest exit: " + shortestPathToExit);
            }
        }

        private static string FindShortesPathToExit()
        {
            Queue<Point> queue = new Queue<Point>();

            Point startPosition = FindStartPosition();

            if (startPosition == null)
            {
                return null;
            }

            queue.Enqueue(startPosition);

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                if (IsExit(currentCell))
                {
                    return TracePathBack(currentCell);
                }

                TryDirection(queue, currentCell, "U", 0, -1);
                TryDirection(queue, currentCell, "R", 1, 0);
                TryDirection(queue, currentCell, "D", 0, 1);
                TryDirection(queue, currentCell, "L", -1, 0);
            }

            return null;
        }

        private static void PopulateLabyrinth()
        {
            width = int.Parse(Console.ReadLine());
            height = int.Parse(Console.ReadLine());
            labyrinth = new char[width, height];

            for (int y = 0; y < height; y++)
            {
                string line = Console.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    labyrinth[x, y] = line[x];
                }
            }
        }

        private static Point FindStartPosition()
        {
            for (int y = 0; y < labyrinth.GetLength(1); y++)
            {
                for (int x = 0; x < labyrinth.GetLength(0); x++)
                {
                    if (labyrinth[x, y] == StartCell)
                    {
                        return new Point { X = x, Y = y };
                    }
                }
            }

            return null;
        }

        private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
        {
            int newX = currentCell.X + deltaX;
            int newY = currentCell.Y + deltaY;
            if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newX, newY] == '-')
            {
                var nextCell = new Point()
                                   {
                                       X = newX,
                                       Y = newY,
                                       Direction = direction,
                                       PreviousPoint = currentCell
                                   };
                queue.Enqueue(nextCell);
            }
        }

        private static string TracePathBack(Point currentCell)
        {
            StringBuilder path = new StringBuilder();
            while (currentCell.PreviousPoint != null)
            {
                path.Append(currentCell.Direction);
                currentCell = currentCell.PreviousPoint;
            }

            return string.Join(string.Empty, path.ToString().Reverse());
        }

        private static bool IsExit(Point currentCell)
        {
            bool isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
            bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;
            return isOnBorderX || isOnBorderY;
        }
    }
}