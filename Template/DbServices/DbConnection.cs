using System.Data.SqlClient;

namespace Production_Analysis.DbServices
{
    /// <summary>
    /// Database connection to MS SQL Server
    /// </summary>
    public class DbConnection
    {
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString = "Server=ANAROCHA\\SQLEXPRESS;Database=ProductionAnalysis;Integrated Security=true";
            //  Aqui e para substituir a connstring acima por uma string de conexão personalizada, caso seja necessário.

        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
