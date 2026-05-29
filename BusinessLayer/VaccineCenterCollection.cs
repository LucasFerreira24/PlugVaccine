using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace BusinessLayer
{
    public class VaccineCenterCollection : Collection<BusinessLayer.VaccineCenter>, INotifyPropertyChanged
    {
        #region Construtors

        public VaccineCenterCollection()
        {
        }

        public VaccineCenterCollection(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return;
            }

            foreach (DataRow item in dataTable.AsEnumerable())
            {
                VaccineCenter vaccineCenter = new VaccineCenter();

                vaccineCenter.CenterId = item.Field<int>("center_id");
                vaccineCenter.Name = item.Field<string>("name");
                vaccineCenter.City = item.Field<string>("city");
                vaccineCenter.PhoneNumber = item.Field<string>("phone_number");

                this.Add(vaccineCenter);
            }
        }

        #endregion

        #region Methods

        public IEnumerable<VaccineCenter> Filtrar(string filter)
        {
            IEnumerable<VaccineCenter> vaccineCenters = from element in this
                                                        where element.Filter(filter)
                                                        select element;

            return vaccineCenters;
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