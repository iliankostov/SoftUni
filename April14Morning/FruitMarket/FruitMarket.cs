using System;

class FruitMarket
{
    static void Main()
    {
        string day = Console.ReadLine();
        int quantitiesProductOne = int.Parse(Console.ReadLine());
        string productOne = Console.ReadLine();
        int quantitiesProducTwo = int.Parse(Console.ReadLine());
        string productTwo = Console.ReadLine();
        int quantitiesProductThree = int.Parse(Console.ReadLine());
        string productThree = Console.ReadLine();

        decimal	banana = 1.80m;
        decimal	cucumber = 2.75m;
        decimal	tomato = 3.20m;
        decimal	orange = 1.60m;
        decimal apple = 0.86m;

        decimal total = 0.00m;

        switch (day)
        {
            case "Friday":
                banana *= 0.9m;
                cucumber *= 0.9m;
                tomato*= 0.9m;
                orange*= 0.9m;
                apple *= 0.9m;
                break;
            case "Sunday":
                banana *= 0.95m;
                cucumber *= 0.95m;
                tomato *= 0.95m;
                orange *= 0.95m;
                apple *= 0.95m;
                break;
            case "Tuesday":
                banana *= 0.8m;               
                orange *= 0.8m;
                apple *= 0.8m;
                break;
            case "Wednesday":
                cucumber *= 0.9m;
                tomato *= 0.9m;
                break;
            case "Thursday":
                banana *= 0.7m;
                break;
            default:
                break;
        }
        switch (productOne)
        {
            case "banana":
                total += quantitiesProductOne * banana;
                break;
            case "cucumber":
                total += quantitiesProductOne * cucumber;
                break;
            case "tomato":
                total += quantitiesProductOne * tomato;
                break;
            case "orange":
                total += quantitiesProductOne * orange;
                break;
            case "apple":
                total += quantitiesProductOne * apple;
                break;
            default:
                break;
        }

        switch (productTwo)
        {
            case "banana":
                total += quantitiesProducTwo * banana;
                break;
            case "cucumber":
                total += quantitiesProducTwo * cucumber;
                break;
            case "tomato":
                total += quantitiesProducTwo * tomato;
                break;
            case "orange":
                total += quantitiesProducTwo * orange;
                break;
            case "apple":
                total += quantitiesProducTwo * apple;
                break;
            default:
                break;
        }

        switch (productThree)
        {
            case "banana":
                total += quantitiesProductThree * banana;
                break;
            case "cucumber":
                total += quantitiesProductThree * cucumber;
                break;
            case "tomato":
                total += quantitiesProductThree * tomato;
                break;
            case "orange":
                total += quantitiesProductThree * orange;
                break;
            case "apple":
                total += quantitiesProductThree * apple;
                break;
            default:
                break;
        }

        Console.WriteLine("{0:0.00}", total);

    }
}