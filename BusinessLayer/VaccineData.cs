using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer
{
    public class VaccineData
    {
        #region Construtors

        public VaccineData()
        {
            this.vaccineDataId = 0;
            this.idPatient = 0;
            this.idVaccine = 0;
            this.doseNumber = 0;
            this.vaccinationDate = DateTime.MinValue;
            this.idCenter = 0;
        }

        public VaccineData(
            int vaccineDataId,
            int idPatient,
            int idVaccine,
            int doseNumber,
            DateTime vaccinationDate,
            int idCenter)
            : this()
        {
            this.vaccineDataId = vaccineDataId;
            this.idPatient = idPatient;
            this.idVaccine = idVaccine;
            this.doseNumber = doseNumber;
            this.vaccinationDate = vaccinationDate;
            this.idCenter = idCenter;
        }

        #endregion

        #region Properties

        private int vaccineDataId;
        public int VaccineDataId
        {
            get { return vaccineDataId; }
            set
            {
                this.vaccineDataId = value;
            }
        }

        private int idPatient;
        public int IdPatient
        {
            get { return idPatient; }
            set
            {
                this.idPatient = value;
            }
        }

        private int idVaccine;
        public int IdVaccine
        {
            get { return idVaccine; }
            set
            {
                this.idVaccine = value;
            }
        }

        private int doseNumber;
        public int DoseNumber
        {
            get { return doseNumber; }
            set
            {
                this.doseNumber = value;
            }
        }

        private DateTime vaccinationDate;
        public DateTime VaccinationDate
        {
            get { return vaccinationDate; }
            set
            {
                this.vaccinationDate = value;
            }
        }

        private int idCenter;
        public int IdCenter
        {
            get { return idCenter; }
            set
            {
                this.idCenter = value;
            }
        }

        private string DebugMessage
        {
            get
            {
                string message = $"VaccineData {this.VaccineDataId} - Patient [{this.IdPatient}]";
                return message;
            }
        }

        #endregion

        #region Methods

        public static DataTable GetList()
        {
            DataTable dataTable = DataLayer.VaccineData.GetList();
            return dataTable;
        }

        public static VaccineDataCollection GetListVaccineData()
        {
            DataTable dataTable = VaccineData.GetList();

            VaccineDataCollection vaccineData = new VaccineDataCollection(dataTable);
            return vaccineData;
        }

        public void NewVaccineData()
        {
            this.VaccineDataId = 0;
            this.IdPatient = 0;
            this.IdVaccine = 0;
            this.DoseNumber = 0;
            this.VaccinationDate = DateTime.MinValue;
            this.IdCenter = 0;
        }

        public bool Filter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return true;
            }

            filter = filter.ToLower();

            return this.VaccineDataId.ToString().Contains(filter)
                || this.IdPatient.ToString().Contains(filter)
                || this.IdVaccine.ToString().Contains(filter)
                || this.DoseNumber.ToString().Contains(filter)
                || this.IdCenter.ToString().Contains(filter)
                || this.VaccinationDate.ToString("dd/MM/yyyy").Contains(filter);
        }

        #endregion
    }
}