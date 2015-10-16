namespace Twitter.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class EditProfileBindingModel
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public HttpPostedFileBase ProfileImage { get; set; }
    }
}