namespace ExportRiversAsJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using EFMapping;

    public class ExportRiversAsJSON
    {
        public static void Main()
        {
            var context = new GeographyEntities();

            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                             {
                                 riverName = r.RiverName,
                                 riverLenght = r.Length,
                                 countries = r.Countries
                                     .OrderBy(c => c.CountryName)
                                     .Select(c => c.CountryName)
                             });

            var js = new JavaScriptSerializer();
            var riverJson = js.Serialize(rivers.ToList());
            
            File.WriteAllText(@"..\..\rivers.json", riverJson);
            Console.WriteLine("Export rivers.json complited!");
        }
    }
}
