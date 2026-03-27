using System;
using System.Collections.Generic;
using System.Data;
using DataLayer;


namespace BusinessLayer
{
    public class VaccineData
    {

        #region Propriedades

        private int idRegisto;
        public int IdRegisto
        {
            get { return idRegisto; }
            set { idRegisto = value; }
        }

        private int idPaciente;
        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        private int idVacina;
        public int IdVacina
        {
            get { return idVacina; }
            set { idVacina = value; }
        }

        private int dose;
        public int Dose
        {
            get { return dose; }
            set { dose = value; }
        }

        private DateTime dataVacina;
        public DateTime DataVacina
        {
            get { return dataVacina; }
            set { dataVacina = value; }
        }

        private string idCentro;
        public string IdCentro
        {
            get { return idCentro; }
            set { idCentro = value; }
        }

        #endregion

        #region Construtor

        public VaccineData()
        {
            idRegisto = 0;
            idPaciente = 0;
            idVacina = 0;
            dose = 0;
            dataVacina = DateTime.MinValue;
            idCentro = string.Empty;
        }

        public VaccineData(int idRegisto, int idPaciente, int idVacina, int dose, DateTime dataVacina, string idCentro)
        {
            this.idRegisto = idRegisto;
            this.idPaciente = idPaciente;
            this.idVacina = idVacina;
            this.dose = dose;
            this.dataVacina = dataVacina;
            this.idCentro = idCentro;
        }

        #endregion

        #region Metodos

        public static DataTable Listar()
        {
            string error = string.Empty;
            DataTable Result = new DataTable();

            VacinneData VacineDataLayer = new VacinneData();
            return VacineDataLayer.Listar(out error);
        }

        #endregion
    }
}
