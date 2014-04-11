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

        public long prodottoId { 
            get { return _riga == null ? 0 : _riga.ProdottoId; } 
            set { 
                _riga.ProdottoId = value;
                NotifyPropertyChanged("prodottoId");
            } 
        }
        
        public Decimal pesata { 
            get { return _riga == null ? 0 : _riga.Pesata; } 
            set {
                if (value < 0)
                    throw new Exception("La pesata non può essere inferiore a 0!");
                else
                {
                    _riga.Pesata = value;
                    NotifyPropertyChanged("pesata");
                }
            } 
        }
        
        public decimal costo { 
            get { return _riga == null ? 0 : _riga.Costo; } 
            set {
                if (value < 0)
                    throw new Exception("Il costo non può essere inferiore a 0!");
                else
                {
                    _riga.Costo = value;
                    NotifyPropertyChanged("costo");
                }
            } 
        }
        
        public int caloPeso { 
            get { return _riga == null ? 0 : _riga.CaloPesoPercentuale; } 
            set {
                if (value < 0)
                    throw new Exception("Il calo peso % non può essere inferiore a 0!");
                else if (value > 100)
                    throw new Exception("Il calo peso % non può essere superiore a 100!");
                else
                {
                    _riga.CaloPesoPercentuale = value;
                    NotifyPropertyChanged("caloPeso");
                }
            } 
        }

        public Boolean isSelectedRiga { get { return riga != null; } }

        public Boolean canDeleteRiga
        {
            get
            {
                Boolean deletable = true;
                deletable = deletable && (riga != null) && (riga.ProdottoId > 0);
                deletable = deletable && current.Righe.Contains(riga);
                return deletable;
            }
        }

        public Boolean canAddRiga
        {
            get
            {
                Boolean canAdd = true;
                canAdd = canAdd && (riga != null) && (riga.ProdottoId > 0);
                return canAdd;
            }
        }

        public Boolean canCancelRiga
        {
            get
            {
                Boolean canCancel = true;
                canCancel = canCancel && canAddRiga;
                return canCancel;
            }
        }

        public Boolean CanSaveViaggio
        {
            get
            {
                Boolean canSave = true;
                canSave = canSave && (current.FornitoreId != 0);
                canSave = canSave && (current.Righe.Count > 0);
                return canSave;
            }
        }

        public List<Prodotto> prodotti { get; set; }
        public List<Fornitore> fornitori { get; set; }

    }
}
