namespace Service.Controllers
{
    using System.Web.Http;

    using Data;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new BookShopData())
        {
        }

        public BaseController(IBookShopData data)
        {
            this.Data = data;
        }

        public IBookShopData Data { get; set; }
    }
}