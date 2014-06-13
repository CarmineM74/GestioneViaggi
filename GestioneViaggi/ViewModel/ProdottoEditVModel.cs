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
        public Prodotto current { get; set; }

        private Boolean CheckValidita()
        {
            return (DateTime.Compare(current.ValidoDal.Date,current.ValidoAl.Date) <= 0);
        }

        public DateTime ValidoDal
        {
            get { return current.ValidoDal; }
            set
            {
//                DateTime _oldval = current.ValidoDal;
                current.ValidoDal = value;
//                if (CheckValidita())
                    NotifyPropertyChanged("ValidoDal");
                //else
                //{
                //    current.ValidoDal = _oldval;
                //    throw new Exception("L'intervallo di validità specificato NON è valido!");
                //}
            }
        }

        public DateTime ValidoAl
        {
            get { return current.ValidoAl; }
            set
            {
//                DateTime _oldval = current.ValidoAl;
                current.ValidoAl = value;
//                if (CheckValidita())
                    NotifyPropertyChanged("ValidoAl");
                //else
                //{
                //    current.ValidoAl = _oldval;
                //    throw new Exception("L'intervallo di validità specificato NON è valido!");
                //}
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
