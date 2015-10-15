namespace Twitter.App.Controllers
{
    using Twitter.Data.Contracts;

    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }
    }
}