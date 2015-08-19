namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using Data.Source;

    using Models;
    using Models.Enumerations;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "BookShop";
        }

        protected override void Seed(BookShopContext context)
        {
            if (!context.Categories.Any())
            {
                // TODO: Why the file path change to C:\Source\categories.txt ?
                string categoriesFileSource = @"../../Source/categories.txt";
                string categoriesClassSource = Source.GetCategories();

                using (var reader = new StringReader(categoriesClassSource))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var categoryName = line;

                        context.Categories.Add(new Category
                                                   {
                                                       Name = categoryName
                                                   });

                        line = reader.ReadLine();
                    }

                    context.SaveChanges();
                }
            }

            if (!context.Authors.Any())
            {
                // TODO: Why the file path change to C:\Source\authors.txt ?
                string authorsFileSource = @"../../Source/authors.txt";
                string authorsClassSource = Source.GetAuthors();

                using (var reader = new StringReader(authorsClassSource))
                {
                    var line = reader.ReadLine();
                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(new[] { ' ' }, 2);
                        var firstName = data[0];
                        var lastName = data[1];

                        context.Authors.Add(new Author
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

            if (!context.Books.Any())
            {
                // TODO: Why the file path change to C:\Source\books.txt ?
                string booksFileSource = @"../../Source/books.txt";
                string booksClassSource = Source.GetBooks();

                using (var reader = new StringReader(booksClassSource))
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

                        var newBook = new Book
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