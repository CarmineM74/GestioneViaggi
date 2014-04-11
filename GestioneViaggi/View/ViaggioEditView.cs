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
using GestioneViaggi.Model;

namespace GestioneViaggi.View
{
    public partial class ViaggioEditView : Form, IViaggioEditView
    {
        private ViaggioEditVModel _vmodel;
        private ViaggioEditPresenter _presenter;
        private Boolean _nuovoProdottoSelezionato = false;

        public ViaggioEditView()
        {
            InitializeComponent();
        }

        public void SetVModel(ViaggioEditVModel vmodel)
        {
            _vmodel = vmodel;
            viaggioVMBs.DataSource = _vmodel;
            viaggioBs.DataSource = _vmodel.current;
            rigaBs.DataSource = _vmodel.riga;
            righeBs.DataSource = _vmodel.current.Righe;
            righeDg.DataSource = righeBs;
            prodottiBs.DataSource = _vmodel.prodotti;
            fornitoriBs.DataSource = _vmodel.fornitori;
        }

        public void SetPresenter(ViaggioEditPresenter presenter)
        {
            _presenter = presenter;
        }

        private void righeDg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (righeDg.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
            {
                e.Value = ViewHelpers.EvaluateValue(righeDg.Rows[e.RowIndex].DataBoundItem, righeDg.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void prodottoCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nuovoProdottoSelezionato = true;
            _presenter.SetCurrentProdotto(prodottoCb.SelectedItem as Prodotto);
        }

        private void pesataTb_Leave(object sender, EventArgs e)
        {
            if (_nuovoProdottoSelezionato)
            {
                costoTb.Text = _presenter.CalcolaCostoRiga(_vmodel.riga).ToString();
                _nuovoProdottoSelezionato = false;
            }
        }

        private void nuovaRigaBtn_Click(object sender, EventArgs e)
        {
            _presenter.NuovaRiga();
            rigaBs.DataSource = _vmodel.riga;
        }

        private void annullaNuovaRigaBtn_Click(object sender, EventArgs e)
        {
            _presenter.AnnullaNuovaRiga();
        }

        private void aggiungiRigaBtn_Click(object sender, EventArgs e)
        {
        }

        private void eliminaRigaBtn_Click(object sender, EventArgs e)
        {
        }

    }
}
