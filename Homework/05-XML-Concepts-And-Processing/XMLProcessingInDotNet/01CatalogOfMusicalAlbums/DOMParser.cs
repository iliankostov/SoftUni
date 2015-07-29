namespace XMLProcessingInDotNet
{
    using System;
    using System.Collections.Generic;
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
                    case "3":
                        var sortedArtists = new SortedSet<string>();
                        foreach (XmlNode childNodes in rootNode.ChildNodes)
                        {
                            foreach (XmlNode childNode in childNodes)
                            {
                                if (childNode.Name == "artist")
                                {
                                    sortedArtists.Add(childNode.InnerText);
                                }
                            }
                        }

                        Console.WriteLine(string.Join(Environment.NewLine, sortedArtists));
                        break;
                    case "4":
                        var uniqueArtists = new Dictionary<string, int>();
                        foreach (XmlNode childNodes in rootNode.ChildNodes)
                        {
                            foreach (XmlNode childNode in childNodes)
                            {
                                if (childNode.Name == "artist")
                                {
                                    var key = childNode.InnerText;

                                    if (uniqueArtists.ContainsKey(key))
                                    {
                                        uniqueArtists[key]++;
                                    }
                                    else
                                    {
                                        uniqueArtists[key] = 1;
                                    }
                                }
                            }
                        }

                        foreach (var uniqueArtist in uniqueArtists)
                        {
                            Console.WriteLine(uniqueArtist.Key + " " + uniqueArtist.Value);
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
