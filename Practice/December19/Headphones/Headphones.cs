using System;
class Headphones
{
    static void Main()
    {
        int diameter = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char dash = '-';
        

        
        int outsideDash = ((diameter * 2 + 1) - (diameter + 2)) / 2;
        int insideDash = diameter;
        int increaseHeadphones = 1;
        int decreaseHeadphones = diameter;

        for (int i = 0; i < diameter*2; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(new String(dash, outsideDash) + 
                    new String(asterisk, diameter + 2) + new String(dash, outsideDash));
            }
            if (i < diameter - 1)
            {
                Console.WriteLine(new String(dash, outsideDash) + asterisk +
                    new String(dash, insideDash) + asterisk + new String(dash, outsideDash));
            }
            if (i == diameter)
            {
                Console.WriteLine(new String(dash, outsideDash) + asterisk +
                    new String(dash, insideDash) + asterisk + new String(dash, outsideDash));
                outsideDash -= 1;
                insideDash -= 2;
                increaseHeadphones += 2;
            }
            if (i > diameter && i < (diameter + diameter / 2))
            {
                Console.WriteLine(new String(dash, outsideDash) + new String(asterisk, increaseHeadphones) +
                    new String(dash, insideDash) + new String(asterisk, increaseHeadphones) + new String(dash, outsideDash));
                outsideDash -= 1;
                insideDash -= 2;
                increaseHeadphones += 2;
            }
            if (i == (diameter + diameter / 2) + 1)
            {
                Console.WriteLine(new String(asterisk, diameter) + dash + new String(asterisk, diameter));
                decreaseHeadphones -= 2;
                insideDash += 2;
                outsideDash += 1;
            }
            if (i > (diameter + diameter / 2) && i < diameter * 2)
            {
                Console.WriteLine(new String(dash, outsideDash) + new String(asterisk, decreaseHeadphones) +
                    new String(dash, insideDash) + new String(asterisk, decreaseHeadphones) + new String(dash, outsideDash));
                decreaseHeadphones -= 2;
                insideDash += 2;
                outsideDash += 1;
            }
        }
    }
}