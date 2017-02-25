namespace ImportRiversFromXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using EFMapping;

    public class ImportRiversFromXML
    {
        public static void Main()
        {
            var context = new GeographyEntities();

            var xmlDocument = XDocument.Load(@"..\..\rivers.xml");

            var riverNodes = xmlDocument.XPathSelectElements("/rivers/river");

            foreach (XElement riverNode in riverNodes)
            {
                try
                {
                    if (riverNode.Element("name") == null)
                    {
                        throw new Exception("Name cannot be null.");
                    }

                    if (riverNode.Element("length") == null)
                    {
                        throw new Exception("Lenght cannot be null.");
                    }

                    if (riverNode.Element("outflow") == null)
                    {
                        throw new Exception("Outflow cannot be null.");
                    }

                    string riverName = riverNode.Element("name").Value;
                    int riverLenght = int.Parse(riverNode.Element("length").Value);
                    string riverOutflow = riverNode.Element("outflow").Value;

                    int? drainageArea = null;
                    if (riverNode.Element("drainage-area") != null)
                    {
                        drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                    }

                    int? averageDischarge  = null;
                    if (riverNode.Element("average-discharge") != null)
                    {
                        averageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                    }

                    var river = new River()
                                    {
                                        RiverName = riverName,
                                        Length = riverLenght,
                                        Outflow = riverOutflow,
                                        DrainageArea = drainageArea,
                                        AverageDischarge = averageDischarge
                                    };


                    IEnumerable<XElement> countryNodes = null;
                    if (riverNode.Element("countries") != null)
                    {
                        countryNodes = riverNode.XPathSelectElements("/countries/country");
                        var countryNames = countryNodes.Select(c => c.Value);
                        foreach (var countryName in countryNames)
                        {
                            var country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                            river.Countries.Add(country);
                        }

                    }

                    context.Rivers.Add(river);
                    context.SaveChanges();
                    Console.WriteLine("XML imported!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
