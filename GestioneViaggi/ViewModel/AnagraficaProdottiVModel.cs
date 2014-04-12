using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.ComponentModel;

namespace GestioneViaggi.ViewModel
{
    public class AnagraficaProdottiVModel : IVModel<Prodotto>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private List<Prodotto> _items;
        public List<Prodotto> items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged("items"); }
        }

        private Prodotto _current;
        public Prodotto current
        {
            get { return _current; }
            set { _current = value; NotifyPropertyChanged("current"); }
        }

        private String _descrizione;
        public String descrizione
        {
            get { return _descrizione; }
            set 
            {
                Prodotto pr = _items.SingleOrDefault(p => p.Descrizione == value);
                if (pr != null)
                    throw new Exception("Esiste già un prodotto con la stessa descrizione!");
                else
                {
                    _descrizione = value;
                    NotifyPropertyChanged("descrizione");
                }
            }
        }

        private Decimal _costo;
        public Decimal costo
        {
            get { return _costo; }
            set {
                if (value < 0)
                    throw new Exception("Il costo non può essere inferiore a 0!");
                else
                {
                    _costo = value;
                    NotifyPropertyChanged("costo");
                }
            }
        }

        public Boolean isSelected { get { return current != null; } }

    }
}
