using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.Model;
using GestioneViaggi.View;
using GestioneViaggi.ViewModel;
using GestioneViaggi.DAL;

namespace GestioneViaggi.Presenter
{
    public delegate void ViaggiRefreshedDelegate(List<Viaggio> viaggi);
    public class ElencoViaggiPresenter
    {
        private IElencoViaggiView _view;
        private ElencoViaggiVModel _vmodel;

        public event ViaggiRefreshedDelegate onViaggiRefreshed;

        public ElencoViaggiPresenter(IElencoViaggiView iElencoViaggiView)
        {
            _view = iElencoViaggiView;
            _vmodel = new ElencoViaggiVModel();
            _vmodel.current = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshViaggi()
        {
            _vmodel.items = ViaggiService.All(); //Dal.db.Viaggi.All().ToList();
            if (onViaggiRefreshed != null)
                onViaggiRefreshed(_vmodel.items);
        }
    }
}
