namespace Chepelare.Identity
{
    using Chepelare.Models;
    using Chepelare.Models.Enumerations;

    public static class UserExtensions
    {
        public static bool IsInRole(this User user, Roles role)
        {
            return user.Role == role;
        }
    }
}