namespace AJAX.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AJAX.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AjaxContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AjaxContext context)
        {
            if (!context.Towns.Any())
            {
                var towns = new List<Town>()
                    {
                        new Town() { Name = "Sofia" },
                        new Town() { Name = "Plovdiv" },
                        new Town() { Name = "Varna" },
                        new Town() { Name = "Burgas" },
                        new Town() { Name = "Ruse" }
                    };

                foreach (var town in towns)
                {
                    context.Towns.Add(town);
                }

                context.SaveChanges();
            }
        }
    }
}