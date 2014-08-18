using System;

class TheExplorer
{
    static void Main()  
    {
        int width = int.Parse(Console.ReadLine());
        char asterisk = '*';
        char dash = '-';
        int outDash = (width - 1) / 2;
        int inDash = 1;
        string topDownLane = new String(dash, outDash) + asterisk + new String(dash, outDash);       
        outDash -= 1;

        for (int i = 0; i < width; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(topDownLane);
            }
            else if (i < (width-1) / 2)
            {
                Console.WriteLine(new String(dash, outDash) + asterisk + new String(dash, inDash) + asterisk + new String(dash, outDash));
                outDash--;
                inDash += 2;
            }
            else if (i == (width - 1) / 2)
            {
                Console.WriteLine(asterisk + new String(dash, width - 2) + asterisk);
            }
            else if (i > ((width - 1) / 2) && i < width - 1)
            {
                outDash++;
                inDash -= 2;
                Console.WriteLine(new String(dash, outDash) + asterisk + new String(dash, inDash) + asterisk + new String(dash, outDash));
            }
            else
            {
                Console.WriteLine(topDownLane);
            }

        }
    }
}