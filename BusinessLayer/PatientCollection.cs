using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class PatientCollection : Collection<BusinessLayer.Patient>, INotifyPropertyChanged
    {
        #region Construtors

        public PatientCollection()
        {
        }

        public PatientCollection(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow item in dataTable.AsEnumerable())
            {
                Patient patient = new Patient();

                patient.PatientId = item.Field<int>("patient_id");
                patient.Name = item.Field<string>("name");
                patient.BirthDate = item.Field<System.DateTime>("birth_date");
                patient.Gender = item.Field<string>("gender");
                patient.NationalHealthNumber = item.Field<string>("national_health_number");
                patient.Contact = item.Field<string>("contact");
                patient.RiskGroup = item.Field<bool>("risk_group");

                this.Add(patient);
            }
        }

        #endregion

        #region Methods

        public int GetTotal()
        {
            int total = this.Count;
            return total;
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(propertyName)
                );
            }
        }

        #endregion
    }
}