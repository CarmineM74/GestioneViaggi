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
    public delegate void FornitoriRefreshedDelegate(List<Fornitore> Fornitori);
    public delegate void NotifyMessagesDelegate(List<String> messages);

    public class AnagraficaFornitoriPresenter
    {
        private IAnagraficaFornitoriView _view;
        private AnagraficaFornitoriVModel _vmodel;

        public event FornitoriRefreshedDelegate onFornitoriRefreshed;
        public event NotifyMessagesDelegate onFornitoriSaveError;
        public event NotifyMessagesDelegate onFornitoriRemoveError;

        public AnagraficaFornitoriPresenter(IAnagraficaFornitoriView iAnagraficaFornitoriView)
        {
            _view = iAnagraficaFornitoriView;
            _vmodel = new AnagraficaFornitoriVModel();
            _vmodel.currentClient = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshFornitori()
        {
            _vmodel.Fornitori = Dal.db.Fornitori.All().ToList();
            if (onFornitoriRefreshed != null)
                onFornitoriRefreshed(_vmodel.Fornitori);
        }

        internal void SaveClient(Fornitore cliente)
        {
            if (!cliente.isValid())
            {
                if (onFornitoriSaveError != null)
                    onFornitoriSaveError(cliente.Errors);
            }
            else
            {
                Dal.db.Fornitori.InsertOrUpdate(cliente);
                refreshFornitori();
            }
        }

        internal void RemoveClient(Fornitore cliente)
        {
            List<String> errors = new List<string>();
            var viaggi = Dal.db.Query("select * from Viaggio where ClienteId=@id", new { id = cliente.Id });
            if (viaggi.Count() > 0)
            {
                errors.Add(String.Format("Impossibile rimuovere il cliente: {0} viaggi associati", viaggi.Count()));
                if (onFornitoriRemoveError != null)
                    onFornitoriRemoveError(errors);
            }
        }
    }
}
