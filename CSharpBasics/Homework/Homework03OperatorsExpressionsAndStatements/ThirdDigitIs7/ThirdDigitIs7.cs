using System;

class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Please enter your int number: ");
        int n = int.Parse(Console.ReadLine());        
        if (n < 700)
        {            
            Console.WriteLine(false);
        }
        else
        {
            string number = n.ToString();
            string modifiedNumber = number.Substring(number.Length - 3);
            int threeDigit = int.Parse(modifiedNumber);
            if (threeDigit < 700 || threeDigit > 799)
            {
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(true);
            }                        
        }
    }
}