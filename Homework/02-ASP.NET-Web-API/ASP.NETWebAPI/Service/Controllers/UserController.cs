namespace Service.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Service.Models.BindingModels;

    public class UserController : BaseController
    {
        [HttpPut]
        [Route("api/users/{username}/roles")]
        public IHttpActionResult AddRole(string username, RoleBindingModel roleBinding)
        {
            var user = this.Data.Users.Read().FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return this.NotFound();
            }

            if (roleBinding == null)
            {
                return this.BadRequest("Role is null.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var role = new IdentityRole
                           {
                               Name = roleBinding.Name
                           };

            if (!this.Data.Roles.Read().Any(r => r.Name == roleBinding.Name))
            {
                this.Data.Roles.Create(role);
            }

            var userRole = new IdentityUserRole
                               {
                                   UserId = user.Id
                               };

            this.Data.SaveChanges();

            role.Users.Add(userRole);
            return this.Ok();
        }

        [HttpDelete]
        [Route("api/users/{username}/roles")]
        public IHttpActionResult RemoveRole(string username, RoleBindingModel roleBinding)
        {
            var user = this.Data.Users.Read().FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return this.NotFound();
            }

            var role = this.Data.Roles.Read().FirstOrDefault(r => r.Name == roleBinding.Name);
            if (role == null)
            {
                return this.BadRequest("The user do not have requested role");
            }

            this.Data.Roles.Delete(role);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}