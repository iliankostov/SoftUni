namespace IssueTracker.Utilities
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public static class HashUtilities
    {
        public static string HashPassword(string password)
        {
            var result = SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString());

            return string.Join(string.Empty, result);
        }
    }
}