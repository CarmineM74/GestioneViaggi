using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.ComponentModel;
using System.Windows.Forms;

namespace GestioneViaggi.ViewModel
{
    public class ViaggioEditVModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public Viaggio current { get; set; }

        private RigaViaggio _riga;
        public RigaViaggio riga {
            get { return _riga; }
            set
            {
                _riga = value;
                NotifyPropertyChanged("riga");
            } 
        }

        public Boolean isSelectedRiga { get { return riga != null; } }
        public List<Prodotto> prodotti { get; set; }
        public List<Fornitore> fornitori { get; set; }

    }
}
