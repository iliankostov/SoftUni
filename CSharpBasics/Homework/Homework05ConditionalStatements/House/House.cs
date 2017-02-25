using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char dot = '.';
        string firstLine = new string(dot, (n / 2)) + asterisk + new string(dot, (n / 2));
        string midLane = new string(asterisk, n);

        int innerRoofDots = 1;
        int outerRoofDots = (n / 2) - 1;
        int outerWallDots = n / 4;

        for (int i = 1; i <= n; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(firstLine);
            }   
            else if (i <= n/2)
            {
                Console.WriteLine(new string(dot, outerRoofDots) + asterisk + new string(dot, innerRoofDots) + asterisk + new string(dot, outerRoofDots));
                outerRoofDots--;
                innerRoofDots += 2;
            }
            else if (i == (n+1)/2)
            {
                Console.WriteLine(midLane);
            }
            else if (i < n)
            {
                Console.WriteLine(new string(dot, outerWallDots) + asterisk + new string(dot, n - 2 - (2 * outerWallDots)) + asterisk + new string(dot, outerWallDots));
            }
            else
            {
                Console.WriteLine(new string(dot, outerWallDots) + new string(asterisk, n - (2 * outerWallDots)) + new string(dot, outerWallDots));
            }

        }        
    }
}