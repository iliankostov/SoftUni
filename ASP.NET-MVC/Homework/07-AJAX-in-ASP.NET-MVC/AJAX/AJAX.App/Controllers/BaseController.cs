namespace AJAX.App.Controllers
{
    using System.Web.Mvc;

    using AJAX.Data;
    using AJAX.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new AjaxData())
        {
        }

        public BaseController(IAjaxData data)
        {
            this.Data = data;
        }

        protected IAjaxData Data { get; }
    }
}