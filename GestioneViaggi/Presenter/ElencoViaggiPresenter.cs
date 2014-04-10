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
        public event NotifyMessagesMapDelegate onViaggiFilterFailed;

        public ElencoViaggiPresenter(IElencoViaggiView iElencoViaggiView)
        {
            _view = iElencoViaggiView;
            _vmodel = new ElencoViaggiVModel();
            _vmodel.current = null;
            _view.SetVModel(_vmodel);
        }

        public void refreshViaggi()
        {
            _vmodel.items = ViaggiService.All(); 
            if (onViaggiRefreshed != null)
                onViaggiRefreshed(_vmodel.items);
        }

        public void SetDateFilterFromTo(DateTime from, DateTime to)
        {
            _vmodel.dalFilter = from;
            _vmodel.alFilter = to;
        }

        public void ClearFilter()
        {
            _vmodel.filtro = new ViaggioFilter();
            if (onViaggiRefreshed != null)
                onViaggiRefreshed(_vmodel.items);
        }

        internal void ApplyFilter()
        {
            List<Viaggio> viaggi;
            Dictionary<String, List<String>> msgs = new Dictionary<string, List<string>>();
            _vmodel.filtro.CheckValidity(msgs);
            if (msgs.Count > 0)
            {
                if (onViaggiFilterFailed != null)
                    onViaggiFilterFailed(msgs);
            }
            else
            {
                viaggi = _vmodel.items;
               if (_vmodel.filtro.fornitoreValid)
                   viaggi = viaggi.Where(v => v.Fornitore.RagioneSociale.Contains(_vmodel.filtro.fornitore)).ToList();
               if (_vmodel.filtro.targaValid)
                   viaggi = viaggi.Where(v => v.TargaAutomezzo.Contains(_vmodel.filtro.targa)).ToList();
               if (_vmodel.filtro.conducenteValid)
                   viaggi = viaggi.Where(v => v.Conducente.Contains(_vmodel.filtro.conducente)).ToList();
               if ((_vmodel.filtro.dataEnabled) && (_vmodel.filtro.dataValid))
               {
                   viaggi = viaggi.Where(v => (v.Data >= _vmodel.filtro.dal) && (v.Data <= _vmodel.filtro.al)).ToList();
               }
               if (onViaggiRefreshed != null)
                   onViaggiRefreshed(viaggi);
            }
        }
    }
}
