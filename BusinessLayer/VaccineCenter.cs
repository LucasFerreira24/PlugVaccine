using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer
{
    public class VaccineCenter
    {
        #region Construtors

        public VaccineCenter()
        {
            this.centerId = 0;
            this.name = string.Empty;
            this.city = string.Empty;
            this.phoneNumber = string.Empty;
        }

        public VaccineCenter(int centerId, string name, string city, string phoneNumber)
            : this()
        {
            this.centerId = centerId;
            this.name = name;
            this.city = city;
            this.phoneNumber = phoneNumber;
        }

        #endregion

        #region Properties

        private int centerId;
        public int CenterId
        {
            get { return centerId; }
            set
            {
                this.centerId = value;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                this.city = value;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                this.phoneNumber = value;
            }
        }

        private string DebugMessage
        {
            get
            {
                string message = $"VaccineCenter {this.CenterId} - [{this.Name}]";
                return message;
            }
        }

        #endregion

        #region Methods

        public static DataTable GetList()
        {
            DataTable dataTable = DataLayer.VaccineCenter.GetList();
            return dataTable;
        }

        public static VaccineCenterCollection GetListVaccineCenters()
        {
            DataTable dataTable = VaccineCenter.GetList();

            VaccineCenterCollection vaccineCenters = new VaccineCenterCollection(dataTable);
            return vaccineCenters;
        }

        public void NewVaccineCenter()
        {
            this.CenterId = 0;
            this.Name = string.Empty;
            this.City = string.Empty;
            this.PhoneNumber = string.Empty;
        }

        public bool Filter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return true;
            }

            filter = filter.ToLower();

            return this.Name.ToLower().Contains(filter)
                || this.City.ToLower().Contains(filter)
                || this.PhoneNumber.ToLower().Contains(filter);
        }

        #endregion
    }
}