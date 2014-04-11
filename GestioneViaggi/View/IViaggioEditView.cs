using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneViaggi.ViewModel;
using GestioneViaggi.Presenter;

namespace GestioneViaggi.View
{
    public interface IViaggioEditView
    {
        void SetVModel(ViaggioEditVModel model);
        void SetPresenter(ViaggioEditPresenter presenter);
    }
}
