namespace Caching.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Caching.App.Infrastructure;
    using Caching.App.Models.ViewModels;
    using Caching.Data.UnitOfWork;

    using PagedList;

    public class UsersController : BaseController
    {
        public UsersController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            if (this.HttpContext.Cache["users"] == null)
            {
                var users = this.ApplicationData.Users.All()
                            .OrderBy(u => u.UserName)
                            .ProjectTo<UserViewModel>()
                            .ToPagedList(pageNumber: page ?? 1, pageSize: AppConfig.PageSize);

                this.HttpContext.Cache.Insert(
                    "users", 
                    users, 
                    null, 
                    System.Web.Caching.Cache.NoAbsoluteExpiration, 
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }

            return this.View(this.HttpContext.Cache["users"]);
        }
    }
}