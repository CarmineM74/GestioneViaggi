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
    public class ViaggioEditPresenter : IDisposable
    {
        private IViaggioEditView _view;
        private ViaggioEditVModel _vmodel;

        public ViaggioEditPresenter(IViaggioEditView view)
        {
            _view = view;
            _vmodel = new ViaggioEditVModel();
            _vmodel.current = new Viaggio();
            _vmodel.prodotti = Dal.db.Prodotti.All().ToList();
            _vmodel.fornitori = Dal.db.Fornitori.All().ToList();
            _vmodel.riga = null;

        }

        public void Dispose()
        {
        }

        public void SetCurrentViaggio(Viaggio viaggio)
        {
            _vmodel.current = viaggio;
            _view.SetPresenter(this);
            _view.SetVModel(_vmodel);
        }

        internal void NuovaRiga()
        {
            _vmodel.riga = new RigaViaggio();
        }

        internal void AnnullaNuovaRiga()
        {
            _vmodel.riga = null;
        }

        internal void AggiungiRigaAlViaggio()
        {
            _vmodel.current.Righe.Add(_vmodel.riga);
            _vmodel.riga = new RigaViaggio();
        }

        internal Decimal CalcolaCostoRiga(RigaViaggio riga)
        {
            if (riga.ProdottoId <= 0)
                return 0;
            return riga.Prodotto.Costo * riga.Pesata;
        }

        internal void SetCurrentProdotto(Prodotto prodotto)
        {
            _vmodel.riga.Prodotto = prodotto;
            if (prodotto == null)
                _vmodel.riga.ProdottoId = 0;
            else
                _vmodel.riga.ProdottoId = prodotto.Id;
        }

        internal void EliminaRigaDalViaggio(RigaViaggio riga)
        {
            if (riga.Id != 0)
            {
                // Riga non ancora salvata
                _vmodel.current.Righe.Remove(riga);
            }
            else
            {
                // Riga già salvata
            }
        }
    }
}
