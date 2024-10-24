using System.Data;
using System.Data.SqlClient;

namespace api.Connection
{
    public class Connection : IConnection
    {
        private readonly IConfiguration _configuration;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null)
                {
                    return null;
                }

                sqlConnection.ConnectionString = _configuration.GetConnectionString("SQL");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }

    public interface IConnection
    {
        IDbConnection GetConnection { get; }
    }
}
