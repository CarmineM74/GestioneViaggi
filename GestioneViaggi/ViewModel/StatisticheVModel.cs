using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.Windows.Forms;
using System.ComponentModel;

namespace GestioneViaggi.ViewModel
{
    public class Totalizzatori
    {
        public int NumeroViaggi { get; set; }
        public Decimal TotaleKg { get; set; }
        public Decimal TotaleCosto { get; set; }

        private Decimal _PesoViaggioMin = -1;
        public Decimal PesoViaggioMin {
            get { return _PesoViaggioMin; }
            set
            {
                if (_PesoViaggioMin < 0)
                    _PesoViaggioMin = value;
                else
                {
                    if (_PesoViaggioMin > value)
                        _PesoViaggioMin = value;
                }
            }
        }

        private Decimal _PesoViaggioMax = -1;
        public Decimal PesoViaggioMax
        {
            get { return _PesoViaggioMax; }
            set
            {
                if (_PesoViaggioMax < 0)
                    _PesoViaggioMax = value;
                else
                {
                    if (_PesoViaggioMax < value)
                        _PesoViaggioMax = value;
                }
            }
        }

        private Decimal _CostoViaggioMin = -1;
        public Decimal CostoViaggioMin {
            get { return _CostoViaggioMin; }
            set
            {
                if (_CostoViaggioMin < 0)
                    _CostoViaggioMin = value;
                else
                {
                    if (_CostoViaggioMin > value)
                        _CostoViaggioMin = value;
                }
            }
        }

        private Decimal _CostoViaggioMax = -1;
        public Decimal CostoViaggioMax
        {
            get { return _CostoViaggioMax; }
            set
            {
                if (_CostoViaggioMax < 0)
                    _CostoViaggioMax = value;
                else
                {
                    if (_CostoViaggioMax < value)
                        _CostoViaggioMax = value;
                }
            }
        }

        public Decimal PesoViaggioMedio { get; set; }
        public Decimal CostoViaggioMedio { get; set; }
        public Decimal CostoMedioPeso { get; set; }
        public Decimal CaloPesoMedio { get; set; }

        public List<int> ViaggiMeseAc { get; set; }
        public List<int> ViaggiMeseAp { get; set; }

        private List<Viaggio> _viaggi;

        public Totalizzatori(List<Viaggio> viaggi)
        {
            NumeroViaggi = 0;
            TotaleCosto = 0;
            TotaleKg = 0;
            _PesoViaggioMin = -1;
            _PesoViaggioMax = -1;
            _CostoViaggioMin = -1;
            _CostoViaggioMax = -1;
            PesoViaggioMedio = 0;
            CostoViaggioMedio = 0;
            CostoMedioPeso = 0;
            CaloPesoMedio = 0;
            ViaggiMeseAc = new List<int>();
            ViaggiMeseAp = new List<int>();
            _viaggi = viaggi;
        }

        private Totalizzatori CalcolaTotalizzatori(Totalizzatori t, Viaggio v)
        {
            Decimal totalePeso = v.TotalePeso();
            Decimal totaleCosto = v.TotaleCosto();
            int mese = v.Data.Month;
            t.NumeroViaggi += 1;
            t.TotaleCosto += v.TotaleCosto();
            t.TotaleKg += totalePeso;
            t.PesoViaggioMedio = t.TotaleKg;
            t.PesoViaggioMin = totalePeso; // Semanticamente non è corretto! Perchè non è detto che l'assegnazione avvenga. Sarebbe più corretto trasformarlo in un metodo.
            t.PesoViaggioMax = totalePeso;
            t.TotaleCosto += totaleCosto;
            t.CostoViaggioMedio = t.TotaleCosto;
            t.CostoViaggioMin = totaleCosto;
            t.CostoViaggioMax = totaleCosto;
            t.CostoMedioPeso = t.TotaleCosto;
            return t;
        }

        private List<int> ConteggiaViaggiMese(List<Viaggio> viaggi) 
        {
            var l = from viaggio in viaggi
                    let mese = viaggio.Data.Month
                    group viaggio by mese into monthGroup
                    orderby monthGroup.Key
                    select new
                    {
                        mese = monthGroup.Key,
                        qta = (from v in monthGroup select monthGroup).Count()
                    };
            return l.Select(g => g.qta).ToList();
        }

        public void Aggiorna()
        {
            _viaggi.Aggregate(this, CalcolaTotalizzatori);
            PesoViaggioMedio = PesoViaggioMedio / NumeroViaggi;
            CostoViaggioMedio = CostoViaggioMedio / NumeroViaggi;
            CostoMedioPeso = CostoMedioPeso / TotaleKg;
            List<Viaggio> viaggiAc = _viaggi.Where(v => v.Data.Year == DateTime.Today.Year).ToList();
            List<Viaggio> viaggiAp = _viaggi.Where(v => v.Data.Year == DateTime.Today.Year-1).ToList();
            ViaggiMeseAc = ConteggiaViaggiMese(viaggiAc);
            ViaggiMeseAp = ConteggiaViaggiMese(viaggiAp);
        }
    }

    public class StatisticheVModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private Fornitore _fornitore;
        public Fornitore fornitore 
        {
            get { return _fornitore; }
            set
            {
                if (_fornitore != value)
                {
                    _fornitore = value;
                    NotifyPropertyChanged("fornitore");
                }
            }
        }

        private long _fornitoreId;
        public long fornitoreId
        {
            get { return _fornitoreId; }
            set {
                if (_fornitoreId != value)
                {
                    _fornitoreId = value;
                    NotifyPropertyChanged("fornitoreId");
                }
            }
        }

        private Prodotto _prodotto;
        public Prodotto prodotto
        {
            get { return _prodotto; }
            set {
                if (_prodotto != value)
                {
                    _prodotto = value;
                    NotifyPropertyChanged("prodotto");
                }
            }
        }

        private DateTime _filtroDal;
        public DateTime FiltroDal
        {
            get { return _filtroDal; }
            set { 
                _filtroDal = value; 
                NotifyPropertyChanged("filtroDal"); 
            }
        }

        private DateTime _filtroAl;
        public DateTime FiltroAl
        {
            get { return _filtroAl; }
            set { 
                _filtroAl = value; 
                NotifyPropertyChanged("filtroAl"); 
            }
        }

        public Boolean ProductSelectionEnabled
        {
            get { return (_fornitore != null); }
        }

        public Boolean RiepilogoDateFilterEnabled
        {
            get { return ProductSelectionEnabled && (_prodotto != null); }
        }

        public Boolean RiepilogoGeneraleBtnEnabled
        {
            get { return RiepilogoDateFilterEnabled; }
        }

        private List<Fornitore> _fornitori;
        public List<Fornitore> fornitori
        {
            get { return _fornitori; }
            set { _fornitori = value; NotifyPropertyChanged("fornitori"); }
        }
        public List<Prodotto> prodotti { get; set; }
        public List<Viaggio> viaggi { get; set; }
        public StatisticheDs dataset { get; set; }
        public Totalizzatori totalizzatori { get; set; }

    }
}
