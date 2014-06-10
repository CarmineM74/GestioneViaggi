using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.View;
using GestioneViaggi.ViewModel;
using GestioneViaggi.Model;
using GestioneViaggi.DAL;

namespace GestioneViaggi.Presenter
{
    public class ProdottoEditPresenter : IDisposable
    {
        private IProdottoEditView _view;
        private ProdottoEditVModel _vmodel;
        public ProdottoEditVModel vmodel { get { return _vmodel; } }

        public event NotifyMessagesDelegate onProdottoSaveError;

        public ProdottoEditPresenter(IProdottoEditView view)
        {
            _view = view;
            _vmodel = new ProdottoEditVModel();
            _vmodel.current = new Prodotto();
        }

        public void Dispose()
        {
        }

        public void SetFornitore(Fornitore fornitore)
        {
            _vmodel.fornitore = fornitore;
            _vmodel.items = fornitore.Listino;
        }

        internal void SetCurrentProdotto(Prodotto prodotto)
        {
            _vmodel.current = prodotto;
            _vmodel.current.Fornitore = _vmodel.fornitore;
            _vmodel.current.FornitoreId = _vmodel.fornitore.Id;
            _view.SetPresenter(this);
            _view.SetVModel(_vmodel);
        }

        internal void SalvaProdotto()
        {
            List<String> errori = FornitoreService.SaveProduct(_vmodel.current);
            if ((errori.Count() > 0) && (onProdottoSaveError != null))
                onProdottoSaveError(errori);
        }
    }
}
