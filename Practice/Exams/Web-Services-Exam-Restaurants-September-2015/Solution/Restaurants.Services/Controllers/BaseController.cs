namespace Restaurants.Services.Controllers
{
    using System.Web.Http;
    using Restaurants.Data;
    using Restaurants.Data.Interfaces;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new UnitOfWorkData())
        {
        }

        public BaseController(IUnitOfWorkData data)
        {
            this.Data = data;
        }

        public IUnitOfWorkData Data { get; set; }
    }
}