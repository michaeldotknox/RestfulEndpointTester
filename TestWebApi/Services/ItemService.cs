using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Common.DataContracts.v1;
using Dapper;

namespace TestWebApi.Services
{
    public class ItemService
    {
        public async Task<GetItem> Get(int id)
        {
            var connectionString =
                @"Server =.\SQLExpress; AttachDbFilename =|DataDirectory| testdata.mdf; Database = dbname;Trusted_Connection = Yes;";
            using (var connection = new SqlConnection(connectionString))
            {
                var item = (await connection.QueryAsync<GetItem>("SELECT Id, Name FROM Item WHERE Id = @Id", new[] {id})).FirstOrDefault();

                return item;
            }
        }
    }
}
