namespace EFCodeFirstCountriesMountainsAndPeaks
{
    using System.Data.Entity;

    using global::EFCodeFirstCountriesMountainsAndPeaks.Migrations;
    using global::EFCodeFirstCountriesMountainsAndPeaks.Models;

    public class GeographyEntities : DbContext
    {
        public GeographyEntities()
            : base("GeographyEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<GeographyEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Mountain> Mountains { get; set; }

        public virtual DbSet<Peak> Peaks { get; set; }
    }
}