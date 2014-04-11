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
        private Boolean _nuovoProdottoSelezionato = true;

        public ViaggioEditView()
        {
            InitializeComponent();
        }

        public void SetVModel(ViaggioEditVModel vmodel)
        {
            _vmodel = vmodel;
            viaggioVMBs.DataSource = _vmodel;
            viaggioBs.DataSource = _vmodel.current;
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
            if (righeDg.Rows[e.RowIndex] == null)
                return;
            if (righeDg.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
            {
                e.Value = ViewHelpers.EvaluateValue(righeDg.Rows[e.RowIndex].DataBoundItem, righeDg.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void righeDg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _presenter.ImpostaRigaCorrente(righeBs.Current as RigaViaggio);
            if (_vmodel.riga == null)
                return;
            prodottoCb.SelectedValue = _vmodel.riga.ProdottoId;
        }

        private void prodottoCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nuovoProdottoSelezionato = true;
        }

        private void pesataTb_Leave(object sender, EventArgs e)
        {
            Decimal costo = 0;
            Decimal.TryParse(costoTb.Text, out costo);
            if ((_nuovoProdottoSelezionato) || (costo == 0))
            {
                costoTb.Text = _presenter.CalcolaCostoRiga((long)prodottoCb.SelectedValue).ToString();
                _nuovoProdottoSelezionato = false;
            }
        }

        private void nuovaRigaBtn_Click(object sender, EventArgs e)
        {
            _presenter.NuovaRiga();
        }

        private void annullaNuovaRigaBtn_Click(object sender, EventArgs e)
        {
            _presenter.AnnullaNuovaRiga();
        }

        private void aggiungiRigaBtn_Click(object sender, EventArgs e)
        {
            _presenter.AggiungiRigaAlViaggio();
            righeBs.DataSource = _vmodel.current.Righe;
            righeDg.DataSource = righeBs;
            righeBs.ResetBindings(false);
            _presenter.AnnullaNuovaRiga();
            _presenter.NuovaRiga();
        }

        private void eliminaRigaBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sicuro di voler eliminare la riga corrente?", "Eliminazione riga", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            _presenter.EliminaRigaDalViaggio(_vmodel.riga);
            righeBs.DataSource = _vmodel.current.Righe;
            righeDg.DataSource = righeBs;
            righeBs.ResetBindings(false);
            _presenter.AnnullaNuovaRiga();
        }
    }
}
