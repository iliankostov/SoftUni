namespace XMLProcessingInDotNet
{
    using System;
    using System.Xml;

    public class DOMParser
    {
        public static void Main()
        {
            Console.Write("Please choise number of problem in interval [2..10]: ");
            var input = Console.ReadLine();
            XmlDocument catalog = new XmlDocument();
            catalog.Load(@"..\..\catalog.xml");
            XmlNode rootNode = catalog.DocumentElement;
            if (rootNode != null)
            {
                switch (input)
                {
                    case "2":
                        foreach (XmlNode childNodes in rootNode.ChildNodes)
                        {
                            foreach (XmlNode childNode in childNodes)
                            {
                                if (childNode.Name == "name")
                                {
                                    Console.WriteLine(childNode.InnerText);
                                }
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("Wrong input.");
                        break;
                }
            }
        }
    }
}
