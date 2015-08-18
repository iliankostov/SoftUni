namespace Service.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Data;

    using global::Models;

    using Service.Models;

    public class AuthorsController : ApiController
    {
        private readonly BookShopContext context = new BookShopContext();

        [HttpGet]
        [Route("api/authors/{id}")]
        public IHttpActionResult GetAuthor(int id)
        {
            var author = this.context.Authors.Find(id);
            if (author == null)
            {
                return this.NotFound();
            }

            var authorView = new AuthorViewModel();
            authorView.FirstName = author.FirstName;
            authorView.LastName = author.LastName;

            return this.Ok(authorView);
        }

        [HttpPost]
        [Route("api/authors")]
        public IHttpActionResult PostAuthor(AuthorBindingModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid input data or missing last name");
            }

            var newAuthor = new Author();
            newAuthor.FirstName = author.FirstName;
            newAuthor.LastName = author.LastName;

            this.context.Authors.Add(newAuthor);
            this.context.SaveChanges();
            return this.Ok(newAuthor.Id);
        }

        [HttpGet]
        [Route("api/authors/{id}/books")]
        public IHttpActionResult GetBooksByAuthorId(int id)
        {
            var author = this.context.Authors.Find(id);
            if (author == null)
            {
                return this.NotFound();
            }

            var books = author.Books;
            List<BookViewModel> booksView = new List<BookViewModel>();
            if (books.Any())
            {
                foreach (var book in books)
                {
                    var bookView = new BookViewModel();
                    bookView.Title = book.Title;
                    bookView.Description = book.Description;
                    bookView.EditionType = book.EditionType;
                    bookView.AgeRestriction = book.AgeRestriction;
                    bookView.Price = book.Price;
                    bookView.Copies = book.Copies;
                    bookView.AuthorName = author.FirstName + " " + author.LastName;

                    List<string> categoriesNames = book.Categories.Select(c => c.Name).ToList();
                    bookView.CategoriesNames = categoriesNames;

                    List<string> relatedBooksNames = book.RelatedBooks.Select(rb => rb.Title).ToList();
                    bookView.RelatedBooksNames = relatedBooksNames;

                    booksView.Add(bookView);
                }
            }

            return this.Ok(booksView);
        }
    }
}