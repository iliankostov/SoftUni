using System;

class PrintADeckOf52Cards
{
    static void Main()
    {
        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };
        int[] suits = { 5, 4, 3, 6 };
        foreach (string card in cards)
        {            
            foreach (int suit in suits)
            {
                switch (suit)
                {
                    case 5:
                        Console.Write("{0}{1} ", card, (char)suit);
                        break;
                    case 4:
                        Console.Write("{0}{1} ", card, (char)suit);
                        break;
                    case 3:
                        Console.Write("{0}{1} ", card, (char)suit);
                        break;
                    case 6:
                        Console.WriteLine("{0}{1} ", card, (char)suit);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
               
            }
        }       
    }
}