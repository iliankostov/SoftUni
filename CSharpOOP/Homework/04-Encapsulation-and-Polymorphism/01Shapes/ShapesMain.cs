namespace Shapes
{
    using System;
    using System.Collections.Generic;

    internal class ShapesMain
    {
        internal static void Main()
        {
            List<Triangle> triangles = new List<Triangle>()
            {
                new Triangle(10.4, 5.8),
                new Triangle(20.5, 10.6),
                new Triangle(30.4, 15.6)
            };

            List<Rectangle> rectangles = new List<Rectangle>()
            {
                new Rectangle(10.5, 5.9),
                new Rectangle(20.4, 10.5),
                new Rectangle(30.5, 15.8)
            };

            List<Circle> circles = new List<Circle>()
            {
                new Circle(10),
                new Circle(20),
                new Circle(30)
            };

            foreach (var triangle in triangles)
            {
                triangle.CalculatePerimeter();
                triangle.CalculateArea();
            }

            Console.WriteLine();

            foreach (var rectangle in rectangles)
            {
                rectangle.CalculatePerimeter();
                rectangle.CalculateArea();
            }

            Console.WriteLine();

            foreach (var circle in circles)
            {
                circle.CalculatePerimeter();
                circle.CalculateArea();
            }
        }
    }
}