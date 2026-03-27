using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Collections.ObjectModel;

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

                vaccine.IdVacina = item.Field<int>("id_vacina");
                vaccine.NomeVacina = item.Field<string>("NomeVacina");
                vaccine.Doenca = item.Field<string>("doenca");
                vaccine.Fabricante = item.Field<string>("fabricante");
                vaccine.DosesTotais = item.Field<int>("doses_totais");

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