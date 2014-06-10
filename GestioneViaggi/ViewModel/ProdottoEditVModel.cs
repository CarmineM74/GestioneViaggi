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

        public DateTime ValidoDal
        {
            get { return current.ValidoDal; }
            set
            {
                current.ValidoDal = value;
                NotifyPropertyChanged("ValidoDal");
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
                Prodotto pr = items.SingleOrDefault(p => (p.Id != current.Id) && (p.Descrizione == value) && (DateTime.Compare(p.ValidoDal.Date,ValidoDal.Date) == 0));
                if (pr != null)
                    throw new Exception("Esiste già un prodotto con la stessa descrizione e validità!");
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
                return (!String.IsNullOrEmpty(Descrizione) && (costo >= 0));
            }
        }

    }
}
