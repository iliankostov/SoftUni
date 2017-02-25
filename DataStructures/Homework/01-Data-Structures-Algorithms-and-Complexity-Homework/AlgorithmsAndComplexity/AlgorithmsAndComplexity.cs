namespace AlgorithmsAndComplexity
{
    using System;
    using System.IO;

    public class AlgorithmsAndComplexity
    {
        public static void Main()
        {
            string path = @"..\..\output.txt";
            string hr = new string('-', 55);
            File.Create(path).Dispose();
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(hr);
            sw.WriteLine("Problem 1. Add(T) Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 2. Remove(index) Complexity – Worst Case:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 3. Remove(index) Complexity – Best Case:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 4. Remove(index) Complexity – Average Case:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 5. RemoveFirst(T) Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 6. RemoveLast(T) Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 7. Length Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 8. This[index] Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 9. First Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.WriteLine("Problem 10. Last Complexity:");
            sw.WriteLine(@"O(N)");
            sw.WriteLine(hr);
            sw.Close();
            Console.WriteLine("Find the output.txt next to .sln");
        }
    }
}
