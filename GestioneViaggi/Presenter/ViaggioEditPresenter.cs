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
using System.ComponentModel;

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
            _vmodel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_vmodel_PropertyChanged);
            _vmodel.current = new Viaggio();
            _vmodel.prodotti = Dal.db.Prodotti.All().ToList();
            _vmodel.fornitori = Dal.db.Fornitori.All().ToList();
            _vmodel.riga = null;

        }

        void _vmodel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "fornitoreId") 
            {
                // Recuperiamo il listino per il fornitore selezionato
                _vmodel.prodotti = FornitoreService.ListinoValidoPerFornitore(_vmodel.current.Fornitore,_vmodel.DataViaggio);
                _view.SetVModel(_vmodel);
            }
            if (e.PropertyName == "pesata")
                ricalcolaCostoRiga(_vmodel.riga);
            if (e.PropertyName == "caloPeso")
                ricalcolaCostiRighe();
        }

        public void Dispose()
        {
        }

        public void SetCurrentViaggio(Viaggio viaggio)
        {
            _vmodel.current = viaggio;
            _vmodel.DataViaggio = viaggio.Data;
            _view.SetPresenter(this);
            _view.SetVModel(_vmodel);
        }

        private void ricalcolaCostoRiga(RigaViaggio riga)
        {
            // 2014.06.16
            // La richiesta del cliente di usare un Calo Peso unico ed in valore assoluto
            // per tutto il documento ci espone ad un grave problema.
            // Tutte le righe con Pesata < del Calo Peso avranno un Costo < 0!
            // Come ci regoliamo ?
            riga.Costo = riga.Prodotto.Costo * (riga.Pesata - _vmodel.caloPeso);
        }

        private void ricalcolaCostiRighe()
        {
            foreach (RigaViaggio r in _vmodel.current.Righe)
                ricalcolaCostoRiga(r);
        }

        internal void NuovaRiga()
        {
            // 1. Nuova RigaViaggio()
            // 2. Assegnazione Prodotto selezionato alla riga
            // 3. Inserimento nuova riga nel corpo del viaggio
            _vmodel.riga = new RigaViaggio(_vmodel.selectedProduct);
            _vmodel.current.Righe.Add(_vmodel.riga);
        }

        internal void EliminaRigaDalViaggio(RigaViaggio riga)
        {
            if (riga == null)
                return;
            _vmodel.current.Righe.Remove(riga);
            if (riga.Id != 0)
                ViaggiService.DeleteRiga(riga);
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
