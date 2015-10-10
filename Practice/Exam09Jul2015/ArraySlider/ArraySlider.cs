namespace ArraySlider
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class ArraySlider
    {
        private static void Main()
        {
            var array =
                Console.ReadLine()
                    .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(BigInteger.Parse)
                    .ToArray();

            string line = Console.ReadLine();
            int currentIndex = 0;

            while (line != "stop")
            {
                var lineArgs = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int offset = int.Parse(lineArgs[0]) % array.Length;
                string operation = lineArgs[1];
                BigInteger operand = BigInteger.Parse(lineArgs[2]);

                if (offset < 0)
                {
                    currentIndex = (currentIndex + offset + array.Length) % array.Length;
                }
                else
                {
                    currentIndex = (currentIndex + offset) % array.Length;
                }

                ProcessCommand(array, currentIndex, operation, operand);
                line = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void ProcessCommand(BigInteger[] array, int currentIndex, string operation, BigInteger operand)
        {
            switch (operation)
            {
                case "&":
                    array[currentIndex] &= operand;
                    break;
                case "|":
                    array[currentIndex] |= operand;
                    break;
                case "^":
                    array[currentIndex] ^= operand;
                    break;
                case "+":
                    array[currentIndex] += operand;
                    break;
                case "-":
                    array[currentIndex] -= operand;
                    if (array[currentIndex] < 0)
                    {
                        array[currentIndex] = 0;
                    }

                    break;
                case "*":
                    array[currentIndex] *= operand;
                    break;
                case "/":
                    array[currentIndex] /= operand;
                    break;
            }
        }
    }
}