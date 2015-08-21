namespace Service.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData;

    using global::Models;

    using Service.Models.BindingModels;
    using Service.Models.ViewModels;

    public class CategoriesController : BaseController
    {
        [HttpGet]
        [Route("api/categories")]
        [EnableQuery]
        public IHttpActionResult GetCategories()
        {
            var categories = this.Data.Categories.Read()
                .Select(CategoryViewModel.Create);

            return this.Ok(categories);
        }

        [HttpGet]
        [Route("api/categories/{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            var category = this.Data.Categories.Read()
                .Where(c => c.Id == id)
                .Select(CategoryViewModel.Create)
                .FirstOrDefault();

            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category);
        }

        [HttpPost]
        [Route("api/categories")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult CreateCategory(CategoryBindingModel categoryBinding)
        {
            if (categoryBinding == null)
            {
                return this.BadRequest("Input is empty.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Categories.Read().Any(c => c.Name == categoryBinding.Name))
            {
                return this.BadRequest("Duplicate category name");
            }

            var category = new Category { Name = categoryBinding.Name };

            this.Data.Categories.Create(category);
            this.Data.SaveChanges();

            var categoryView = new CategoryViewModel
                                   {
                                       Id = category.Id, 
                                       Name = category.Name
                                   };

            return this.Ok(categoryView);
        }

        [HttpPut]
        [Route("api/categories/{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateCategory(int id, CategoryBindingModel categoryBinding)
        {
            var category = this.Data.Categories.Read().FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            if (categoryBinding == null)
            {
                return this.BadRequest("Input is empty.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (this.Data.Categories.Read().Any(c => c.Name == categoryBinding.Name && c.Id != id))
            {
                return this.BadRequest("Duplicate category name");
            }

            category.Name = categoryBinding.Name;

            this.Data.Categories.Update(category);
            this.Data.SaveChanges();

            var categoryView = new CategoryViewModel
                                   {
                                       Id = category.Id, 
                                       Name = category.Name
                                   };

            return this.Ok(categoryView);
        }

        [HttpDelete]
        [Route("api/categories/{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = this.Data.Categories.Read().FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            this.Data.Categories.Delete(category);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}