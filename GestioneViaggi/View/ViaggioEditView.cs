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
            errorProvider1.DataSource = viaggioVMBs;
        }

        public void SetPresenter(ViaggioEditPresenter presenter)
        {
            _presenter = presenter;
        }

        private void righeDg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (righeDg.Rows[e.RowIndex] == null)
                return;
            try
            {
                if (righeDg.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
                {
                    e.Value = ViewHelpers.EvaluateValue(righeDg.Rows[e.RowIndex].DataBoundItem, righeDg.Columns[e.ColumnIndex].DataPropertyName);
                }
            }
            catch (Exception)
            {
            }
        }

        private void updateListRighe()
        {
            righeBs.DataSource = _vmodel.current.Righe;
            righeDg.DataSource = righeBs;
            righeBs.ResetBindings(false);
        }

        private void nuovaRigaBtn_Click(object sender, EventArgs e)
        {
            if (_vmodel.current.Righe.Where(r => r.Prodotto.Descrizione == _vmodel.selectedProduct.Descrizione).Count() > 0)
                if (MessageBox.Show("Prodotto già presente nel viaggio!\nVuoi inserirlo comunque?", "Prodotto già presente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            _presenter.NuovaRiga();
            updateListRighe();
            righeBs.MoveLast();
            pesataTb.Focus();
        }

        private void eliminaRigaBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sicuro di voler eliminare la riga corrente?", "Eliminazione riga", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            _presenter.EliminaRigaDalViaggio(_vmodel.riga);
            updateListRighe();
        }

        private void salvaViaggioBtn_Click(object sender, EventArgs e)
        {
            _presenter.SalvaViaggio();
        }

        private void prodottiBs_CurrentChanged(object sender, EventArgs e)
        {
            _vmodel.selectedProduct = prodottiBs.Current as Prodotto;
        }

        private void righeBs_CurrentChanged(object sender, EventArgs e)
        {
            _presenter.ImpostaRigaCorrente(righeBs.Current as RigaViaggio);
        }
    }
}
