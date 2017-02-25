namespace Shapes
{
    using System;

    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override void CalculateArea()
        {
            double area = this.Width * this.Height;
            Console.WriteLine("The area of the rectangle is {0:0.00}", area);
        }

        public override void CalculatePerimeter()
        {
            double perimeter = (this.Width * 2) + (this.Height * 2);
            Console.WriteLine("The perimeter of the rectangle is {0:0.00}", perimeter);
        }
    }
}