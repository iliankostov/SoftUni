namespace AutomationTests.Data
{
    using System.Data.OleDb;
    using System.Linq;
    using Dapper;
    using Utilities;

    public class DataReader<T> where T : class
    {
        private const string CONNECTION_STRING = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;";
        private const string EXCEL_DATA_PATH = @"..\..\Data\Data.xlsx";
        private const string QUERY_TEMPLATE = @"select * from [{0}$] where TestName = '{1}'";

        public T GetData(string test)
        {
            using (var connection = new OleDbConnection(string.Format(CONNECTION_STRING, EXCEL_DATA_PATH.ToAbsolutePath())))
            {
                return connection.Query<T>(string.Format(QUERY_TEMPLATE, typeof(T).Name, test)).FirstOrDefault();
            }
        }
    }
}
