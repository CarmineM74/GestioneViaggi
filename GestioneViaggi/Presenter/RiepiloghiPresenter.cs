using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.ViewModel;
using GestioneViaggi.DAL;
using GestioneViaggi.Model;
using System.Data;
using System.Windows.Forms;
using GestioneViaggi.View;
using GestioneViaggi.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace GestioneViaggi.Presenter
{
    public delegate void RiepilogDateRangeInvalidDelegate(DateTime from, DateTime to);
    public delegate void DatiInsufficientiDelegate();

    public class ProdottiDescrizioneEqComparer : IEqualityComparer<Prodotto>
    {
        public bool Equals(Prodotto x, Prodotto y)
        {
            return x.Descrizione == y.Descrizione;
        }

        public int GetHashCode(Prodotto obj)
        {
            return obj.Descrizione.GetHashCode();
        }
    }

    public class RiepiloghiPresenter : IDisposable
    {
        private StatisticheVModel _vmodel;
        private IRiepiloghiView _view;

        public event RiepilogDateRangeInvalidDelegate RiepilogoDateRangeInvalidError;
        public event DatiInsufficientiDelegate DatiInsufficientiError;

        public RiepiloghiPresenter(IRiepiloghiView view)
        {
            _view = view;
            _vmodel = new StatisticheVModel();
            _vmodel.prodotti = new List<Prodotto>();
            _vmodel.viaggi = ViaggiService.All();
            _vmodel.FiltroDal = DateTime.Today.Date;
            _vmodel.FiltroAl = _vmodel.FiltroDal;
            _view.SetVModel(_vmodel);
        }

        public void Dispose()
        {
        }

        internal Boolean isValidDateRange()
        {
            return (DateTime.Compare(_vmodel.FiltroDal.Date, _vmodel.FiltroAl.Date) <= 0);
        }

        internal List<Viaggio> FiltraViaggiPerData(List<Viaggio> viaggi)
        {
            DateTime dal, al;
            dal = _vmodel.FiltroDal.Date;
            al = _vmodel.FiltroAl.Date;
            return viaggi.Where(v => (DateTime.Compare(dal, v.Data.Date) <= 0) && (DateTime.Compare(al, v.Data.Date) >= 0)).ToList();
        }

        internal List<Viaggio> FiltraViaggiPerProdotto(List<Viaggio> viaggi)
        {
            return viaggi.Where(v => v.HasProdotto(_vmodel.prodotto)).ToList();
        }

        internal void RiepilogoGenerale()
        {
            if (isValidDateRange())
            {
                List<Viaggio> vs = FiltraViaggiPerData(_vmodel.viaggi);
                vs = FiltraViaggiPerProdotto(vs);
                _vmodel.totalizzatori = new Totalizzatori(vs);
                if (vs.Count() > 0)
                {
                    _vmodel.dataset = new Model.StatisticheDs();
                    StatisticheDs.TotalizzatoriRow totalizzatori = _vmodel.dataset.Totalizzatori.NewTotalizzatoriRow();
                    _vmodel.totalizzatori.Aggiorna();
                    _vmodel.totalizzatori.FillRow(_vmodel.fornitore,_vmodel.prodotto,_vmodel.FiltroDal,_vmodel.FiltroAl,totalizzatori);
                    _vmodel.dataset.Totalizzatori.Rows.Add(totalizzatori);
                }
                else
                {
                    if (DatiInsufficientiError != null)
                        DatiInsufficientiError();
                }
            }
            else
            {
                if (RiepilogoDateRangeInvalidError != null)
                    RiepilogoDateRangeInvalidError(_vmodel.FiltroDal, _vmodel.FiltroAl);
            }
        }

        internal void SetFornitori(List<Fornitore> fornitori)
        {
            _vmodel.fornitori = fornitori;
        }

        internal void SetFornitore(Fornitore fornitore)
        {
            _vmodel.fornitore = fornitore;
            // Recuperiamo l'elenco dei prodotti legati al fornitore selezionato
            // Non dobbiamo considerare la data di validità.
            _vmodel.prodotti.Clear();
            _vmodel.prodotti.AddRange(FornitoreService.ListinoPerFornitore(fornitore).Distinct(new ProdottiDescrizioneEqComparer()));
            // Recuperiamo l'elenco dei viaggio legati al fornitore selezionato
            _vmodel.viaggi = ViaggiService.FindByFornitore(fornitore);
        }

        internal void SetProdotto(Prodotto prodotto)
        {
            _vmodel.prodotto = prodotto;
        }

        public void SetDateFilterFromTo(DateTime from, DateTime to)
        {
            _vmodel.FiltroDal = from;
            _vmodel.FiltroAl = to;
            if (!isValidDateRange())
            {
                _vmodel.FiltroDal = DateTime.Now.Date;
                _vmodel.FiltroAl = DateTime.Now.Date;
                if (RiepilogoDateRangeInvalidError != null)
                    RiepilogoDateRangeInvalidError(from, to);
            }
        }
    }
}
