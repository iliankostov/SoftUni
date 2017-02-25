using System;

class Rectangles
{
    static void Main()
    {
        Console.Write("Please enter the rectangle's width: ");
        double rectangleWidth = double.Parse(Console.ReadLine());
        Console.Write("Plese enter the rectangle's height: ");
        double rectangleHeight = double.Parse(Console.ReadLine());
        double rectanglePerimeter = 2 * (rectangleWidth + rectangleHeight);
        double rectangleArea = rectangleWidth * rectangleHeight;
        Console.WriteLine("The rectangle's perimeter is : {0} \nThe rectangle's area is: {1}", rectanglePerimeter, rectangleArea);
    }
}