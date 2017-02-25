namespace Shapes
{
    using System;

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }

        public void CalculateArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            Console.WriteLine("The areaof the circle is: {0:0.00}", area);
        }

        public void CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            Console.WriteLine("The perimeter of the circle is: {0:0.00}", perimeter); 
        }
    }
}