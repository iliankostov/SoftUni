namespace AutomationTests.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class RegistrationUser
    {
        private const char SEPARATOR = '|';
        private const string PATH_TO_REPLACE = @"\bin\Debug";

        public RegistrationUser(IList<object> data)
        {
            this.FirstName = data[0].ToString();
            this.LastName = data[1].ToString();
            this.MaritalStatus = data[2].ToString().Split(SEPARATOR).Select(bool.Parse).ToList();
            this.Hobbys = data[3].ToString().Split(SEPARATOR).Select(bool.Parse).ToList();
            this.Country = data[4].ToString();
            this.BirthMonth = data[5].ToString();
            this.BirthDay = data[6].ToString();
            this.BirthYear = data[7].ToString();
            this.Phone = data[8].ToString();
            this.UserName = data[9].ToString();
            this.Email = data[10].ToString();
            this.Picture = TestContext.CurrentContext.TestDirectory.Replace(PATH_TO_REPLACE, data[11].ToString());
            this.Description = data[12].ToString();
            this.Password = data[13].ToString();
            this.ConfirmPassword = data[14].ToString();
        }

        public string BirthDay { get; private set; }
        public string BirthMonth { get; private set; }
        public string BirthYear { get; private set; }
        public string ConfirmPassword { get; private set; }
        public string Country { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public List<bool> Hobbys { get; private set; }
        public string LastName { get; private set; }
        public List<bool> MaritalStatus { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public string Picture { get; private set; }
        public string UserName { get; private set; }
    }
}
