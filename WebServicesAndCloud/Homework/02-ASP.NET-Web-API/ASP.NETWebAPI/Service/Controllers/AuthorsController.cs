namespace Service.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData;

    using global::Models;

    using Service.Models.BindingModels;
    using Service.Models.ViewModels;

    public class AuthorsController : BaseController
    {
        [HttpGet]
        [Route("api/authors/{id}")]
        public IHttpActionResult GetAuthor(int id)
        {
            var authorView = this.Data.Authors.Read()
                .Where(a => a.Id == id)
                .Select(AuthorViewModel.Create)
                .FirstOrDefault();

            if (authorView == null)
            {
                return this.NotFound();
            }

            return this.Ok(authorView);
        }

        [HttpPost]
        [Route("api/authors")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostAuthor(AuthorBindingModel authorBinding)
        {
            if (authorBinding == null)
            {
                return this.BadRequest("Input is empty.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var author = new Author
                             {
                                 FirstName = authorBinding.FirstName, 
                                 LastName = authorBinding.LastName
                             };

            this.Data.Authors.Create(author);
            this.Data.SaveChanges();

            var authorView = new AuthorViewModel
                                 {
                                     FirstName = author.FirstName, 
                                     LastName = author.LastName
                                 };

            return this.Ok(authorView);
        }

        [HttpGet]
        [Route("api/authors/{id}/books")]
        [EnableQuery]
        public IHttpActionResult GetBooksByAuthorId(int id)
        {
            var author = this.Data.Authors.Read().FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return this.NotFound();
            }

            var booksView = this.Data.Books.Read()
                .Where(b => b.AuthorId == id)
                .Select(BookViewModel.Create);

            return this.Ok(booksView);
        }
    }
}