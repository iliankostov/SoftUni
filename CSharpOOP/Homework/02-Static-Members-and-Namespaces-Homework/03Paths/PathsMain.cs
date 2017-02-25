namespace Paths
{
    using System;
    using System.Collections.Generic;
    using Points3D;
    
    internal class PathsMain
    {
        internal static void Main()
        {
            // Generating inputs
            Point3D pointZero = Point3D.StartingPoint3D;
            Point3D pointOne = new Point3D(1.0, 1.0, 1.0);
            Point3D pointTwo = new Point3D(2.0, 2.0, 2.0);
            List<Point3D> inputList = new List<Point3D> { pointZero, pointOne, pointTwo };

            // Save to file
            Path3D pathsToSave = new Path3D(inputList);
            Storage.SavePathsToFile(pathsToSave.Paths);

            // Load from file
            Path3D pathsToLoad = new Path3D(Storage.LoadPathsFromFile());
           
            // Print the list
            Console.WriteLine("Your paths are:");
            foreach (Point3D point in pathsToLoad.Paths)
            {
                Console.WriteLine(point.ToString());
            }
        }
    }
}