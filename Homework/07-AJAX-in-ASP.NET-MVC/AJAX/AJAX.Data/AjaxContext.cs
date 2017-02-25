namespace AJAX.Data
{
    using System.Data.Entity;

    using AJAX.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class AjaxContext : IdentityDbContext<User>
    {
        public AjaxContext()
            : base("name=AjaxContext")
        {
        }

        public IDbSet<Town> Towns { get; set; }

        public static AjaxContext Create()
        {
            return new AjaxContext();
        }
    }
}