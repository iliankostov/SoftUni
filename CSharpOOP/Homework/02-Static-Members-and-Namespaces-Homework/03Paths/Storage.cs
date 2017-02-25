namespace Paths
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Points3D;
    
    public static class Storage
    {
        public static void SavePathsToFile(List<Point3D> paths) 
        {
            StreamWriter writer = new StreamWriter("../../data.txt");
            try
            {              
                using (writer)
                {
                    foreach (Point3D point in paths)
                    {
                        writer.WriteLine(point.ToString());
                    }

                    Console.WriteLine("Your data was saved successful.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The data.txt file cannot be found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("The data.txt file cannot be load.");
            }
        }

        public static List<Point3D> LoadPathsFromFile()
        {
            string line;
            string patern = ".*?(\\d+.\\d+).*?(\\d+.\\d+).*?(\\d+.\\d+)";
            List<Point3D> paths = new List<Point3D>();
            StreamReader reader = new StreamReader("../../data.txt");

            try
            { 
                using (reader)
                {
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        MatchCollection matches = Regex.Matches(line, patern);
                        foreach (Match match in matches)
                        {
                            double x = double.Parse(match.Groups[1].Value);
                            double y = double.Parse(match.Groups[2].Value);
                            double z = double.Parse(match.Groups[3].Value);

                            Point3D point = new Point3D(x, y, z);
                            paths.Add(point);
                        }

                        line = reader.ReadLine();
                    }

                    Console.WriteLine("Your data was load successful.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The data.txt file cannot be found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("The data.txt file cannot be load.");
            }

            return paths;            
        }
    }
}