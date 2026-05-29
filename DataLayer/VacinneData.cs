using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class VaccineData
    {
        #region Methods

        public static DataTable GetList()
        {
            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VacinneManager;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            string erro = string.Empty;
            DataTable dataTable = GlobalData.ObterLista("GetAllVaccineData", connectionString, out erro);

            if (dataTable == null)
            {
                System.Diagnostics.Debug.WriteLine("DataTable é NULL");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DataTable NÃO é NULL");
                System.Diagnostics.Debug.WriteLine($"Número de linhas: {dataTable.Rows.Count}");
            }

            return dataTable;
        }

        #endregion
    }
}