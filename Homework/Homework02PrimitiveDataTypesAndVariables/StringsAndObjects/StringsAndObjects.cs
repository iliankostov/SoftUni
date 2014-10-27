using System;

class StringsAndObjects
{
    static void Main()
    {
        string str1Value = "Hello";
        string str2Value = "World";
        object objValue = str1Value + " " + str2Value;
        string str3Value = objValue.ToString();
        Console.WriteLine(str3Value);
    }
}