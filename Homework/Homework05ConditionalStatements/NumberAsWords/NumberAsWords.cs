using System;

class NumberAsWords
{
    static void Main()
    {
        Console.Write("Please enter number in range [0...999]: ");
        int numberToConvert = int.Parse(Console.ReadLine());
        string result = NumberToWords(numberToConvert);
        Console.WriteLine(result);
    }
    public static string NumberToWords(int number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0 || number > 999)
        {
            return "out of range";
        }

        string words = "";              

        if ((number / 100) > 0)
        {
            words += NumberToWords(number / 100) + " hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }

        return words;
    }
}