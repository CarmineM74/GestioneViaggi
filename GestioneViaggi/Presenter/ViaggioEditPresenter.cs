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
using System.Windows.Forms;

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
            switch (e.PropertyName)
            {   
                case "fornitoreId":
                    AggiornaListino();
                    break;
                case "DataViaggio":
                    AggiornaListino();
                    break;
                case "pesata":
                    ricalcolaCostoRiga(_vmodel.riga);
                    break;
                case "caloPeso":
                    ricalcolaCostiRighe();
                    _view.SetVModel(_vmodel);
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
        }

        private void NotifySaveError(List<String> errors)
        {
            if ((errors.Count > 0) && (onViaggioSaveError != null))
                onViaggioSaveError(errors);
        }

        private void AggiornaListino()
        {
            _vmodel.prodotti = FornitoreService.ListinoValidoPerFornitore(_vmodel.current.Fornitore, _vmodel.DataViaggio);
            if (_vmodel.prodotti.Count() == 0)
                MessageBox.Show("Non ci sono listini validi per il fornitore e per la data selezionati", "Recupero listino fornitore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _view.SetVModel(_vmodel);
        }

        public void SetCurrentViaggio(Viaggio viaggio)
        {
            _view.SetPresenter(this);
            _vmodel.current = viaggio;
            _view.SetVModel(_vmodel);
            if (!viaggio.isNew())
                AggiornaListino();
        }

        private void ricalcolaCostoRiga(RigaViaggio riga)
        {
            // 2014.06.16
            // La richiesta del cliente di usare un Calo Peso unico ed in valore assoluto
            // per tutto il documento ci espone ad un grave problema.
            // Tutte le righe con Pesata < del Calo Peso avranno un Costo < 0!
            // Come ci regoliamo ?
            riga.Costo = riga.Prodotto.Costo * riga.Pesata;
            //riga.Pesata -= _vmodel.caloPeso;
        }

        private void ricalcolaCostiRighe()
        {
            Boolean _minoreZero = false;
            foreach (RigaViaggio r in _vmodel.current.Righe)
            {
                ricalcolaCostoRiga(r);
                if (r.Costo <= 0) 
                    _minoreZero = true;
            }
            if (_minoreZero)
                MessageBox.Show("Attenzione!:\nUna o più righe presentano un costo inferiore od uguale a 0!", "Costo righe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            List<String> errori = new List<string>();
            if (_vmodel.current.Righe.Where(r => (r.Costo == 0) || (r.Pesata == 0)).Count() > 0)
                if (MessageBox.Show("Ci sono alcune righe con peso 0 e/o costo 0!\nDesideri salvare ugualmente il viaggio?","Salva viaggio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            if (!ViaggioValidationService.isValid(_vmodel.current))
            {
                errori.AddRange(ViaggioValidationService.Validate(_vmodel.current));
            }
            if (errori.Count() > 0)
                NotifySaveError(errori);
            else
                try {
                    ViaggiService.Save(_vmodel.current);
                }
                catch (Exception ev)
                {
                    errori.Add(String.Format("Impossibile salvare il viaggio: {0}",ev.Message));
                    NotifySaveError(errori);
                }
        }
    }
}
