using System;

class DrawFigure
{
    static void Main()
    {
        int heigth = int.Parse(Console.ReadLine());

        int dots = 0;
        int asterisk = heigth;

        string topDownLine = new String('*', heigth);
        string middleLane = new String('.', (heigth -1) / 2) + '*' + new String('.', (heigth -1) / 2);

        for (int i = 1; i <= heigth; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(topDownLine);
                
            }
            else if (i < (heigth + 1) / 2)
            {
                asterisk -= 2;
                dots++;
                Console.WriteLine(new String('.', dots) + new String('*', asterisk) + new String('.', dots));              
            }
            else if (i == (heigth + 1) / 2)
            {
                Console.WriteLine(middleLane);
            }
            else if (i > (heigth + 1) / 2 && i < heigth)
            {
                Console.WriteLine(new String('.', dots) + new String('*', asterisk) + new String('.', dots));
                dots--;
                asterisk += 2;
            }
            else
            {
                Console.WriteLine(topDownLine);
            }                      
        }
    }
}