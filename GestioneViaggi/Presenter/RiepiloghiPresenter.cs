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
    public class RiepiloghiPresenter : IDisposable
    {
        private StatisticheVModel _vmodel;
        private IRiepiloghiView _view;

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

        internal void RiepilogoGenerale()
        {
            _vmodel.dataset = new Model.StatisticheDs();
            StatisticheDs.TotalizzatoriRow totalizzatori = _vmodel.dataset.Totalizzatori.NewTotalizzatoriRow();
            _vmodel.totalizzatori = new Totalizzatori(_vmodel.viaggi);
            _vmodel.totalizzatori.Aggiorna();
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
            foreach (Prodotto p in FornitoreService.ListinoPerFornitore(fornitore))
            {
                if (_vmodel.prodotti.Count(p2 => p2.Descrizione == p.Descrizione) <= 0)
                    _vmodel.prodotti.Add(p);
            }
        }

        internal void SetProdotto(Prodotto prodotto)
        {
            _vmodel.prodotto = prodotto;
        }
    }
}
