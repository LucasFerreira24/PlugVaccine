using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

// Alterar para o que formos usar em conjundo :D #PAPAGAIOFOFINHO


namespace BusinessLayer
{
    [DebuggerDisplay("{DebugMessage}")]
    public class Vaccine : Notifier
    {
        #region Construtors

        public Vaccine()
        {
            this.nomeVacina = string.Empty;
            this.doenca = string.Empty;
            this.fabricante = string.Empty;
            this.idVacina = 0;
            this.dosesTotais = 0;
        }

        public Vaccine(int idVacina, string nomeVacina, string doenca, string fabricante, int dosesTotais)
            : this()
        {
            this.idVacina = idVacina;
            this.nomeVacina = nomeVacina;
            this.doenca = doenca;
            this.fabricante = fabricante;
            this.dosesTotais = dosesTotais;
        }

        #endregion

        #region Properties

        private int idVacina;
        public int IdVacina
        {
            get { return idVacina; }
            set
            {
                this.idVacina = value;
                this.OnPropertyChanged(nameof(IdVacina));
            }
        }

        private string nomeVacina;
        public string NomeVacina
        {
            get { return nomeVacina; }
            set
            {
                this.nomeVacina = value;
                this.OnPropertyChanged(nameof(NomeVacina));
            }
        }

        private string doenca;
        public string Doenca
        {
            get { return doenca; }
            set
            {
                this.doenca = value;
                this.OnPropertyChanged(nameof(Doenca));
            }
        }

        private string fabricante;
        public string Fabricante
        {
            get { return fabricante; }
            set
            {
                this.fabricante = value;
                this.OnPropertyChanged(nameof(Fabricante));
            }
        }

        private int dosesTotais;
        public int DosesTotais
        {
            get { return dosesTotais; }
            set
            {
                this.dosesTotais = value;
                this.OnPropertyChanged(nameof(DosesTotais));
            }
        }

        private string DebugMessage
        {
            get
            {
                string message = $"Vaccine {this.IdVacina} - [{this.NomeVacina}]";
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

        public static DataTable GetList(string filter)
        {
            return DataLayer.Vaccine.GetList(filter);
        }

        public static VaccineCollection GetListVaccines()
        {
            DataTable dataTable = Vaccine.GetList();

            VaccineCollection vaccines = new VaccineCollection(dataTable);

            return vaccines;
        }

        public static VaccineCollection GetListVaccines(string filter)
        {
            DataTable dataTable = Vaccine.GetList(filter);

            VaccineCollection vaccines = new VaccineCollection(dataTable);

            return vaccines;
        }

        public void NewVaccine()
        {
            this.IdVacina = 0;
            this.NomeVacina = string.Empty;
            this.Doenca = string.Empty;
            this.Fabricante = string.Empty;
            this.DosesTotais = 0;
        }

        public bool SaveVaccine(ref string sErro)
        {
            return DataLayer.Vaccine.Save(
                this.IdVacina,
                this.NomeVacina,
                this.Doenca,
                this.Fabricante,
                this.DosesTotais,
                ref sErro
            );
        }

        public bool DeleteVaccine(ref string sErro)
        {
            return DataLayer.Vaccine.Delete(this.IdVacina, ref sErro);
        }

        public static Vaccine GetVaccine(int idVacina)
        {
            Vaccine vaccine = null;
            string nomeVacina = string.Empty;
            string doenca = string.Empty;
            string fabricante = string.Empty;
            int dosesTotais = 0;
            string erro = string.Empty;

            if (DataLayer.Vaccine.GetVaccine(idVacina, ref nomeVacina, ref doenca, ref fabricante, ref dosesTotais, ref erro))
            {
                vaccine = new Vaccine(idVacina, nomeVacina, doenca, fabricante, dosesTotais);
            }

            return vaccine;
        }

        internal bool Filter(string filter)
        {
            bool ok = false;

            if (this.NomeVacina.ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.Doenca.ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.Fabricante.ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }
            else if (this.IdVacina.ToString().ToUpper().Contains(filter.ToUpper()))
            {
                ok = true;
            }

            return ok;
        }

        #endregion
    }

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