namespace Snippy.Web.Controllers
{
    using System.Web.Mvc;

    using Snippy.Data;
    using Snippy.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new SnippyData())
        {
        }

        public BaseController(ISnippyData data)
        {
            this.Data = data;
        }

        public ISnippyData Data { get; set; }
    }
}