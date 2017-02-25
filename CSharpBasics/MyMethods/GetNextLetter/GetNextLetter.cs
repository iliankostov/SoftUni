using System;

class GetNextLetter
{
    static void Main()
    {
        char letter = char.Parse(Console.ReadLine());
        for (int i = 0; i < 30; i++)
        {           
            letter = GetNextLetters(letter);
            Console.WriteLine(letter);
        }
    }

    static char GetNextLetters(char letter)
    {
        letter++;
        if (letter > 'Z')
        {
            letter = 'A';
        }
        return letter;
    }
}