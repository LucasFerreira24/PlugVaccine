using System;
using System.ComponentModel;
using System.Data;

namespace BusinessLayer
{
    public class Patient
    {
        #region Construtors

        public Patient()
        {
            this.patientId = 0;
            this.name = string.Empty;
            this.birthDate = DateTime.MinValue;
            this.gender = string.Empty;
            this.nationalHealthNumber = string.Empty;
            this.contact = string.Empty;
            this.riskGroup = false;
        }

        public Patient(
            int patientId,
            string name,
            DateTime birthDate,
            string gender,
            string nationalHealthNumber,
            string contact,
            bool riskGroup)
            : this()
        {
            this.patientId = patientId;
            this.name = name;
            this.birthDate = birthDate;
            this.gender = gender;
            this.nationalHealthNumber = nationalHealthNumber;
            this.contact = contact;
            this.riskGroup = riskGroup;
        }

        #endregion

        #region Properties

        private int patientId;
        public int PatientId
        {
            get { return patientId; }
            set
            {
                this.patientId = value;
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

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                this.birthDate = value;
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                this.gender = value;
            }
        }

        private string nationalHealthNumber;
        public string NationalHealthNumber
        {
            get { return nationalHealthNumber; }
            set
            {
                this.nationalHealthNumber = value;
            }
        }

        private string contact;
        public string Contact
        {
            get { return contact; }
            set
            {
                this.contact = value;
            }
        }

        private bool riskGroup;
        public bool RiskGroup
        {
            get { return riskGroup; }
            set
            {
                this.riskGroup = value;
            }
        }

        private string DebugMessage
        {
            get
            {
                string message = $"Patient {this.PatientId} - [{this.Name}]";
                return message;
            }
        }

        #endregion

        #region Methods

        public static DataTable GetList()
        {
            DataTable dataTable = DataLayer.Patient.GetList();
            return dataTable;
        }

        public static PatientCollection GetListPatients()
        {
            DataTable dataTable = Patient.GetList();

            PatientCollection patients = new PatientCollection(dataTable);
            return patients;
        }

        public void NewPatient()
        {
            this.PatientId = 0;
            this.Name = string.Empty;
            this.BirthDate = DateTime.MinValue;
            this.Gender = string.Empty;
            this.NationalHealthNumber = string.Empty;
            this.Contact = string.Empty;
            this.RiskGroup = false;
        }

        #endregion
    }
}