namespace ExportMonasteriesByCountryAsXML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    using EFMapping;

    public class ExportMonasteriesByCountryAsXML
    {
        public static void Main()
        {
            var context = new GeographyEntities();

            var monasteriesByCountry = context.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                             {
                                 CountryName = c.CountryName,
                                 Monasteries = c.Monasteries
                                     .OrderBy(m => m.Name)
                                     .Select(m => m.Name)
                             });

            var xmlMonasteries = new XElement("monasteries");

            foreach (var country in monasteriesByCountry)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));
                foreach (var monastery in country.Monasteries)
                {
                    xmlCountry.Add(new XElement("monastery", monastery));
                }

                xmlMonasteries.Add(xmlCountry);
            }

            var xmlDocument = new XDocument(xmlMonasteries);
            xmlDocument.Save(@"..\..\monasteries.xml");
            Console.WriteLine("Exporting monasteries.xml complited!");
        }
    }
}
