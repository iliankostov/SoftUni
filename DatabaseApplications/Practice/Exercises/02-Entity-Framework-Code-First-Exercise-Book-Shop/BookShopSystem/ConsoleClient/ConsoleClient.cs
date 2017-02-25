namespace ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;
    using Data.Migrations;

    public class ConsoleClient
    {
        public static void Main()
        {
            var context = new BookShopContext();
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(migrationStrategy);

            Console.Write("Do you want output for step 6 y/n: ");
            string wannaSix = Console.ReadLine();

            if (wannaSix == "y")
            {
                Console.Write("Please choise part from 1 to 5: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var bookTitles = context.Books
                            .Where(b => b.ReleaseDate.Year > 2000)
                            .Select(b => new { b.Title });
                        foreach (var bookTitle in bookTitles)
                        {
                            Console.WriteLine(bookTitle.Title);
                        }

                        break;
                    case "2":
                        var authorsByBook = context.Authors
                            .Where(a => a.Books
                                .Any(b => b.ReleaseDate.Year < 1990))
                            .Select(a => new
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName
                            });
                        foreach (var author in authorsByBook)
                        {
                            Console.WriteLine("{0} {1}", author.FirstName, author.LastName);
                        }

                        break;
                    case "3":
                        var authors = context.Authors
                            .OrderByDescending(a => a.Books.Count)
                            .Select(a => new
                            {
                                FirstName = a.FirstName,
                                LastName = a.LastName,
                                BookCount = a.Books.Count
                            });
                        foreach (var author in authors)
                        {
                            Console.WriteLine("{0} {1} - {2}", author.FirstName, author.LastName, author.BookCount);
                        }

                        break;
                    case "4":
                        var georgesBooks = context.Books
                            .Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
                            .OrderByDescending(b => b.ReleaseDate)
                            .ThenBy(b => b.Title)
                            .Select(b => new
                            {
                                Title = b.Title,
                                ReleaseDate = b.ReleaseDate,
                                Copies = b.Copies
                            });
                        foreach (var georgesBook in georgesBooks)
                        {
                            Console.WriteLine("{0} - {1} - {2}", georgesBook.Title, georgesBook.ReleaseDate, georgesBook.Copies);
                        }
                        break;
                    case "5":
                        var booksByCategories = context.Categories
                            .OrderBy(c => c.Books.Count)
                            .Select(c => new
                            {
                                Books = c.Books
                                            .OrderByDescending(b => b.ReleaseDate)
                                            .ThenBy(b => b.Title)
                                            .Take(3)
                                            .Select(b => new
                                            {
                                                BookTitle = b.Title,
                                                ReleaseDate = b.ReleaseDate
                                            }),
                                CategoryName = c.Name,
                                BookCount = c.Books.Count
                            });
                        foreach (var booksByCategory in booksByCategories)
                        {
                            Console.WriteLine("--{0}: {1} books", booksByCategory.CategoryName, booksByCategory.BookCount);
                            foreach (var book in booksByCategory.Books)
                            {
                                Console.WriteLine("{0} ({1})", book.BookTitle, book.ReleaseDate.Year);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Incorect choise.");
                        break;
                }
            }
            else
            {
                var books = context.Books
                .Take(3)
                .ToList();
                if (books.Count == 0)
                {
                    books[0].RelatedBooks.Add(books[1]);
                    books[1].RelatedBooks.Add(books[0]);
                    books[0].RelatedBooks.Add(books[2]);
                    books[2].RelatedBooks.Add(books[0]);

                    context.SaveChanges();
                }

                var booksFromQuery = context.Books
                    .Take(3)
                    .Select(b => new
                                 {
                                     Title = b.Title,
                                     RelatedBooks = b.RelatedBooks.Select(rb => new { rb.Title })
                                 });

                foreach (var book in booksFromQuery)
                {
                    Console.WriteLine("--{0}", book.Title);
                    foreach (var relatedBook in book.RelatedBooks)
                    {
                        Console.WriteLine(relatedBook.Title);
                    }
                }
            }
        }
    }
}
