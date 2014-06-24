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

namespace GestioneViaggi.Presenter
{
    public delegate void RiepilogDateRangeInvalidDelegate(DateTime from, DateTime to);

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

        public RiepiloghiPresenter(IRiepiloghiView view)
        {
            _view = view;
            _vmodel = new StatisticheVModel();
            _vmodel.prodotti = new List<Prodotto>();
            _vmodel.viaggi = ViaggiService.All();
            _view.SetVModel(_vmodel);
        }

        public void Dispose()
        {
        }

        internal Boolean isValidDateRange()
        {
            return (DateTime.Compare(_vmodel.FiltroDal.Date, _vmodel.FiltroAl.Date) <= 0);
        }

        internal void RiepilogoGenerale()
        {
            if (isValidDateRange())
            {
                _vmodel.dataset = new Model.StatisticheDs();
                StatisticheDs.TotalizzatoriRow totalizzatori = _vmodel.dataset.Totalizzatori.NewTotalizzatoriRow();
                _vmodel.totalizzatori = new Totalizzatori(_vmodel.viaggi);
                _vmodel.totalizzatori.Aggiorna();
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
