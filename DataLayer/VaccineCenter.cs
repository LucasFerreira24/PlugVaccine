using System;
using Microsoft.Data.SqlClient; // Use apenas este para .NET moderno
using System.Collections.Generic;

namespace DataLayer
{
    public class VaccineCenter
    {
        // Certifique-se de substituir pela sua string real
        private string connectionString = "Server=localhost;Database=NomeDoSeuBanco;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Inserir(string name, string city, string phone)
        {
            string query = "INSERT INTO centros_vacinacao (center_name, city, phone_number) VALUES (center_name, @city, @phone_number)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@center_name", name);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@phone_number", phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        } // Fim do Inserir

        public void PopularBanco()
        {
            string query = @"
                INSERT INTO centros_vacinacao (center_name, city, phone_number) VALUES  
                ('Centro de Saúde de Lisboa', 'Lisboa', '+351213456789'),
                ('Centro de Saúde do Porto', 'Porto', '+351225678901'),
                ('Centro de Saúde de Coimbra', 'Coimbra', '+351239123456'),
                ('Hospital Santa Maria - Vacinação', 'Lisboa', '+351217805000'),
                ('Centro de Vacinação Madrid Salud', 'Madrid', '+34911234567'),
                ('Vaccination Center Paris', 'Paris', '+33123456789'),
                ('NHS Vaccination Centre', 'London', '+442012345678'),
                ('NYC Vaccination Hub', 'New York', '+12125551234'),
                ('Toronto Public Health Clinic', 'Toronto', '+14165550000'),
                ('Sydney Immunisation Centre', 'Sydney', '+61298765432');";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery(); // IMPORTANTE: Isso aqui é o que faz o SQL rodar de fato
            }
        } // Fim do PopularBanco
    }
}