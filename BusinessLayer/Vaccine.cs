using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer
{
    public class Vaccine
    {
        #region Construtors

        public Vaccine()
        {
            this.vaccineName = string.Empty;
            this.disease = string.Empty;
            this.manufacturer = string.Empty;
            this.vaccineId = 0;
            this.totalDoses = 0;
        }

        public Vaccine(int vaccineId, string vaccineName, string disease, string manufacturer, int totalDoses)
            : this()
        {
            this.vaccineId = vaccineId;
            this.vaccineName = vaccineName;
            this.disease = disease;
            this.manufacturer = manufacturer;
            this.totalDoses = totalDoses;
        }

        #endregion

        #region Properties

        private int vaccineId;
        public int VaccineId
        {
            get { return vaccineId; }
            set
            {
                this.vaccineId = value;
            }
        }

        private string vaccineName;
        public string VaccineName
        {
            get { return vaccineName; }
            set
            {
                this.vaccineName = value;
            }
        }

        private string disease;
        public string Disease
        {
            get { return disease; }
            set
            {
                this.disease = value;
            }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                this.manufacturer = value;
            }
        }

        private int totalDoses;
        public int TotalDoses
        {
            get { return totalDoses; }
            set
            {
                this.totalDoses = value;
            }
        }

        private string DebugMessage
        {
            get
            {
                string message = $"Vaccine {this.VaccineId} - [{this.VaccineName}]";
                return message;
            }
        }

        #endregion

        #region Methods

        public static DataTable GetList()
        {
            DataTable dataTable = DataLayer.Vaccine.GetList();
            return dataTable;
        }

        //public static DataTable GetList(string filter)
        //{
        //    return DataLayer.Vaccine.GetList(filter);
        //}

        public static VaccineCollection GetListVaccines()
        {
            DataTable dataTable = Vaccine.GetList();

            VaccineCollection vaccines = new VaccineCollection(dataTable);
            return vaccines;
        }

        //public static VaccineCollection GetListVaccines(string filter)
        //{
        //    DataTable dataTable = Vaccine.GetList(filter);

        //    //VaccineCollection vaccines = new VaccineCollection(dataTable);

        //    //return vaccines;

        //    return null;
        //}

        public void NewVaccine()
        {
            this.VaccineId = 0;
            this.VaccineName = string.Empty;
            this.Disease = string.Empty;
            this.Manufacturer = string.Empty;
            this.TotalDoses = 0;
        }

        public bool SaveVaccine(ref string sErro)
        {
            //return DataLayer.Vaccine.Save(this.VaccineId, this.VaccineName, this.Disease, this.Manufacturer, this.TotalDoses, ref sErro);
            return true;
        }

        public bool DeleteVaccine(ref string sErro)
        {
            //return DataLayer.Vaccine.Delete(this.VaccineId, ref sErro);
            return true;
        }

        /*
        
        public static Vaccine GetVaccine(int vaccineId)
        {
            Vaccine vaccine = null;
            string vaccineName = string.Empty;
            string disease = string.Empty;
            string manufacturer = string.Empty;
            int totalDoses = 0;
            string erro = string.Empty;

            

            if (DataLayer.Vaccine.GetVaccine(vaccineId, ref vaccineName, ref disease, ref manufacturer, ref totalDoses, ref erro))
            {
                vaccine = new Vaccine(vaccineId, vaccineName, disease, manufacturer, totalDoses);
            }

            return vaccine;
        }

        */

        internal bool Filter(string filter)
        {
            bool ok = false;

            if (this.VaccineName.ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.Disease.ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.Manufacturer.ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.VaccineId.ToString().ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.TotalDoses.ToString().ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }

            return ok;
        }

        #endregion
    }
}