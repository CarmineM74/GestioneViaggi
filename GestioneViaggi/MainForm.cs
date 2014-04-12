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
        private ViaggioEditPresenter _viaggioeditpr = null;

        public MainForm()
        {
            InitializeComponent();
            Setup();
            //testData();
        }

        private void testData()
        {
            List<String> conducenti = new List<string>();
            conducenti.Add("Carmine Moleti");
            conducenti.Add("Francesco Moleti");
            conducenti.Add("Franco Melardo");
            conducenti.Add("Carmine Della Gatta");
            conducenti.Add("Anna Del Prete");
            conducenti.Add("Vito Del Prete");

            List<String> targhe = new List<string>();
            targhe.Add("EF158NN");
            targhe.Add("BW214CZ");
            targhe.Add("BX762ZY");
            targhe.Add("FC888DQ");

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

            List<Viaggio> viaggi = new List<Viaggio>();
            Random rndDate = new Random(DateTime.Now.Millisecond);
            foreach (int j in Enumerable.Range(1, 1000))
            {
                Viaggio v = new Viaggio
                {
                    FornitoreId = new Random(DateTime.Now.Millisecond).Next(1, 10),
                    Data = DateTime.Now.AddDays(rndDate.Next(600)*-1),
                    TargaAutomezzo = targhe[rndDate.Next(0,targhe.Count-1)],
                    Conducente = conducenti[rndDate.Next(0,conducenti.Count-1)]
                };
                viaggi.Add(v);
            }
            viaggi.Sort((v1, v2) => v1.Data.CompareTo(v2.Data));
            foreach (Viaggio v in viaggi)
            {
                v.Id = Dal.connection.Insert(v);
            }

            rndDate = new Random(DateTime.Now.Millisecond);
            foreach (int j in Enumerable.Range(1, 1000))
            {
                foreach (int i in Enumerable.Range(1, 5))
                {
                    p = Dal.db.Prodotti.Get(rndDate.Next(1, 10));
                    Decimal pesata = Decimal.Parse(rndDate.Next(10000).ToString());
                    RigaViaggio rv = new RigaViaggio
                    {
                        ViaggioId = viaggi[j-1].Id,
                        ProdottoId = p.Id,
                        Pesata = pesata,
                        CaloPesoPercentuale = rndDate.Next(100),
                        Costo = p.Costo * pesata
                    };
                    Dal.connection.Insert(rv);
                }
            }
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
            _anapropr.onProdottiSaveError += new NotifyMessagesDelegate(_anapropr_onProdottiSaveError);
            _anapropr.onProdottiRemoveError += new NotifyMessagesDelegate(_anapropr_onProdottiSaveError);
            _anapropr.refreshProdotti();
            _viaggipr = new ElencoViaggiPresenter(this as IElencoViaggiView);
            _viaggipr.onViaggiRefreshed += new ViaggiRefreshedDelegate(_viaggipr_onViaggiRefreshed);
            _viaggipr.onViaggiFilterFailed += new NotifyMessagesMapDelegate(_viaggipr_onViaggiFilterFailed);
            _viaggipr.refreshViaggi();
        }

        //Prodotti

        void _anapropr_onProdottiSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages),"Anagrafica prodotti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void terminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            elencoProdottiGb.Text = String.Format("Elenco prodotti: {0}",prodotti.Count());
        }

        private void elencoProdottiBs_CurrentChanged(object sender, EventArgs e)
        {
            _anaprovm.current = (elencoProdottiBs.Current as Prodotto).Clone();
            currentProdottoBs.DataSource = _anaprovm.current;
            anagraficaProdottiVMBs.ResetBindings(false);
        }

        private void descrizioneProdottoFilterTb_TextChanged(object sender, EventArgs e)
        {
            _anapropr.FilterProdottoByDescrizione(descrizioneProdottoFilterTb.Text);
        }

        private void nuovoProdottoBtn_Click(object sender, EventArgs e)
        {
            _anaprovm.current = new Prodotto();
            currentProdottoBs.DataSource = _anaprovm.current;
            anagraficaProdottiVMBs.ResetBindings(false);
        }

        private void salvaProdottoBtn_Click(object sender, EventArgs e)
        {
            _anapropr.Save(_anaprovm.current);
        }

        private void eliminaProdottoBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedere con la rimozione del prodotto selezionato?", "Rimozione prodotto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _anapropr.Remove(_anaprovm.current);
            }
        }

        //End Prodotti

        //Fornitori
        void IAnagraficaFornitoriView.SetVModel(AnagraficaFornitoriVModel model)
        {
            _anaforvm = model;
            anagraficaFornitoriVMBs.DataSource = _anaforvm;
        }

        void _anaforpr_onFornitoriRefreshed(List<Fornitore> fornitori)
        {
            elencoFornitoriBs.DataSource = fornitori;
            elencoFornitoriDg.DataSource = elencoFornitoriBs;
            elencoFornitoriGb.Text = String.Format("Elenco fornitori: {0}", fornitori.Count());
        }

        void _anaforpr_onFornitoriSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages), "Anagrafica fornitori", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ragioneSocialeFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            _anaforpr.FilterFornitoreByRagioneSociale(ragioneSocialeFilterTextBox.Text);
        }

        private void elencoFornitoriDg_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
            {
                e.CellStyle.BackColor = (e.RowIndex % 2) == 0 ? Color.White : Color.AntiqueWhite;
            }
        }

        //End Fornitori

        //Viaggi
        void _viaggipr_onViaggiFilterFailed(Dictionary<string, List<string>> messages)
        {
            //List<String> errori = messages.Select(kvp => String.Format("{0}: {1}\n", kvp.Key, kvp.Value.Aggregate((v,a) => a += v + ","))).ToList();
            //String errore = errori.Aggregate((v, a) => a += v);
            if (messages.Keys.Contains("data"))
            {
                String errore = messages["data"].Aggregate((v, a) => a += "- " + v + "\n");
                MessageBox.Show(errore, "Errore filtro viaggi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            elencoViaggiGb.Text = String.Format("Elenco viaggi: {0}",viaggi.Count());
        }

        private void elencoViaggiDg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (elencoViaggiDg.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
            {
                e.Value = ViewHelpers.EvaluateValue(elencoViaggiDg.Rows[e.RowIndex].DataBoundItem, elencoViaggiDg.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private void viaggioMeseFilterCb_TextChanged(object sender, EventArgs e)
        {
            if (viaggioMeseFilterCb.Items.Contains(viaggioMeseFilterCb.Text))
            {
                int idx = viaggioMeseFilterCb.Items.IndexOf(viaggioMeseFilterCb.Text);
                DateTime from, to;
                int anno = DateTime.Today.Year;
                from = DateTime.Parse(String.Format("1/{0}/{1}", idx + 1, anno));
                to = from.AddMonths(1).AddDays(-1);
                _viaggipr.SetDateFilterFromTo(from, to);
                elencoViaggiVMBs.ResetBindings(false);
            }
        }

        private void viaggiRimuoviFiltroBtn_Click(object sender, EventArgs e)
        {
            _viaggipr.ClearFilter();
            viaggioMeseFilterCb.Text = "";
            elencoViaggiVMBs.ResetBindings(false);
        }

        private void viaggiApplicaFiltroBtn_Click(object sender, EventArgs e)
        {
            _viaggipr.ApplyFilter();
        }

        private void elencoViaggiDg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _viaggipr.ImpostaViaggioCorrente(elencoViaggiBs.Current as Viaggio);
        }

        void _viaggioeditpr_onViaggioSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages), "Elenco viaggi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nuovoViaggioBtn_Click(object sender, EventArgs e)
        {
            using (ViaggioEditView form = new ViaggioEditView())
            {
                using (_viaggioeditpr = new ViaggioEditPresenter(form))
                {
                    _viaggioeditpr.onViaggioSaveError += new NotifyMessagesDelegate(_viaggioeditpr_onViaggioSaveError);
                    _viaggioeditpr.SetCurrentViaggio(new Viaggio());
                    form.Text = "Inserimento nuovo viaggio";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _viaggipr.refreshViaggi();
                        MessageBox.Show("Operazione completata!", "Nuovo viaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void modificaViaggioBtn_Click(object sender, EventArgs e)
        {
            using (ViaggioEditView form = new ViaggioEditView())
            {
                using (_viaggioeditpr = new ViaggioEditPresenter(form))
                {
                    _viaggioeditpr.onViaggioSaveError += new NotifyMessagesDelegate(_viaggioeditpr_onViaggioSaveError);
                    _viaggioeditpr.SetCurrentViaggio(_viaggivm.current);
                    form.Text = "Modifica viaggio";
                    form.ShowDialog();
                }
            }
        }

        //End Viaggi
    }
}
