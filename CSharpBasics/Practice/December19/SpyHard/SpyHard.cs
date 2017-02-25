using System;

class SpyHard
{
    static void Main()
    {
        int key = int.Parse(Console.ReadLine());
        string message = Console.ReadLine();

        string output = key + "" + message.Length;
        int sum = 0;

        char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string convertedNumber = "";

        for (int a = 0; a < message.Length; a++)
        {
            if (((int)message[a] >= 97 && (int)message[a] <= 122) || ((int)message[a] >= 65 && (int)message[a] <= 90))
            {
                char ch = Char.ToLower(message[a]);

                int chNum = (int)ch - 96;
                sum += chNum;
            }
            else
            {
                int chNum = (int)message[a];
                sum += chNum;
            }
        }

        while (sum > 0)
        {
            convertedNumber = chars[sum % key] + convertedNumber;
            sum = sum / key;
        }

        Console.WriteLine(output + convertedNumber);
    }

}