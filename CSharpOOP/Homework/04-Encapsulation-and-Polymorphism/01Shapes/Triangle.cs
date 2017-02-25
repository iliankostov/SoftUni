namespace Shapes
{
    using System;

    public class Triangle : BasicShape
    {
        public Triangle(double width, double height) 
            : base(width, height)
        {            
        }

        public override void CalculateArea()
        {
            double area = (this.Width * this.Height) / 2;
            Console.WriteLine("The area of the triangle is: {0:0.00}", area);
        }

        public override void CalculatePerimeter()
        {
            double side = Math.Sqrt(Math.Pow(this.Width / 2, 2) + Math.Pow(this.Height, 2)); // Valid only for isoscale triangle !
            double perimeter = this.Width + side + side;
            Console.WriteLine("The perimeter of the triangle is: {0:0.00}", perimeter);
        }
    }
}
