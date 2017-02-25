namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            var categoriesCount = context.Categories.Count();

            if (categoriesCount == 0)
            {
                using (var reader = new StreamReader("../../../../categories.txt"))
                {
                    var line = reader.ReadLine();
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var categoryName = line;

                        context.Categories.Add(new Category()
                        {
                            Name = categoryName,
                        });

                        line = reader.ReadLine();
                    }

                    context.SaveChanges();
                }
            }

            var authorsCount = context.Authors.Count();

            if (authorsCount == 0)
            {
                using (var reader = new StreamReader("../../../../authors.txt"))
                {
                    var line = reader.ReadLine();
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(new[] { ' ' }, 2);
                        var firstName = data[0];
                        var lastName = data[1];

                        context.Authors.Add(new Author()
                                                {
                                                    FirstName = firstName, LastName = lastName
                                                });

                        line = reader.ReadLine();
                    }
                }

                context.SaveChanges();
            }

            var authors = context.Authors.ToList();
            var categories = context.Categories.ToList();
            var random = new Random();
            var booksCount = context.Books.Count();

            if (booksCount == 0)
            {
                using (var reader = new StreamReader("../../../../books.txt"))
                {
                    var line = reader.ReadLine();
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(new[] { ' ' }, 6);
                        var authorIndex = random.Next(0, authors.Count);
                        var author = authors[authorIndex];
                        var edition = (EditionType)int.Parse(data[0]);
                        var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                        var copies = int.Parse(data[2]);
                        var price = decimal.Parse(data[3]);
                        var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                        var title = data[5];
                        var categoryIndex = random.Next(0, categories.Count);
                        var category = categories[categoryIndex];

                        var newBook = new Book()
                                          {
                                              Author = author,
                                              EditionType = edition,
                                              ReleaseDate = releaseDate,
                                              Copies = copies,
                                              Price = price,
                                              AgeRestriction = ageRestriction,
                                              Title = title
                                          };
                        newBook.Categories.Add(category);

                        context.Books.Add(newBook);

                        line = reader.ReadLine();
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
