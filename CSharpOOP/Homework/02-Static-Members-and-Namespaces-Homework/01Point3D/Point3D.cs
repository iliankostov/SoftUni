namespace Points3D
{
    using System;

    public class Point3D
    {
        // Create fields
        private static readonly Point3D startingPoint3D = new Point3D(0, 0, 0);
        private double x;
        private double y;
        private double z;
        
        // Create constructor
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Create static property StartingPoint3D
        public static Point3D StartingPoint3D
        {
            get
            {
                return startingPoint3D;
            }
        }

        // Create property X
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        // Create property Y
        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        // Create property Z
        public double Z
        {
            get
            {
                return this.z;
            }

            set
            {
                this.z = value;
            }
        }

        // Override toString() method
        public override string ToString()
        {
            return string.Format("x = {0:0.00}; y = {1:0.00}; z = {2:0.00}", this.X, this.Y, this.Z);
        }
    }
}
