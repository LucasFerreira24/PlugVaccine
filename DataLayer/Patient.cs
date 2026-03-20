using System;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class Patient
    {
        // Update with your actual connection string
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlugVaccineDB;Integrated Security=True;";

        public void Insert(string nome, DateTime dataNascimento, string sexo, string numeroUtente, string contacto, bool grupoRisco)
        {
            string query = @"INSERT INTO pacientes 
                (nome, data_nascimento, sexo, numero_utente, contacto, grupo_risco) 
                VALUES (@nome, @dataNascimento, @sexo, @numeroUtente, @contacto, @grupoRisco)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.Parameters.AddWithValue("@numeroUtente", numeroUtente);
                cmd.Parameters.AddWithValue("@contacto", contacto);
                cmd.Parameters.AddWithValue("@grupoRisco", grupoRisco);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void PopulateDatabase()
        {
            string query = @"
                INSERT INTO pacientes (nome, data_nascimento, sexo, numero_utente, contacto, grupo_risco) VALUES
                ('Ana Silva', '1985-04-12', 'F', '123456789', '+351912345678', 1),
                ('João Costa', '1990-09-23', 'M', '987654321', '+351934567890', 0),
                ('Maria Santos', '1978-01-30', 'F', '456789123', 'maria@email.com', 1),
                ('Carlos Pereira', '2000-07-15', 'M', '321654987', '+351987654321', 0),
                ('Sofia Martins', '1995-12-05', 'F', '654321789', 'sofia@email.com', 1);";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
