using System;

class QuotesInStrings
{
    static void Main()
    {
        string str1Value = "The \"use\" of quotations causes difficulties.";
        string str2Value = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("{0}\n{1}", str1Value, str2Value);
    }
}