namespace Shapes
{
    using System;

    public abstract class BasicShape : IShape
    {
        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public abstract void CalculateArea();

        public abstract void CalculatePerimeter(); 
    }
}