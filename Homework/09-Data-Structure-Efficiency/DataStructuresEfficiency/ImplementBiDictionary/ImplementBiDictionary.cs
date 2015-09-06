namespace ImplementBiDictionary
{
    using System;

    internal class ImplementBiDictionary
    {
        private static void Main()
        {
            var distances = new BiDictionary<string, string, int>();
            distances.Add("Sofia", "Varna", 443);
            distances.Add("Sofia", "Varna", 468);
            distances.Add("Sofia", "Varna", 490);
            distances.Add("Sofia", "Plovdiv", 145);
            distances.Add("Sofia", "Bourgas", 383);
            distances.Add("Plovdiv", "Bourgas", 253);
            distances.Add("Plovdiv", "Bourgas", 292);
            Console.WriteLine(string.Join(", ", distances.FindByKey1("Sofia"))); // [443, 468, 490, 145, 383]
            Console.WriteLine(string.Join(", ", distances.FindByKey2("Bourgas"))); // [383, 253, 292]
            Console.WriteLine(string.Join(", ", distances.Find("Plovdiv", "Bourgas"))); // [253, 292]
            Console.WriteLine(string.Join(", ", distances.Find("Rousse", "Varna"))); // []
            Console.WriteLine(string.Join(", ", distances.Find("Sofia", "Varna"))); // [443, 468, 490]
            Console.WriteLine(distances.Remove("Sofia", "Varna")); // true
            Console.WriteLine(string.Join(", ", distances.FindByKey1("Sofia"))); // [145, 383]
            Console.WriteLine(string.Join(", ", distances.FindByKey2("Varna"))); // []
            Console.WriteLine(string.Join(", ", distances.Find("Sofia", "Varna"))); // []

        }
    }
}