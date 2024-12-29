using Microsoft.Data.SqlClient;
using System.Data;

namespace myapi
{
    public class Globals
    {
        private readonly IConfiguration _configuration;

        public Globals(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlCommand Connection()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
    }
}
