using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;
using GestioneViaggi.DAL;
using GestioneViaggi.Model;
using GestioneViaggi.View;
using GestioneViaggi.Presenter;
using GestioneViaggi.ViewModel;

namespace GestioneViaggi
{
    public partial class MainForm : Form, IAnagraficaFornitoriView, IAnagraficaProdottiView, IElencoViaggiView
    {
        private Dal _dal;
        private AnagraficaFornitoriVModel _anaforvm = null;
        private AnagraficaFornitoriPresenter _anaforpr = null;
        private AnagraficaProdottiVModel _anaprovm = null;
        private AnagraficaProdottiPresenter _anapropr = null;
        private ElencoViaggiPresenter _viaggipr = null;
        private ElencoViaggiVModel _viaggivm = null;

        public MainForm()
        {
            InitializeComponent();
            Setup();
            //testData();
        }

        private void testData()
        {
            Fornitore c;
            Prodotto p;
            foreach (int i in Enumerable.Range(1, 10))
            {
                c = new Fornitore
                {
                    RagioneSociale = "Fornitore di prova " + DateTime.Now.Millisecond.ToString()
                };
                c.Id = Dal.connection.Insert(c);

                p = new Prodotto
                {
                    Descrizione = "Prodotto di prova " + DateTime.Now.Millisecond.ToString(),
                    Costo = Decimal.Parse(new Random(DateTime.Now.Millisecond).Next(100).ToString())
                };
                p.Id = Dal.connection.Insert(p);

            }

            Viaggio v;
            foreach (int j in Enumerable.Range(1, 20))
            {
                v = new Viaggio
                {
                    FornitoreId = new Random(DateTime.Now.Millisecond).Next(1, 10),
                    Data = DateTime.Now,
                    TargaAutomezzo = "EF158NN",
                    Conducente = "Carmine Moleti"
                };
                v.Id = Dal.connection.Insert(v);

                foreach (int i in Enumerable.Range(1, 5))
                {
                    p = Dal.db.Prodotti.Get(new Random(DateTime.Now.Millisecond).Next(1, 10));
                    Decimal pesata = Decimal.Parse(new Random(DateTime.Now.Millisecond).Next(10000).ToString());
                    RigaViaggio rv = new RigaViaggio
                    {
                        ViaggioId = v.Id,
                        ProdottoId = p.Id,
                        Pesata = pesata,
                        CaloPesoPercentuale = new Random(DateTime.Now.Millisecond).Next(100),
                        Costo = p.Costo * pesata
                    };
                    Dal.connection.Insert(rv);
                }
            }
            Dal.connection.Close();
        }

        private void Setup()
        {
            try
            {
                Dal.ensureDb();
                Dal.connection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Errore configurazione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                Process.GetCurrentProcess().Kill();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Text = String.Format("Gestione Viaggi - V{0}", Application.ProductVersion);
            _anaforpr = new AnagraficaFornitoriPresenter(this as IAnagraficaFornitoriView);
            _anaforpr.onFornitoriRefreshed += new FornitoriRefreshedDelegate(_anaforpr_onFornitoriRefreshed);
            _anaforpr.onFornitoriSaveError += new NotifyMessagesDelegate(_anaforpr_onFornitoriSaveError);
            _anaforpr.onFornitoriRemoveError += new NotifyMessagesDelegate(_anaforpr_onFornitoriSaveError);
            _anaforpr.refreshFornitori();
            _anapropr = new AnagraficaProdottiPresenter(this as IAnagraficaProdottiView);
            _anapropr.onProdottiRefreshed += new ProdottiRefreshedDelegate(_anapropr_onProdottiRefreshed);
            _anapropr.refreshProdotti();
            _viaggipr = new ElencoViaggiPresenter(this as IElencoViaggiView);
            _viaggipr.onViaggiRefreshed += new ViaggiRefreshedDelegate(_viaggipr_onViaggiRefreshed);
            _viaggipr.refreshViaggi();
        }

        void IElencoViaggiView.SetVModel(ElencoViaggiVModel model)
        {
            _viaggivm = model;
            elencoViaggiVMBs.DataSource = _viaggivm;
        }

        void _viaggipr_onViaggiRefreshed(List<Viaggio> viaggi)
        {
            elencoViaggiBs.DataSource = viaggi;
            elencoViaggiDg.DataSource = elencoViaggiBs;
        }

        private void elencoViaggiDg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (elencoViaggiDg.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
            {
                e.Value = ViewHelpers.EvaluateValue(elencoViaggiDg.Rows[e.RowIndex].DataBoundItem, elencoViaggiDg.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        void IAnagraficaProdottiView.SetVModel(AnagraficaProdottiVModel model)
        {
            _anaprovm = model;
            anagraficaProdottiVMBs.DataSource = _anaprovm;
        }

        void _anapropr_onProdottiRefreshed(List<Prodotto> prodotti)
        {
            elencoProdottiBs.DataSource = prodotti;
            elencoProdottiDg.DataSource = elencoProdottiBs;
        }

        private void elencoProdottiBs_CurrentChanged(object sender, EventArgs e)
        {
            _anaprovm.current = (elencoProdottiBs.Current as Prodotto).Clone();
            currentProdottoBs.DataSource = _anaprovm.current;
            anagraficaProdottiVMBs.ResetBindings(false);
        }

        void _anaforpr_onFornitoriSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages));
        }

        void IAnagraficaFornitoriView.SetVModel(AnagraficaFornitoriVModel model)
        {
            _anaforvm = model;
            anagraficaFornitoriVMBs.DataSource = _anaforvm;
        }

        void _anaforpr_onFornitoriRefreshed(List<Fornitore> fornitori)
        {
            elencoFornitoriBs.DataSource = fornitori;
            elencoFornitoriDg.DataSource = elencoFornitoriBs;
        }

        private void elencoFornitoriBs_CurrentChanged(object sender, EventArgs e)
        {
            _anaforvm.current = (elencoFornitoriBs.Current as Fornitore).Clone();
            currentFornitoreBs.DataSource = _anaforvm.current;
            anagraficaFornitoriVMBs.ResetBindings(false);
        }

        private void salvaFornitoreBtn_Click(object sender, EventArgs e)
        {
            _anaforpr.Save(_anaforvm.current);
        }

        private void nuovoFornitoreBtn_Click(object sender, EventArgs e)
        {
            _anaforvm.current = new Fornitore();
            currentFornitoreBs.DataSource = _anaforvm.current;
            anagraficaFornitoriVMBs.ResetBindings(false);
        }

        private void eliminaFornitoreBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedere con la rimozione del cliente selezionato?", "Rimozione cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _anaforpr.Remove(_anaforvm.current);
            }
        }

        private void terminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ragioneSocialeFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            _anaforpr.FilterFornitoreByRagioneSociale(ragioneSocialeFilterTextBox.Text);
        }

        private void descrizioneProdottoFilterTb_TextChanged(object sender, EventArgs e)
        {
            _anapropr.FilterProdottoByDescrizione(descrizioneProdottoFilterTb.Text);
        }

    }
}
