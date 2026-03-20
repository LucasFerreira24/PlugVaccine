using System;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class Patient
    {
        // Replace with your actual connection string
        private string connectionString = "Server=localhost;Database=NomeDoSeuBanco;Trusted_Connection=True;TrustServerCertificate=True;";

        //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False

        public void Insert(string name, string birthDate, string phone)
        {
            string query = "INSERT INTO pacientes (nome_paciente, data_nascimento, telefone) VALUES (@name, @birthDate, @phone)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@birthDate", birthDate);
                cmd.Parameters.AddWithValue("@phone", phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void PopulateDatabase()
        {
            string query = @"
                INSERT INTO pacientes (nome_paciente, data_nascimento, telefone) VALUES
                ('Ana Silva', '1985-04-12', '+351912345678'),
                ('João Costa', '1990-09-23', '+351934567890'),
                ('Maria Santos', '1978-01-30', '+351965432109'),
                ('Carlos Pereira', '2000-07-15', '+351987654321'),
                ('Sofia Martins', '1995-12-05', '+351923456789');";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
