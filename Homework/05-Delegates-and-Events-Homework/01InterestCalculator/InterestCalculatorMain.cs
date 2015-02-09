namespace InterestCalculator
{
    using System;

    internal class InterestCalculatorMain
    {
        public static decimal GetSimpleInterest(decimal moneySum, double interest, int years)
        {
            decimal simpleInterest = moneySum * (decimal)(1 + (interest * years / 100));
            return simpleInterest;
        }

        public static decimal GetCompoundInterest(decimal moneySum, double interest, int years)
        {
            decimal compoundInterest = moneySum * (decimal)Math.Pow(1 + (interest / 12 / 100), years * 12);
            return compoundInterest;
        }

        internal static void Main()
        {
            InterestCalculator interestOne = new InterestCalculator(500, 5.6, 10, GetCompoundInterest);
            Console.WriteLine(interestOne);

            InterestCalculator interestTwo = new InterestCalculator(2500, 7.2, 15, GetSimpleInterest);
            Console.WriteLine(interestTwo);
        }
    }
}