using System.Data;
using Microsoft.Data.SqlClient;


namespace BDServices
{
    public class DataBaseService
    {

        private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlugVaccineDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        // Susana Domingues private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        // Ines Couto private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        // Ana Rocha private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        private SqlConnection? Conn;

        public DataBaseService()
        {
            Conn = null;
        }

        public bool connect()
        {
            try
            {
                Conn = new SqlConnection(ConnectionString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool open()
        {
            try
            {
                if (Conn == null)
                    return false;

                if (Conn.State != ConnectionState.Open)
                    Conn.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool close()
        {
            try
            {
                if (Conn != null && Conn.State == ConnectionState.Open)
                    Conn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ExecuteSelectQuery(string sql)
        {
            DataTable Result = new DataTable();

            try
            {
                if (Conn == null)
                    throw new Exception("Conexão não inicializada.");

                if (!this.open())
                    throw new Exception("Erro ao abrir a connexcao.");

                using (SqlCommand cmd = new SqlCommand(sql, Conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(Result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Result;
        }
    }
}
