using System;

class BookOrders
{
    static void Main()
    {
        int orders = int.Parse(Console.ReadLine());        
        double discount = 0;
        int numbeOfBook = 0;
        double totalPrice = 0;

        for (int i = 0; i < orders; i++)
        {           
            int packets = int.Parse(Console.ReadLine());
            int bookPerPacket = int.Parse(Console.ReadLine());
            double priceOfBook = double.Parse(Console.ReadLine());

            if (packets >= 10 && packets <= 19)
            {
                discount = 0.05;
            }
            else if (packets >= 20 && packets <= 29)
            {
                discount = 0.06;
            }
            else if (packets >= 30 && packets <= 39)
            {
                discount = 0.07;
            }
            else if (packets >= 40 && packets <= 49)
            {
                discount = 0.08;
            }
            else if (packets >= 50 && packets <= 59)
            {
                discount = 0.09;
            }
            else if (packets >= 60 && packets <= 69)
            {
                discount = 0.10;
            }
            else if (packets >= 70 && packets <= 79)
            {
                discount = 0.11;
            }
            else if (packets >= 80 && packets <= 89)
            {
                discount = 0.12;
            }
            else if (packets >= 90 && packets <= 99)
            {
                discount = 0.13;
            }
            else if (packets >= 100 && packets <= 109)
            {
                discount = 0.14;
            }
            else if (packets >= 110)
            {
                discount = 0.15;
            }
            else
            {
                discount = 0;
            }
            priceOfBook = priceOfBook * (1 - discount);
            numbeOfBook += packets * bookPerPacket;
            totalPrice += packets * bookPerPacket * priceOfBook;
        }
        Console.WriteLine(numbeOfBook);
        Console.WriteLine("{0:0.00}", totalPrice);       
    }
}