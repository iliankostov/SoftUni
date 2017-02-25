namespace NineDigitsGenerator
{
    using System;
    using System.IO;

    public class NineDigitsGenerator
    {
        public static void Main()
        {
            string input = string.Empty;
            while (true)
            {
                try
                {
                    Console.Write("Do you have 11 GB free space? y/n: ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        break;
                    }
                    else if (input.ToLower() == "n")
                    {
                        throw new ArgumentException("Please free more space!");
                    }
                    else
                    {
                        throw new NullReferenceException("Please try again.");
                    }
                }
                catch (NullReferenceException nrf)
                {
                    Console.Error.WriteLine(nrf.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.Error.WriteLine(ae.Message);
                }
            }

            Console.WriteLine("Generaring ... NineDigitsDictationary.txt ... Please wait!");
            TextWriter tw = new StreamWriter("NineDigitsDictationary.txt");
            for (int i = 0; i <= 999999999; i++)
            {
                tw.WriteLine(i.ToString().PadLeft(9, '0'));
            }

            tw.Close();
            Console.WriteLine("Done!");
        }
    }
}