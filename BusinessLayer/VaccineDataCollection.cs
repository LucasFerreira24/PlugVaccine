using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class VaccineCollection : Collection<BusinessLayer.Vaccine>, INotifyPropertyChanged
    {
        #region Construtors

        public VaccineCollection()
        {
        }

        public VaccineCollection(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow item in dataTable.AsEnumerable())
            {
                Vaccine vaccine = new Vaccine();

                vaccine.VaccineId = item.Field<int>("vaccine_id");
                vaccine.VaccineName = item.Field<string>("vaccine_name");
                vaccine.Disease = item.Field<string>("disease");
                vaccine.Manufacturer = item.Field<string>("manufacturer");
                vaccine.TotalDoses = item.Field<int>("total_doses");

                this.Add(vaccine);
            }
        }

        #endregion

        #region Methods

        public IEnumerable<Vaccine> Filtrar(string filter)
        {
            IEnumerable<Vaccine> vaccines = from element in this
                                            where element.Filter(filter)
                                            select element;

            return vaccines;
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