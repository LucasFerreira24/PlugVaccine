using System;
using System.Data;
using System.Data.SqlClient;

// Alterar para o que formos usar em conjundo :D #PAPAGAIOFOFINHO

namespace DataLayer
{
    public class Vaccine
    {
        #region Metodos

        public static DataTable GetList()
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.ConnectionString;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Vaccine";

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                con.Close();
            }
            catch (Exception e)
            {
            }

            return dataTable;
        }

        public static DataTable GetList(string filter)
        {
            DataTable dataTable = null;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.ConnectionString;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Vaccine WHERE NomeVacina LIKE @Filter";

                SqlParameter param = new SqlParameter("Filter", SqlDbType.VarChar, 100);
                param.Value = "%" + filter + "%";
                cmd.Parameters.Add(param);

                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                dataTable = new DataTable();
                dataTable.Load(dataReader);

                con.Close();
            }
            catch (Exception e)
            {
            }

            return dataTable;
        }

        public static bool GetVaccine(int idVacina, ref string nomeVacina, ref string doenca, ref string fabricante, ref int dosesTotais, ref string sErro)
        {
            bool bOk = true;
            sErro = "";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.ConnectionString;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Vaccine WHERE id_vacina = @IdVacina";

                SqlParameter param = new SqlParameter("IdVacina", SqlDbType.Int);
                param.Value = idVacina;
                cmd.Parameters.Add(param);

                SqlDataReader sqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();

                    if (!sqlDataReader.IsDBNull(1))
                        nomeVacina = sqlDataReader.GetString(1);

                    if (!sqlDataReader.IsDBNull(2))
                        doenca = sqlDataReader.GetString(2);

                    if (!sqlDataReader.IsDBNull(3))
                        fabricante = sqlDataReader.GetString(3);

                    if (!sqlDataReader.IsDBNull(4))
                        dosesTotais = sqlDataReader.GetInt32(4);

                    bOk = true;
                }

                con.Close();
            }
            catch (Exception e)
            {
                sErro = e.Message;
                bOk = false;
            }

            return bOk;
        }

        public static bool Save(int idVacina, string nomeVacina, string doenca, string fabricante, int dosesTotais, ref string sErro)
        {
            bool bOk = true;
            sErro = "";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.ConnectionString;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"IF EXISTS (SELECT 1 FROM Vaccine WHERE id_vacina = @IdVacina)
                                    UPDATE Vaccine
                                    SET NomeVacina = @NomeVacina,
                                        doenca = @Doenca,
                                        fabricante = @Fabricante,
                                        doses_totais = @DosesTotais
                                    WHERE id_vacina = @IdVacina
                                    ELSE
                                    INSERT INTO Vaccine (id_vacina, NomeVacina, doenca, fabricante, doses_totais)
                                    VALUES (@IdVacina, @NomeVacina, @Doenca, @Fabricante, @DosesTotais)";

                SqlParameter param = new SqlParameter("IdVacina", SqlDbType.Int);
                param.Value = idVacina;
                cmd.Parameters.Add(param);

                param = new SqlParameter("NomeVacina", SqlDbType.VarChar, 100);
                param.Value = nomeVacina;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Doenca", SqlDbType.VarChar, 100);
                param.Value = doenca;
                cmd.Parameters.Add(param);

                param = new SqlParameter("Fabricante", SqlDbType.VarChar, 100);
                param.Value = fabricante;
                cmd.Parameters.Add(param);

                param = new SqlParameter("DosesTotais", SqlDbType.Int);
                param.Value = dosesTotais;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                sErro = e.Message;
                bOk = false;
            }

            return bOk;
        }

        public static bool Delete(int idVacina, ref string sErro)
        {
            bool bOk = true;
            sErro = "";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.ConnectionString;
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Vaccine WHERE id_vacina = @IdVacina";

                SqlParameter param = new SqlParameter("IdVacina", SqlDbType.Int);
                param.Value = idVacina;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                sErro = e.Message;
                bOk = false;
            }

            return bOk;
        }

        #endregion
    }
}
