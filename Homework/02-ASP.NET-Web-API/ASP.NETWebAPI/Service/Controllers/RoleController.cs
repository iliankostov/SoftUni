namespace Service.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Service.Models.BindingModels;

    public class RoleController : BaseController
    {
        [HttpPut]
        [Route("api/users/{username}/roles")]
        [Authorize(Roles = "Admin")]
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

            var role = this.Data.Roles.Read().FirstOrDefault(r => r.Name == roleBinding.Name);
            if (role == null)
            {
                role = new IdentityRole
                           {
                               Name = roleBinding.Name
                           };

                this.Data.Roles.Create(role);
                this.Data.SaveChanges();
            }

            var userRole = role.Users.FirstOrDefault(r => r.UserId == user.Id);
            if (userRole == null)
            {
                userRole = new IdentityUserRole
                               {
                                   UserId = user.Id, 
                                   RoleId = role.Id
                               };

                role.Users.Add(userRole);
            }

            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        [Route("api/users/{username}/roles")]
        [Authorize(Roles = "Admin")]
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
                return this.BadRequest("Role not found.");
            }

            var userRole = role.Users.FirstOrDefault(r => r.UserId == user.Id);
            if (userRole == null)
            {
                return this.BadRequest("User do not have requsted role.");
            }

            role.Users.Remove(userRole);

            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}