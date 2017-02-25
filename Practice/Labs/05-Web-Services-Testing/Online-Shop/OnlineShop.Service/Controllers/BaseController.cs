namespace OnlineShop.Service.Controllers
{
    using System.Web.Http;
    using OnlineShop.Data;
    using OnlineShop.Service.Infrastructure;

    public class BaseController : ApiController
    {
        public BaseController()
            : this(new OnlineShopData(new OnlineShopContext()), new AspNetUserIdProvider())
        {
        }

        public BaseController(IOnlineShopData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        public IOnlineShopData Data { get; set; }

        public IUserIdProvider UserIdProvider { get; set; }
    }
}