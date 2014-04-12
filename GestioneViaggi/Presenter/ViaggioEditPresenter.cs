using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.View;
using GestioneViaggi.ViewModel;
using GestioneViaggi.Model;
using GestioneViaggi.DAL;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;

namespace GestioneViaggi.Presenter
{
    public class ViaggioEditPresenter : IDisposable
    {
        private IViaggioEditView _view;
        private ViaggioEditVModel _vmodel;

        public event NotifyMessagesDelegate onViaggioSaveError;

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
            _vmodel.riga.Prodotto = _vmodel.prodotti.First(p => p.Id == _vmodel.prodottoId);
            _vmodel.current.Righe.Add(_vmodel.riga);
        }

        internal Decimal CalcolaCostoRiga(long prodottoId)
        {
            if (prodottoId <= 0)
                return 0;
            Prodotto pp = _vmodel.prodotti.First(p => p.Id == prodottoId);
            return pp.Costo * _vmodel.pesata;
        }

        internal void EliminaRigaDalViaggio(RigaViaggio riga)
        {
            if (riga == null)
                return;
            if (riga.Id == 0)
            {
                // Riga non ancora salvata
                _vmodel.current.Righe.Remove(riga);
            }
            else
            {
                // Riga già salvata
            }
        }

        internal void ImpostaRigaCorrente(RigaViaggio riga)
        {
            _vmodel.riga = riga;
        }

        internal void SalvaViaggio()
        {
            List<String> errori = ViaggiService.Save(_vmodel.current);
            if ((errori.Count() > 0) && (onViaggioSaveError != null))
                onViaggioSaveError(errori);
        }
    }
}
