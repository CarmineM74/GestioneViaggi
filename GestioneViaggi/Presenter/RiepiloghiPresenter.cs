using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.ViewModel;
using GestioneViaggi.DAL;
using GestioneViaggi.Model;
using System.Data;
using System.Windows.Forms;

namespace GestioneViaggi.Presenter
{
    public class RiepiloghiPresenter : IDisposable
    {
        private StatisticheVModel _vmodel;

        public RiepiloghiPresenter()
        {
            _vmodel = new StatisticheVModel();
            _vmodel.viaggi = ViaggiService.All();
        }

        public void Dispose()
        {
        }

        internal void RiepilogoGenerale()
        {
            _vmodel.dataset = new Model.StatisticheDs();
            StatisticheDs.TotalizzatoriRow totalizzatori = _vmodel.dataset.Totalizzatori.NewTotalizzatoriRow();
            _vmodel.totalizzatori = new Totalizzatori(_vmodel.viaggi);
            _vmodel.totalizzatori.Aggiorna();
        }

    }
}
