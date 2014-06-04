using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.View;
using GestioneViaggi.ViewModel;
using GestioneViaggi.DAL;
using GestioneViaggi.Model;
using System.Windows.Forms;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;

namespace GestioneViaggi.Presenter
{
    public delegate void FornitoriRefreshedDelegate(List<Fornitore> fornitori);

    public class AnagraficaFornitoriPresenter
    {
        private IAnagraficaFornitoriView _view;
        private AnagraficaFornitoriVModel _vmodel;

        public event FornitoriRefreshedDelegate onFornitoriRefreshed;
        public event NotifyMessagesDelegate onFornitoriSaveError;
        public event NotifyMessagesDelegate onFornitoriRemoveError;
        public event NotifyMessagesDelegate onProductRemoveError;

        public AnagraficaFornitoriPresenter(IAnagraficaFornitoriView iAnagraficaFornitoriView)
        {
            _view = iAnagraficaFornitoriView;
            _vmodel = new AnagraficaFornitoriVModel();
            _vmodel.current = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshFornitori()
        {
            _vmodel.items = FornitoreService.All();
            if (onFornitoriRefreshed != null)
                onFornitoriRefreshed(_vmodel.items);
        }

        internal void Save(Fornitore fornitore)
        {
            if (!fornitore.isValid())
            {
                if (onFornitoriSaveError != null)
                    onFornitoriSaveError(fornitore.Errors);
            }
            else
            {
                FornitoreService.Save(fornitore);
                refreshFornitori();
            }
        }

        //private void TryRemove(Object obj, Func<Object,int> cnt,Func<Object,int> success, Func<Object,int> failure) 
        //{
        //    if (cnt(obj) > 0)
        //    {
        //        failure(obj);
        //    }
        //    else
        //    {
        //        success(obj);
        //    }
        //}

        //private int RemoveSuccess(Fornitore f)
        //{
        //    return 0;
        //}

        //private int RemoveFailure(Fornitore f)
        //{
        //    return 0;
        //}

        //private void test(Fornitore fornitore)
        //{
        //    TryRemove(fornitore, (f => ViaggiService.FindByFornitore(f as Fornitore).Count()), (f => RemoveSuccess(f as Fornitore)), (f => RemoveFailure(f as Fornitore)));
        //}

        internal void Remove(Fornitore fornitore)
        {
            List<String> errors = new List<string>();
            var viaggi = ViaggiService.FindByFornitore(fornitore);
            if (viaggi.Count() > 0)
            {
                errors.Add(String.Format("Impossibile rimuovere il fornitore: {0} viaggi associati", viaggi.Count()));
                if (onFornitoriRemoveError != null)
                    onFornitoriRemoveError(errors);
            }
            else
            {
                FornitoreService.Delete(fornitore);
                refreshFornitori();
            }
        }

        internal void DeleteProduct(Prodotto prodotto)
        {
            List<String> errors = new List<string>();
            var viaggi = ViaggiService.FindByProdotto(prodotto);
            if (viaggi.Count() > 0)
            {
                errors.Add(String.Format("Impossibile rimuovere il prodotto: {0} viaggi associati", viaggi.Count()));
                if (onProductRemoveError != null)
                    onProductRemoveError(errors);
            }
            else
            {
                FornitoreService.DeleteProduct(prodotto);
                refreshFornitori();
            }
        }

        internal void FilterFornitoreByRagioneSociale(string p)
        {
            List<Fornitore> filtered;
            if ((p.Length < 3) || String.IsNullOrWhiteSpace(p))
                filtered = _vmodel.items;
            else
                filtered = _vmodel.items.Where(f => f.RagioneSociale.Contains(p)).ToList();
            if (onFornitoriRefreshed != null)
                onFornitoriRefreshed(filtered);
        }

    }
}
