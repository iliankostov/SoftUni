namespace EFCodeFirstCountriesMountainsAndPeaks
{
    using System;
    using System.Linq;

    public class EFCodeFirstCountriesMountainsAndPeaks
    {
        public static void Main()
        {
            var context = new GeographyEntities();

            var countryQueries = context.Countries.Select(
                c => new
                         {
                             CountryName = c.CountryName,
                             Mountains = c.Mountains.Select(
                                 m => new
                                          {
                                              m.Name,
                                              m.Peaks
                                          })
                         });
            foreach (var country in countryQueries)
            {
                Console.WriteLine("Country: " + country.CountryName);
                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine(" Mountain: " + mountain.Name);
                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0} ({1})", peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}
