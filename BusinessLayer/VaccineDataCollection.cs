using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class VaccineDataCollection : Collection<BusinessLayer.VaccineData>, INotifyPropertyChanged
    {
        #region Construtors

        public VaccineDataCollection()
        {
        }

        public VaccineDataCollection(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow item in dataTable.AsEnumerable())
            {
                VaccineData vaccineData = new VaccineData();

                vaccineData.VaccineDataId = item.Field<int>("vaccine_data_id");
                vaccineData.IdPatient = item.Field<int>("id_patient");
                vaccineData.IdVaccine = item.Field<int>("id_vaccine");
                vaccineData.DoseNumber = item.Field<int>("dose_number");
                vaccineData.VaccinationDate = item.Field<DateTime>("vaccination_date");
                vaccineData.IdCenter = item.Field<int>("id_center");

                this.Add(vaccineData);
            }
        }

        #endregion

        #region Methods

        public IEnumerable<VaccineData> Filtrar(string filter)
        {
            IEnumerable<VaccineData> vaccineData = from element in this
                                                   where element.Filter(filter)
                                                   select element;

            return vaccineData;
        }

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