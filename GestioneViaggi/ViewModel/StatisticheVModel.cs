using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using System.Windows.Forms;

namespace GestioneViaggi.ViewModel
{
    public class Totalizzatori
    {
        public int NumeroViaggi { get; set; }
        public Decimal TotaleKg { get; set; }
        public Decimal TotaleCosto { get; set; }

        private Decimal _KgViaggioMin = -1;
        public Decimal KgViaggioMin {
            get { return _KgViaggioMin; }
            set
            {
                if (_KgViaggioMin < 0)
                    _KgViaggioMin = value;
                else
                {
                    if (_KgViaggioMin > value)
                        _KgViaggioMin = value;
                }
            }
        }

        private Decimal _KgViaggioMax = -1;
        public Decimal KgViaggioMax
        {
            get { return _KgViaggioMax; }
            set
            {
                if (_KgViaggioMax < 0)
                    _KgViaggioMax = value;
                else
                {
                    if (_KgViaggioMax < value)
                        _KgViaggioMax = value;
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

        public Decimal KgViaggioMedio { get; set; }
        public Decimal CostoViaggioMedio { get; set; }
        public Decimal CostoMedioKg { get; set; }
        public Decimal CaloPesoMedio { get; set; }

        public List<int> ViaggiMeseAc { get; set; }
        public List<int> ViaggiMeseAp { get; set; }

        private List<Viaggio> _viaggi;

        public Totalizzatori(List<Viaggio> viaggi)
        {
            NumeroViaggi = 0;
            TotaleCosto = 0;
            TotaleKg = 0;
            _KgViaggioMin = -1;
            _KgViaggioMax = -1;
            _CostoViaggioMin = -1;
            _CostoViaggioMax = -1;
            KgViaggioMedio = 0;
            CostoViaggioMedio = 0;
            CostoMedioKg = 0;
            CaloPesoMedio = 0;
            ViaggiMeseAc = new List<int>();
            ViaggiMeseAp = new List<int>();
            _viaggi = viaggi;
        }

        private Totalizzatori CalcolaTotalizzatori(Totalizzatori t, Viaggio v)
        {
            Decimal totaleKg = v.TotaleKg();
            Decimal totaleCosto = v.TotaleCosto();
            int mese = v.Data.Month;
            t.NumeroViaggi += 1;
            t.TotaleCosto += v.TotaleCosto();
            t.TotaleKg += totaleKg;
            t.KgViaggioMedio = t.TotaleKg;
            t.KgViaggioMin = totaleKg; // Semanticamente non è corretto! Perchè non è detto che l'assegnazione avvenga. Sarebbe più corretto trasformarlo in un metodo.
            t.KgViaggioMax = totaleKg;
            t.TotaleCosto += totaleCosto;
            t.CostoViaggioMedio = t.TotaleCosto;
            t.CostoViaggioMin = totaleCosto;
            t.CostoViaggioMax = totaleCosto;
            t.CostoMedioKg = t.TotaleCosto;
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
            KgViaggioMedio = KgViaggioMedio / NumeroViaggi;
            CostoViaggioMedio = CostoViaggioMedio / NumeroViaggi;
            CostoMedioKg = CostoMedioKg / TotaleKg;
            List<Viaggio> viaggiAc = _viaggi.Where(v => v.Data.Year == DateTime.Today.Year).ToList();
            List<Viaggio> viaggiAp = _viaggi.Where(v => v.Data.Year == DateTime.Today.Year-1).ToList();
            ViaggiMeseAc = ConteggiaViaggiMese(viaggiAc);
            ViaggiMeseAp = ConteggiaViaggiMese(viaggiAp);
        }
    }

    public class StatisticheVModel
    {
        public List<Viaggio> viaggi { get; set; }
        public StatisticheDs dataset { get; set; }
        public Totalizzatori totalizzatori { get; set; }
    }
}
