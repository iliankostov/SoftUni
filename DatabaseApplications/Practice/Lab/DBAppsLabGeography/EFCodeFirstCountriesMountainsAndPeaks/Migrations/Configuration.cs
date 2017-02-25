namespace EFCodeFirstCountriesMountainsAndPeaks.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using global::EFCodeFirstCountriesMountainsAndPeaks.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GeographyEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GeographyEntities context)
        {
            if (!context.Countries.Any() && !context.Mountains.Any() && !context.Peaks.Any())
            {
                var bulgaria = new Country { CountryCode = "BG", CountryName = "Bulgaria" };
                context.Countries.Add(bulgaria);
                var germany = new Country { CountryCode = "DE", CountryName = "Germany" };
                context.Countries.Add(germany);

                var rila = new Mountain { Name = "Rila", Countries = { bulgaria } };
                context.Mountains.Add(rila);
                var pirin = new Mountain { Name = "Pirin", Countries = { bulgaria } };
                context.Mountains.Add(pirin);
                var rhodopes = new Mountain { Name = "Rhodopes", Countries = { bulgaria } };
                context.Mountains.Add(rhodopes);

                var musala = new Peak { Name = "Musala", Elevation = 2925, Mountain = rila };
                context.Peaks.Add(musala);
                var malyovitsa = new Peak { Name = "Malyovitsa", Elevation = 2729, Mountain = rila };
                context.Peaks.Add(malyovitsa);
                var vihren = new Peak { Name = "Vihren", Elevation = 2914, Mountain = pirin };
                context.Peaks.Add(vihren);

                context.SaveChanges();
            }
        }
    }
}
