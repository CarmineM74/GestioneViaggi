using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using GestioneViaggi.View;
using GestioneViaggi.ViewModel;
using GestioneViaggi.DAL;

namespace GestioneViaggi.Presenter
{
    public delegate void ProdottiRefreshedDelegate(List<Prodotto> prodotti);
    public class AnagraficaProdottiPresenter
    {
        private IAnagraficaProdottiView _view;
        private AnagraficaProdottiVModel _vmodel;

        public event ProdottiRefreshedDelegate onProdottiRefreshed;
        public event NotifyMessagesDelegate onProdottiSaveError;
        public event NotifyMessagesDelegate onProdottiRemoveError;

        public AnagraficaProdottiPresenter(IAnagraficaProdottiView iAnagraficaProdottiView)
        {
            _view = iAnagraficaProdottiView;
            _vmodel = new AnagraficaProdottiVModel();
            _vmodel.current = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshProdotti()
        {
            _vmodel.items = Dal.db.Prodotti.All().ToList();
            if (onProdottiRefreshed != null)
                onProdottiRefreshed(_vmodel.items);
        }

        internal void FilterProdottoByDescrizione(string p)
        {
            List<Prodotto> filtered;
            if ((p.Length < 3) || String.IsNullOrWhiteSpace(p))
                filtered = _vmodel.items;
            else
                filtered = _vmodel.items.Where(f => f.Descrizione.Contains(p)).ToList();
            if (onProdottiRefreshed != null)
                onProdottiRefreshed(filtered);
        }

        public void Save(Prodotto prodotto)
        {
            if (!prodotto.isValid())
            {
                if (onProdottiSaveError != null)
                    onProdottiSaveError(prodotto.Errors);
            }
            else
            {
                Dal.db.Prodotti.InsertOrUpdate(prodotto);
                refreshProdotti();
            }
        }

        public void Remove(Prodotto prodotto)
        {
            List<String> errors = new List<string>();
            var viaggi = ViaggiService.FindByProdotto(prodotto);
            if (viaggi.Count() > 0)
            {
                errors.Add(String.Format("Impossibile rimuovere il prodotto: {0} viaggi associati", viaggi.Count()));
                if (onProdottiRemoveError != null)
                    onProdottiRemoveError(errors);
            }
            else
            {
                Dal.db.Prodotti.Delete(prodotto.Id);
                refreshProdotti();
            }
        }
    }
}
