namespace AutomationTests.Data
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using NUnit.Framework;
    using System.Linq;

    public class DataReader
    {
        private const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;IMEX=1;ImportMixedTypes=Text\"";
        private const string PATH_TO_REPLACE = @"\bin\Debug";
        private const string PATH_SUFFIX = @"\Data\Data.xls";
        private const string QUERY = "select {0} from [{1}$]";

        public static IList<object> RegistrationUser(string test)
        {
            return Read(test, "Users");
        }

        public static IList<object> Read(string test, string model)
        {
            var dataTable = new DataTable();
            var dataPath = TestContext.CurrentContext.TestDirectory.Replace(PATH_TO_REPLACE, PATH_SUFFIX);

            using (var connection = new OleDbConnection(string.Format(CONNECTION_STRING, dataPath)))
            {
                var adapter = new OleDbDataAdapter(string.Format(QUERY, test, model), connection);
                adapter.Fill(dataTable);
            }

            return dataTable.Rows.Cast<DataRow>().Select(r => r.ItemArray[0]).ToList();
        }
    }
}
