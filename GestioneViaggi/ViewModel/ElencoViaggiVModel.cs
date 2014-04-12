using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.ComponentModel;
using System.Windows.Forms;

namespace GestioneViaggi.ViewModel
{
    public class ElencoViaggiVModel : IVModel<Viaggio>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public List<Viaggio> items { get; set; }

        private Viaggio _current = null;
        public Viaggio current { get { return _current; }
            set
            {
                _current = value;
                NotifyPropertyChanged("current");
            }
        }
        public Boolean isSelected { get { return current != null; } }

        public ViaggioFilter filtro = new ViaggioFilter();

        public String fornitoreFilter { get { return filtro.fornitore; } set { filtro.fornitore = value; } }
        public String targaFilter { get { return filtro.targa; } set { filtro.targa = value; } }
        public String conducenteFilter { get { return filtro.conducente; } set { filtro.conducente = value; } }

        public DateTime dalFilter { 
            get { return filtro.dal; } 
            set { 
                filtro.dal = value;
                NotifyPropertyChanged("dalFilter");
            } 
        }
        
        public DateTime alFilter { 
            get { return filtro.al; } 
            set { 
                filtro.al = value;
                NotifyPropertyChanged("alFilter");
            } 
        }

        public Boolean dataFilterEnabled { 
            get { return filtro.dataEnabled; } 
            set { 
                filtro.dataEnabled = value;
                NotifyPropertyChanged("dataFilterEnabled");
            } 
        }

    }
}
