using System;

class LongestAreaInArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] array = new string[n];

        for (int i = 0; i < array.Length; i++)
        {       
            array[i] = Console.ReadLine();
        }

        int maxSequence = 0;
        string value = null;

        for (int i = 0; i < array.Length; i++)
        {
            int countSequence = 0;
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    countSequence++;

                    if (maxSequence < countSequence)
                    {
                        maxSequence = countSequence;
                        value = array[i];
                    }
                }
                else
                {
                    break;
                }
            }
        }

        Console.WriteLine(maxSequence);
        for (int i = 0; i < maxSequence; i++)
        {
            Console.WriteLine(value);
        }
    }
}