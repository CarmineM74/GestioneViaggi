using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.Windows.Forms;
using System.ComponentModel;

namespace GestioneViaggi.ViewModel
{
    public class AnagraficaFornitoriVModel : IVModel<Fornitore>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private List<Fornitore> _items;
        public List<Fornitore> items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged("items"); }
        }

        private Fornitore _current;
        public Fornitore current
        {
            get { return _current; }
            set { _current = value; NotifyPropertyChanged("current"); }
        }

        public String RagioneSociale
        {
            get { return (current == null ? "" : current.RagioneSociale); }
            set 
            {
                Fornitore fr = _items.SingleOrDefault(f => f.RagioneSociale == value);
                if (fr != null)
                    throw new Exception("Esiste già un fornitore con la stessa ragione sociale!");
                else
                {
                    current.RagioneSociale = value;
                    NotifyPropertyChanged("RagioneSociale");
                }
            }
        }

        public Boolean isSelected { get { return _current != null; } }

        public List<Prodotto> currentListino
        {
            get { return (isSelected ? current.Listino : null);  }
        }

        public Boolean canEditListino { get { return (isSelected && (_current.Id > 0)); } }

        private Prodotto _currentProdotto;
        public Prodotto currentProdotto
        {
            get { return _currentProdotto; }
            set { _currentProdotto = value; NotifyPropertyChanged("currentProdotto"); }
        }

        public Boolean isSelectedProdotto { get { return _currentProdotto != null; } }
        public Boolean canDeleteProdotto { get { return isSelectedProdotto; } }
        public Boolean canEditProdotto { get { return isSelectedProdotto; } }

    }
}
