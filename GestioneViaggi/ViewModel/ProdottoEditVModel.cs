using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GestioneViaggi.Model;

namespace GestioneViaggi.ViewModel
{
    public class ProdottoEditVModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public List<Prodotto> items { get; set; }

        public Prodotto _current;
        public Prodotto current {
            get { return _current; }
            set
            {
                DatesChanged = false;
                _current = value;
                NotifyPropertyChanged("current");
            }
        }

        private Boolean CheckValidita()
        {
            return (DateTime.Compare(current.ValidoDal.Date,current.ValidoAl.Date) <= 0);
        }

        public Boolean DatesChanged { get; set; }

        public DateTime ValidoDal
        {
            get { return current.ValidoDal; }
            set
            {
                if (DateTime.Compare(current.ValidoDal.Date, value.Date) != 0)
                {
                    current.ValidoDal = value;
                    DatesChanged = true;
                    NotifyPropertyChanged("ValidoDal");
                }
            }
        }

        public DateTime ValidoAl
        {
            get { return current.ValidoAl; }
            set
            {
                if (DateTime.Compare(current.ValidoAl.Date, value.Date) != 0)
                {
                    current.ValidoAl = value;
                    DatesChanged = true;
                    NotifyPropertyChanged("ValidoAl");
                }
            }
        }

        public Fornitore fornitore { get; set; }

        public decimal costo
        {
            get { return current == null ? 0 : current.Costo; }
            set
            {
                if (value < 0)
                    throw new Exception("Il costo non può essere inferiore a 0!");
                else
                {
                    current.Costo = value;
                    NotifyPropertyChanged("costo");
                }
            }
        }

        public String Descrizione
        {
            get { return (current == null ? "" : current.Descrizione); }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new Exception("La descrizione non può essere vuota!");
                else
                {
                    current.Descrizione = value;
                    NotifyPropertyChanged("Descrizione");
                }
            }
        }

        public Boolean CanSave
        {
            get
            {
                return (!String.IsNullOrEmpty(Descrizione) && (costo >= 0) && CheckValidita());
            }
        }

    }
}
