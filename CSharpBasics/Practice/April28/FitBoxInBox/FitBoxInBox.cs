using System;

class FitBoxInBox
{
    static void Main()
    {
        int widthFirstBox = int.Parse(Console.ReadLine());
        int heightFirstBox = int.Parse(Console.ReadLine());
        int depthFirstBox = int.Parse(Console.ReadLine());
        int widthSecondBox = int.Parse(Console.ReadLine());
        int heightSecondBox = int.Parse(Console.ReadLine());
        int depthSecondBox = int.Parse(Console.ReadLine());

        CheckBoxes(widthFirstBox, heightFirstBox, depthFirstBox, widthSecondBox, heightSecondBox, depthSecondBox);
        CheckBoxes(widthFirstBox, heightFirstBox, depthFirstBox, widthSecondBox, depthSecondBox, heightSecondBox);
        CheckBoxes(widthFirstBox, heightFirstBox, depthFirstBox, heightSecondBox, widthSecondBox, depthSecondBox);
        CheckBoxes(widthFirstBox, heightFirstBox, depthFirstBox, heightSecondBox, depthSecondBox, widthSecondBox);
        CheckBoxes(widthFirstBox, heightFirstBox, depthFirstBox, depthSecondBox, widthSecondBox, heightSecondBox);
        CheckBoxes(widthFirstBox, heightFirstBox, depthFirstBox, depthSecondBox, heightSecondBox, widthSecondBox);

        CheckBoxes(widthSecondBox, heightSecondBox, depthSecondBox, widthFirstBox, heightFirstBox, depthFirstBox);
        CheckBoxes(widthSecondBox, heightSecondBox, depthSecondBox, widthFirstBox, depthFirstBox, heightFirstBox);
        CheckBoxes(widthSecondBox, heightSecondBox, depthSecondBox, heightFirstBox, widthFirstBox, depthFirstBox);
        CheckBoxes(widthSecondBox, heightSecondBox, depthSecondBox, heightFirstBox, depthFirstBox, widthFirstBox);
        CheckBoxes(widthSecondBox, heightSecondBox, depthSecondBox, depthFirstBox, widthFirstBox, heightFirstBox);
        CheckBoxes(widthSecondBox, heightSecondBox, depthSecondBox, depthFirstBox, heightFirstBox, widthFirstBox);

    }
    private static void CheckBoxes(
        int firstWidth, int firstHeight, int firstDepth,
        int secondWidth, int secondHeight, int secondDepth)
    {
        if (firstWidth < secondWidth && firstHeight < secondHeight && firstDepth < secondDepth)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})",
                firstWidth, firstHeight, firstDepth, secondWidth, secondHeight, secondDepth);
        }
    }
}