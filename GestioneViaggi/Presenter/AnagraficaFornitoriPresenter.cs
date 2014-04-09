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

        public AnagraficaFornitoriPresenter(IAnagraficaFornitoriView iAnagraficaFornitoriView)
        {
            _view = iAnagraficaFornitoriView;
            _vmodel = new AnagraficaFornitoriVModel();
            _vmodel.current = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshFornitori()
        {
            _vmodel.items = Dal.db.Fornitori.All().ToList();
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
                Dal.db.Fornitori.InsertOrUpdate(fornitore);
                refreshFornitori();
            }
        }

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
        }
    }
}
