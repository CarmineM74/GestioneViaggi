using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.ComponentModel;
using System.Windows.Forms;
using GestioneViaggi.DAL;

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

        private Viaggio _current;
        public Viaggio current {
            get { return _current; }
            set { _current = value; NotifyPropertyChanged("current"); }
        }

        public Decimal CostoViaggio
        {
            get { return ((_current == null) ? 0 : _current.TotaleCosto()); }
        }

        public Decimal PesoViaggio
        {
            get { return ((_current == null) ? 0 : _current.TotalePeso()); }
        }

        private Prodotto _selectedProduct;
        public Prodotto selectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; NotifyPropertyChanged("selectedProduct"); }
        }

        public DateTime DataViaggio {
            get { return current.Data; }
            set
            {
                if (current.Data != value)
                {
                    current.Data = value;
                    NotifyPropertyChanged("DataViaggio");
                }
            }
        }

        public long fornitoreId
        {
            get { return current.FornitoreId; }
            set
            {
                if (current.FornitoreId != value)
                {
                    current.FornitoreId = value;
                    current.Fornitore = fornitori.First(f => f.Id == value);
                    NotifyPropertyChanged("fornitoreId");
                }
            }
        }

        private RigaViaggio _riga;
        public RigaViaggio riga {
            get { return _riga; }
            set
            {
                _riga = value;
                NotifyPropertyChanged("riga");
            } 
        }

        public Boolean CanChangeFornitore { get { return (_current.Righe.Count == 0); } }

        public long prodottoId { 
            get { return _riga == null ? 0 : _riga.ProdottoId; } 
            set {
                if (_riga == null)
                    return;
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
        
        public decimal caloPeso { 
            get { return current.CaloPeso; } 
            set {
                if (current.Righe.Count > 0)
                {
                    if (value < 0)
                        throw new Exception("Il calo peso non può essere inferiore a 0!");
                    if (value > current.TotalePeso())
                        throw new Exception("Il calo peso non può essere superiore al peso totale del viaggio!");
                }
                current.CaloPeso = value;

                NotifyPropertyChanged("caloPeso");
            } 
        }

        public Boolean isSelectedRiga { get { return riga != null; } }

        public Boolean canDeleteRiga
        {
            get
            {
                Boolean deletable = true;
                deletable = deletable && (riga != null) && (riga.ProdottoId > 0);
                return deletable;
            }
        }

        public Boolean canPickProdotto
        {
            get { return (fornitoreId > 0); }
        }

        public Boolean canNuovaRiga
        {
            get { return (selectedProduct != null); }
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

        public Boolean CanAddRemoveProducts
        {
            get { return (current != null) && (current.Righe.Count > 0) && (prodotti.Count > 0); }
        }

        public List<Prodotto> prodotti { get; set; }
        public List<Fornitore> fornitori { get; set; }

    }
}
