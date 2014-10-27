using System;

class Illuminati
{
    static void Main()
    {
        string input = Console.ReadLine();
        int numberOfVowels = 0;
        int sum = 0;
        
        foreach (char charToCheck in input)
        {
            switch (charToCheck)
            {
                case 'A':
                    numberOfVowels++;
                    sum+=65;
                    break;
                case 'a':
                    numberOfVowels++;
                    sum+=65;
                    break;
                case 'E':
                    numberOfVowels++;
                    sum+=69;
                    break;
                case 'e':
                    numberOfVowels++;
                    sum+=69;
                    break;
                case 'I':
                    numberOfVowels++;
                    sum+=73;
                    break;
                case 'i':
                    numberOfVowels++;
                    sum+=73;
                    break;
                case 'O':
                    numberOfVowels++;
                    sum+=79;
                    break;
                case 'o':
                    numberOfVowels++;
                    sum+=79;
                    break;
                case 'U':
                    numberOfVowels++;
                    sum+=85;
                    break;
                case 'u':
                    numberOfVowels++;
                    sum+=85;
                    break;
                default:
                    break;
            }            
        }

        Console.WriteLine(numberOfVowels);
        Console.WriteLine(sum);
        
    }
}