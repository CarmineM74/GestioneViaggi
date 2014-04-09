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
    public delegate void ProdottiRefreshedDelegate(List<Prodotto> prodotti);
    public class AnagraficaProdottiPresenter
    {
        private IAnagraficaProdottiView _view;
        private AnagraficaProdottiVModel _vmodel;

        public event ProdottiRefreshedDelegate onProdottiRefreshed;

        public AnagraficaProdottiPresenter(IAnagraficaProdottiView iAnagraficaProdottiView)
        {
            _view = iAnagraficaProdottiView;
            _vmodel = new AnagraficaProdottiVModel();
            _vmodel.current = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshProdotti()
        {
            _vmodel.items = Dal.db.Prodotti.All().ToList();
            if (onProdottiRefreshed != null)
                onProdottiRefreshed(_vmodel.items);
        }
    }
}
