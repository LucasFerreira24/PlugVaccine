using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BDServices;

namespace DataLayer
{
    public class VacinneData
    {
        #region Metodos

        #region MetodosNaoUsados

        /*
         public bool Gravar(long numeroRecibo, DateTime dataRecibo, string nome, float total, bool estado, out string erro)
         {
            erro = string.Empty;

            bool resultado = Recibo.GravarRecibo(numeroRecibo, dataRecibo, nome, total, estado, out erro);

            return resultado;
         }

        public static bool GravarRecibo(long numeroRecibo, DateTime dataRecibo, string nome, float total, bool estado, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("GravarRecibo", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("CodigoRecibo", System.Data.SqlDbType.BigInt);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = numeroRecibo;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("DataRecibo", System.Data.SqlDbType.DateTime);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = dataRecibo;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Nome", System.Data.SqlDbType.NVarChar, 200);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = nome;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Total", System.Data.SqlDbType.Real);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = total;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter("Estado", System.Data.SqlDbType.Bit);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = estado;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                resultado = true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }

        public static bool Eliminar(long numeroRecibo, out string erro)
        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("EliminarRecibo", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("CodigoRecibo", System.Data.SqlDbType.BigInt);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = numeroRecibo;

                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                resultado = true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }

        public static bool Obter(long numeroRecibo, ref DateTime dataRecibo, ref string nome, ref float total, ref bool estado, out string erro)

        {
            bool resultado = false;
            erro = string.Empty;

            try
            {
                //SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
                //sqlConnection.Open();

                SqlConnection sqlConnection = BaseDadosGlobal.AbrirBaseDados(Properties.Settings.Default.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand("ObterRecibo", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("CodigoRecibo", System.Data.SqlDbType.BigInt);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = numeroRecibo;

                sqlCommand.Parameters.Add(sqlParameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    if (!sqlDataReader.IsDBNull(1))
                    {
                        dataRecibo = sqlDataReader.GetDateTime(1);
                    }
                    if (!sqlDataReader.IsDBNull(2))
                    {
                        nome = sqlDataReader.GetString(2);
                    }
                    if (!sqlDataReader.IsDBNull(3))
                    {
                        total = sqlDataReader.GetFloat(3);
                    }
                    if (!sqlDataReader.IsDBNull(4))
                    {
                        estado = sqlDataReader.GetBoolean(4);
                    }

                    resultado = true;
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }

            return resultado;
        }

        */


        #endregion

        #region Listar

        public static DataTable Listar(out string erro)
        {
            DataTable dataTable = DatabaseService.ObterLista("ListarRecibo", Properties.Settings.Default.ConnectionString, out erro);
            return dataTable;
        }

        #endregion

        #endregion
    }
}