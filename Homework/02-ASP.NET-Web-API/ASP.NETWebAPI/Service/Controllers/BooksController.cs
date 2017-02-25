namespace Service.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData;

    using global::Models;

    using Service.Models.BindingModels;
    using Service.Models.ViewModels;

    public class BooksController : BaseController
    {
        [HttpGet]
        [Route("api/books/{id}")]
        public IHttpActionResult GetBookById(int id)
        {
            var bookView = this.Data.Books.Read()
                .Where(b => b.Id == id)
                .Select(BookViewModel.Create)
                .FirstOrDefault();

            if (bookView == null)
            {
                return this.NotFound();
            }

            return this.Ok(bookView);
        }

        [HttpGet]
        [Route("api/books")]
        [EnableQuery]
        public IHttpActionResult SearchBooks(string search)
        {
            var booksView = this.Data.Books.Read()
                .Where(b => b.Title.Contains(search))
                .OrderBy(b => b.Title)
                .Select(b => new
                                 {
                                     title = b.Title, 
                                     id = b.Id
                                 })
                .Take(10);

            return this.Ok(booksView);
        }

        [HttpPost]
        [Route("api/books")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult AddBook(BookBindingModel bookBinding)
        {
            if (bookBinding == null)
            {
                return this.BadRequest("Input is empty.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = new Book
                           {
                               Title = bookBinding.Title, 
                               Description = bookBinding.Description, 
                               EditionType = bookBinding.EditionType, 
                               AgeRestriction = bookBinding.AgeRestriction, 
                               Price = bookBinding.Price, 
                               Copies = bookBinding.Copies, 
                               ReleaseDate = bookBinding.ReleaseDate
                           };

            if (bookBinding.AuthorId != null)
            {
                book.AuthorId = bookBinding.AuthorId;
            }

            if (!string.IsNullOrEmpty(bookBinding.Categories))
            {
                var categories = this.Data.Categories.Read().ToList();

                var categoriesString = bookBinding.Categories.Split(' ');

                foreach (var categoryString in categoriesString)
                {
                    var category = categories.FirstOrDefault(c => c.Name == categoryString);

                    if (category != null)
                    {
                        book.Categories.Add(category);
                    }
                }
            }

            this.Data.Books.Create(book);
            this.Data.SaveChanges();

            var bookView = this.Data.Books.Read()
                .Where(b => b.Id == book.Id)
                .Select(BookViewModel.Create)
                .FirstOrDefault();

            return this.Ok(bookView);
        }

        [HttpPut]
        [Route("api/books/{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateBookById(int id, BookBindingModel bookBinding)
        {
            var book = this.Data.Books.Read().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            if (bookBinding == null)
            {
                return this.BadRequest("Input is empty.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            book.Title = bookBinding.Title;
            book.Description = bookBinding.Description;
            book.EditionType = bookBinding.EditionType;
            book.AgeRestriction = bookBinding.AgeRestriction;
            book.Price = bookBinding.Price;
            book.Copies = bookBinding.Copies;
            book.ReleaseDate = bookBinding.ReleaseDate;
            book.AuthorId = bookBinding.AuthorId;

            this.Data.SaveChanges();

            var bookView = this.Data.Books.Read()
                .Where(b => b.Id == book.Id)
                .Select(BookViewModel.Create)
                .FirstOrDefault();

            return this.Ok(bookView);
        }

        [HttpDelete]
        [Route("api/books/{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteBookById(int id)
        {
            var book = this.Data.Books.Read().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            this.Data.Books.Delete(book);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}