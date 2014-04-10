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

        public List<Viaggio> items { get; set; }
        public Viaggio current { get; set; }
        public Boolean isSelected { get { return current != null; } }

        public ViaggioFilter filtro = new ViaggioFilter();

        public String fornitoreFilter { get { return filtro.fornitore; } set { filtro.fornitore = value; } }
        public String targaFilter { get { return filtro.targa; } set { filtro.targa = value; } }
        public String conducenteFilter { get { return filtro.conducente; } set { filtro.conducente = value; } }

        public DateTime dalFilter { 
            get { return filtro.dal; } 
            set { 
                filtro.dal = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("dalFilter"));
            } 
        }
        
        public DateTime alFilter { 
            get { return filtro.al; } 
            set { 
                filtro.al = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("alFilter"));
            } 
        }

        public Boolean dataFilterEnabled { 
            get { return filtro.dataEnabled; } 
            set { 
                filtro.dataEnabled = value; 
                if (PropertyChanged != null) 
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("dataFilterEnabled"));
                }
            } 
        }

    }
}
