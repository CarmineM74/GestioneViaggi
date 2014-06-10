using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestioneViaggi.ViewModel;
using GestioneViaggi.Presenter;

namespace GestioneViaggi.View
{
    public partial class ProdottoEditView : Form, IProdottoEditView
    {
        private ProdottoEditVModel _vmodel;
        private ProdottoEditPresenter _presenter;

        public ProdottoEditView()
        {
            InitializeComponent();
        }

        private void ProdottoEditView_Shown(object sender, EventArgs e)
        {
            // Fix DateTime 
            // Prevents errorProvider from complaining about dtp.Value not being valid!
            validoDalDtp.Value = DateTime.Now;
        }

        public void SetVModel(ProdottoEditVModel vmodel)
        {
            _vmodel = vmodel;
            prodottoVMBs.DataSource = _vmodel;
        }

        public void SetPresenter(ProdottoEditPresenter presenter)
        {
            _presenter = presenter;
        }

        private void salvaProdottoBtn_Click(object sender, EventArgs e)
        {
            _presenter.SalvaProdotto();
        }
    }
}
