using System;
using System.Data.SqlClient;
using Common.DataContracts.v1;

namespace TestWebApi.Services
{
    public class ItemService
    {
        public GetItem Get(int id)
        {
            var connectionString =
                @"Server =.\SQLExpress; AttachDbFilename =|DataDirectory| testdata.mdf; Database = dbname;Trusted_Connection = Yes;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
            throw new NotImplementedException();
        }
    }
}
