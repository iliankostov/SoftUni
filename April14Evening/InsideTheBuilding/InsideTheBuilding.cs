using System;

class InsideTheBuilding
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int[] points = new int[10];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = int.Parse(Console.ReadLine());
        }

        int[] x = new int[5];
        int[] y = new int[5];
        for (int i = 0, j = 0; i < points.Length; i++)
        {
            if (i % 2 == 0)
            {
                x[j] = points[i];
                j++;
            }
        }
        for (int i = 0, j = 0; i < points.Length; i++)
        {
            if (i % 2 !=0)
            {
                y[j] = points[i];
                j++;
            }
        }
       

        for (int i = 0; i < x.Length; i++)
        {
            bool horizontal = x[i] >= 0 && x[i] <= 3 * height && y[i] >= 0 && y[i] <= height;
            bool vertical = x[i] >= height && x[i] <= 2 * height && y[i] > height && y[i] <= 4 * height;
            if (horizontal)
            {
                Console.WriteLine("inside");
            }
            else if (vertical)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
        
    }
}