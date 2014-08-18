using System;

class Eclipse
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        char frame = '*';
        char glases = '/';
        char bridge = '-';
        char empty = ' ';

        string laneUpDown = empty + new String(frame, height * 2 - 2) + empty + new String(empty, height - 1) + empty + new String(frame, height * 2 - 2) + empty;
        Console.WriteLine(laneUpDown);

        for (int i = 1; i <= height - 2; i++)
        {
            if (i == height/2)
            {
                Console.WriteLine(frame + new String(glases, height * 2 - 2) + frame + 
                                  new String(bridge, height - 1) + 
                                  frame + new String(glases, height * 2 - 2) + frame);
            }
            else
            {
                Console.WriteLine(frame + new String(glases, height * 2 - 2) + frame +
                                  new String(empty, height - 1) +
                                  frame + new String(glases, height * 2 - 2) + frame);
            }
        }

        Console.WriteLine(laneUpDown);
    }
}