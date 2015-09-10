namespace News.Services.Controllers
{
    using System.Web.Http;
    using News.Repositories;
    using News.Repositories.Interfaces;

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