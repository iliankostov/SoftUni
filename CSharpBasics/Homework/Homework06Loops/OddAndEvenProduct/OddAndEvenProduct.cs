using System;

class OddAndEvenProduct
{
    static void Main()
    {
        Console.Write("Please input n integers in a single line, separated by a space: ");
        string[] allLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int evenProduct = 1;
        int oddProduct = 1;
        for (int i = 0; i < allLine.Length; i++)
        {
            int number = int.Parse(allLine[i]);
            if (i % 2 == 0)
            {
                evenProduct *= number;
            }
            else
            {
                oddProduct *= number;
            }            
        }
        if (evenProduct == oddProduct)
        {
            Console.WriteLine("yes \nproduct = {0}", evenProduct);
        }
        else
        {
            Console.WriteLine("no \nodd_product = {0} \neven_product = {1}", oddProduct, evenProduct);
        }
    }
}