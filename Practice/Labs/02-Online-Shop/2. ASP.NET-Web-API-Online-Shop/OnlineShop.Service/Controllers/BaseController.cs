namespace OnlineShop.Service.Controllers
{
    using System.Web.Http;
    using OnlineShop.Data;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new OnlineShopContext())
        {
        }

        public BaseController(OnlineShopContext data)
        {
            this.Data = data;
        }

        public OnlineShopContext Data { get; set; }
    }
}