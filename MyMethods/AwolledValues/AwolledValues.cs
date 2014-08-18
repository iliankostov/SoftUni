using System;
class AllowedValue
{
    static void Main()
    {
        int value = int.Parse(Console.ReadLine());
        Console.WriteLine(AllowedValues(value));
    }

    private static bool AllowedValues(int num)
    {
        string digits = num.ToString();

        foreach (var element in digits)
        {
            if (element < '1' || element > '7')
            {
                return false;
            }
        }
        return true;
    }
}