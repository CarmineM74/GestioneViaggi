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

        private void NotifySaveError(List<String> errors)
        {
            if ((errors.Count > 0) && (onProdottoSaveError != null))
                onProdottoSaveError(errors);
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
            Prodotto prodotto = _vmodel.current;
            List<String> errori = new List<string>();
            if (ProdottoValidationService.isValid(prodotto))
            {
                if (!prodotto.isNew())
                {
                    List<String> cu = ProdottoValidationService.CanUpdate(prodotto);
                    errori.AddRange(cu);
                }
                else
                {
                    List<String> ci = ProdottoValidationService.CanInsert(prodotto);
                    errori.AddRange(ci);
                }
            }
            else
            {
                errori.AddRange(ProdottoValidationService.Validate(prodotto));
            }
            if (errori.Count() > 0)
                NotifySaveError(errori);
            else
                try
                {
                    FornitoreService.SaveProduct(prodotto);
                }
                catch (Exception ev)
                {
                    errori.Add(String.Format("Prodotto non salvato: {0} - {1} - {2} ({3})", prodotto.Descrizione, prodotto.ValidoDal.ToString(), prodotto.Costo, ev.Message));
                    NotifySaveError(errori);
                }
        }
    }
}
