namespace Paths
{
    using System;    
    using System.Collections.Generic;
    using Points3D;

    public class Path3D
    {
        // Create constructor
        public Path3D(List<Point3D> paths)
        {
            this.Paths = paths;
        }

        // Create readonly property
        public List<Point3D> Paths { get; private set; }
    }
}