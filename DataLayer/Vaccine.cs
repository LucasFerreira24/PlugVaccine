using System;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class Vaccine
    {
        #region Methods

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
                cmd.CommandText = "SELECT vaccine_id, vaccine_name, disease, manufacturer, total_doses FROM Vaccine";

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
                cmd.CommandText = @"SELECT vaccine_id, vaccine_name, disease, manufacturer, total_doses
                                    FROM Vaccine
                                    WHERE vaccine_name LIKE @filter
                                       OR disease LIKE @filter
                                       OR manufacturer LIKE @filter";

                cmd.Parameters.AddWithValue("@filter", "%" + filter + "%");

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

        #endregion
    }
}