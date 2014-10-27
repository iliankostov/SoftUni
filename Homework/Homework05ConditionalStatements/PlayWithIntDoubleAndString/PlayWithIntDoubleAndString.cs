using System;

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type: \n1 --> int \n2 --> double \n3 --> string");
        int choise = int.Parse(Console.ReadLine());

        switch (choise)
        {
            case 1:
                Console.WriteLine("Please enter int number: ");
                int i = int.Parse(Console.ReadLine());
                Console.WriteLine(i += 1);
                break;
            case 2:
                Console.WriteLine("Please enter double number: ");
                double d = double.Parse(Console.ReadLine());
                Console.WriteLine(d += 1);
                break;
            case 3:
                Console.WriteLine("Please enter a string: ");
                string s = Console.ReadLine();
                Console.WriteLine(s + "*");
                break;
            default:
                break;
        }
    }
}