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
    public delegate void ClientiRefreshedDelegate(List<Cliente> clienti);
    public delegate void NotifyMessagesDelegate(List<String> messages);

    public class AnagraficaClientiPresenter
    {
        private IAnagraficaClientiView _view;
        private AnagraficaClientiVModel _vmodel;

        public event ClientiRefreshedDelegate onClientiRefreshed;
        public event NotifyMessagesDelegate onClientiSaveError;
        public event NotifyMessagesDelegate onClientiRemoveError;

        public AnagraficaClientiPresenter(IAnagraficaClientiView iAnagraficaClientiView)
        {
            _view = iAnagraficaClientiView;
            _vmodel = new AnagraficaClientiVModel();
            _vmodel.currentClient = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshClienti()
        {
            _vmodel.Clienti = Dal.db.Clienti.All().ToList();
            if (onClientiRefreshed != null)
                onClientiRefreshed(_vmodel.Clienti);
        }

        internal void SaveClient(Cliente cliente)
        {
            if (!cliente.isValid())
            {
                if (onClientiSaveError != null)
                    onClientiSaveError(cliente.Errors);
            }
            else
            {
                Dal.db.Clienti.InsertOrUpdate(cliente);
                refreshClienti();
            }
        }

        internal void RemoveClient(Cliente cliente)
        {
            List<String> errors = new List<string>();
            var viaggi = Dal.db.Query("select * from Viaggio where ClienteId=@id", new { id = cliente.Id });
            if (viaggi.Count() > 0)
            {
                errors.Add(String.Format("Impossibile rimuovere il cliente: {0} viaggi associati", viaggi.Count()));
                if (onClientiRemoveError != null)
                    onClientiRemoveError(errors);
            }
        }
    }
}
