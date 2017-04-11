namespace AutomationTests.Data
{
    using System.Data.OleDb;
    using System.Linq;
    using System.Reflection;
    using Models;
    using Dapper;
    using Utilities;

    public class DataReader
    {
        private const string CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;";
        private const string EXCEL_DATA_PATH = @"..\..\Data\Data.xlsx";
        private const string QUERY_TEMPLATE = "select * from [{0}$] where TestName = '{1}'";

        public static RegistrationUser User(string test)
        {
            var absolutePath = EXCEL_DATA_PATH.ToAbsolutePath();
            var sheet = MethodBase.GetCurrentMethod().Name;
            var query = string.Format(QUERY_TEMPLATE, sheet, test);
            var registrationUser = new RegistrationUser();

            using (var connection = new OleDbConnection(string.Format(CONNECTION_STRING, absolutePath)))
            {
                registrationUser = connection.Query<RegistrationUser>(query).FirstOrDefault();
            }

            return registrationUser;
        }
    }
}
