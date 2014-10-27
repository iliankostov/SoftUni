using System;

class Triangle
{
    static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        double aSide = Math.Sqrt(Math.Pow((bX - aX), 2) + Math.Pow((bY - aY), 2));
        double bSide = Math.Sqrt(Math.Pow((cX - bX), 2) + Math.Pow((cY - bY), 2));
        double cSide = Math.Sqrt(Math.Pow((aX - cX), 2) + Math.Pow((aY - cY), 2));

        if (aSide + bSide > cSide && bSide + cSide > aSide && aSide + cSide > bSide)
        {
            double perimeter = (aSide + bSide + cSide) / 2;
            double area = Math.Sqrt(perimeter*(perimeter - aSide)*(perimeter - bSide)*(perimeter - cSide));
            Console.WriteLine("Yes\n{0:0.00}", area);
        }
        else
        {
            Console.WriteLine("No\n{0:0.00}", aSide);
        }      
    }
}