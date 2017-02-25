namespace HashTable
{
    using System;

    public class Example
    {
        public static void Main()
        {
            var grades = new HashTable<string, int>();
            Console.WriteLine("Grades:" + string.Join(",", grades));
            Console.WriteLine("--------------------");

            grades.Add("Peter", 3);
            grades.Add("Maria", 6);
            grades["George"] = 5;

            Console.WriteLine("Grades:" + string.Join(",", grades));
            Console.WriteLine("--------------------");

            grades.AddOrReplace("Peter", 33);
            grades.AddOrReplace("Tanya", 4);
            grades["George"] = 55;
            Console.WriteLine("Grades:" + string.Join(",", grades));
            Console.WriteLine("--------------------");

            Console.WriteLine("Keys: " + string.Join(", ", grades.Keys));
            Console.WriteLine("Values: " + string.Join(", ", grades.Values));
            Console.WriteLine("Count = " + string.Join(", ", grades.Count));
            Console.WriteLine("--------------------");

            grades.Remove("Peter");
            grades.Remove("George");
            grades.Remove("George");
            Console.WriteLine("Grades:" + string.Join(",", grades));
            Console.WriteLine("--------------------");

            Console.WriteLine("ContainsKey[\"Tanya\"] = " + grades.ContainsKey("Tanya"));
            Console.WriteLine("ContainsKey[\"George\"] = " + grades.ContainsKey("George"));
            Console.WriteLine("Grades[\"Tanya\"] = " + grades["Tanya"]);
            Console.WriteLine("--------------------");

            grades.Add("Maria1", 5);
            grades.Add("Maria12", 6);
            grades.Add("Peter 13", 5);
            grades.Add("Peter 14", 5);
            grades.Add("George 1", 6);
            grades.Add("George 11", 6);
            grades.Add("George 12", 5);
            grades.Add("George 2", 5);
            grades.Add("George 3", 5);
            grades.Add("Maria 3", 5);
            //grades.Add("Maria 2", 5);

            Console.WriteLine("\nCollisions deep: {0}\n--------------------", grades.CalculateCollisionsDeep());
            Console.WriteLine("\nHashTable preview: \n--------------------\n{0}", grades);
        }
    }
}
