﻿using System;
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
using CrystalDecisions.CrystalReports.Engine;
using GestioneViaggi.Reports;

namespace GestioneViaggi
{
    public delegate void ManipulateDateRangeDelegate(DateTime from, DateTime to);

    public partial class MainForm : Form, IAnagraficaFornitoriView, IElencoViaggiView, IRiepiloghiView
    {
        private Dal _dal;
        private AnagraficaFornitoriVModel _anaforvm = null;
        private AnagraficaFornitoriPresenter _anaforpr = null;
        private AnagraficaProdottiVModel _anaprovm = null;
        private AnagraficaProdottiPresenter _anapropr = null;
        private ElencoViaggiPresenter _viaggipr = null;
        private ElencoViaggiVModel _viaggivm = null;
        private ViaggioEditPresenter _viaggioeditpr = null;
        private StatisticheVModel _riepilogovm;
        private RiepiloghiPresenter _riepilogopr = null;

        public MainForm()
        {
            InitializeComponent();
            Setup();
            //testData();
        }

        private long PickCartellino(List<long> cartellini)
        {
            int idx = new Random(DateTime.Now.Millisecond).Next(1, cartellini.Count());
            long cartellino = cartellini[idx - 1];
            cartellini.RemoveAt(idx - 1);
            return cartellino;
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

            Random rndDate = new Random(DateTime.Now.Millisecond);
            List<Fornitore> fornitori = new List<Fornitore>();
            Fornitore c;
            Prodotto p;
            foreach (int i in Enumerable.Range(1, 10))
            {
                c = new Fornitore
                {
                    RagioneSociale = "Fornitore di prova " + DateTime.Now.Millisecond.ToString()
                };
                c.Id = Dal.connection.Insert(c);
                fornitori.Add(c);

                p = new Prodotto
                {
                    Descrizione = "Prodotto di prova " + DateTime.Now.Millisecond.ToString(),
                    FornitoreId = rndDate.Next(1,10),
                    ValidoDal = DateTime.Today,
                    ValidoAl = DateTime.Today.AddDays(rndDate.Next(1,10)),
                    Costo = Decimal.Parse(new Random(DateTime.Now.Millisecond).Next(100).ToString())
                };
                p.Id = Dal.connection.Insert(p);
            }

            List<Viaggio> viaggi = new List<Viaggio>();
            List<long> cartellini = new List<long>();
            foreach (long x in Enumerable.Range(1, 1000))
                cartellini.Add(x);

            rndDate = new Random(DateTime.Now.Millisecond);
            foreach (int j in Enumerable.Range(1, 1000))
            {
                Viaggio v = new Viaggio
                {
                    Cartellino = PickCartellino(cartellini),
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
            _riepilogopr = new RiepiloghiPresenter(this);
            _riepilogopr.RiepilogoDateRangeInvalidError += new RiepilogDateRangeInvalidDelegate(_riepilogopr_RiepilogoDateRangeInvalidError);
            _riepilogopr.DatiInsufficientiError += new DatiInsufficientiDelegate(_riepilogopr_DatiInsufficientiError);
            _anaforpr = new AnagraficaFornitoriPresenter(this as IAnagraficaFornitoriView);
            _anaforpr.onFornitoriRefreshed += new FornitoriRefreshedDelegate(_anaforpr_onFornitoriRefreshed);
            _anaforpr.onFornitoriSaveError += new NotifyMessagesDelegate(_anaforpr_onFornitoriSaveError);
            _anaforpr.onFornitoriRemoveError += new NotifyMessagesDelegate(_anaforpr_onFornitoriSaveError);
            _anaforpr.onProductRemoveError += new NotifyMessagesDelegate(_anaforpr_onFornitoriSaveError);
            _anaforpr.refreshFornitori();
            _viaggipr = new ElencoViaggiPresenter(this as IElencoViaggiView);
            _viaggipr.onViaggiRefreshed += new ViaggiRefreshedDelegate(_viaggipr_onViaggiRefreshed);
            _viaggipr.onViaggiFilterFailed += new NotifyMessagesMapDelegate(_viaggipr_onViaggiFilterFailed);
            _viaggipr.refreshViaggi();
        }

        private void terminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
            _riepilogopr.SetFornitori(elencoFornitoriBs.DataSource as List<Fornitore>);
            riepilogoFornitoriBs.DataSource = null;
            riepilogoFornitoriBs.DataSource = _riepilogovm.fornitori;
            riepilogoProdottiBs.DataSource = null;
            riepilogoProdottiBs.DataSource = _riepilogovm.prodotti;
            riepilogoBs.ResetBindings(false);
            _riepilogopr.SetFornitore(null);
        }

        void _anaforpr_onFornitoriSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages), "Anagrafica fornitori", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void elencoFornitoriBs_CurrentChanged(object sender, EventArgs e)
        {
            // 2014.06.03 - Dobbiamo associare il listino associato al fornitore
            Fornitore f = (elencoFornitoriBs.Current as Fornitore);
            if (f != null)
            {
                _anaforvm.current = f.Clone();
                currentFornitoreBs.DataSource = _anaforvm.current;
                listinoBs.DataSource = _anaforvm.currentListino;
                listinoDg.DataSource = listinoBs;
                listinoBs.ResetBindings(false);
                anagraficaFornitoriVMBs.ResetBindings(false);
            }
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
            if (MessageBox.Show("Procedere con la rimozione del fornitore selezionato?", "Rimozione fornitore", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

        private void listinoBs_CurrentChanged(object sender, EventArgs e)
        {
            _anaforvm.currentProdotto = (listinoBs.Current as Prodotto);
        }

        private void eliminaProdottoBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedo con l'eliminazione del prodotto selezionato?", "Elimina prodotto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            _anaforpr.DeleteProduct(_anaforvm.currentProdotto);
        }

        void _prodottoeditpr_onProdottoSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages), "Listino prodotti", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void nuovoProdottoBtn_Click(object sender, EventArgs e)
        {
            using (ProdottoEditView form = new ProdottoEditView())
            {
                using (ProdottoEditPresenter _prodottoeditpr = new ProdottoEditPresenter(form))
                {
                    _prodottoeditpr.SetFornitore(_anaforvm.current);
                    _prodottoeditpr.onProdottoSaveError += new NotifyMessagesDelegate(_prodottoeditpr_onProdottoSaveError);
                    _prodottoeditpr.SetCurrentProdotto(new Prodotto());
                    form.Text = "Inserimento nuovo prodotto";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _anaforpr.refreshFornitori();
                        if (ProdottoValidationService.isValid(_prodottoeditpr.vmodel.current))
                            MessageBox.Show("Operazione completata!", "Nuovo prodotto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void editProdottoBtn_Click(object sender, EventArgs e)
        {
            using (ProdottoEditView form = new ProdottoEditView())
            {
                using (ProdottoEditPresenter _prodottoeditpr = new ProdottoEditPresenter(form))
                {
                    _prodottoeditpr.SetFornitore(_anaforvm.current);
                    _prodottoeditpr.onProdottoSaveError += new NotifyMessagesDelegate(_prodottoeditpr_onProdottoSaveError);
                    _prodottoeditpr.SetCurrentProdotto(_anaforvm.currentProdotto);
                    form.Text = "Modifica prodotto";
                    form.ShowDialog();
                }
                _anaforpr.refreshFornitori();
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
            if (elencoViaggiDg.Rows[e.RowIndex] == null)
                return;
            try
            {
                if (elencoViaggiDg.Columns[e.ColumnIndex].DataPropertyName.Contains("."))
                {
                    e.Value = ViewHelpers.EvaluateValue(elencoViaggiDg.Rows[e.RowIndex].DataBoundItem, elencoViaggiDg.Columns[e.ColumnIndex].DataPropertyName);
                }
            }
            catch (Exception)
            {
            }
        }

        private void CalcolaIntervalloDaMese(ComboBox cb, ManipulateDateRangeDelegate fn)
        {
            if (cb.Items.Contains(cb.Text))
            {
                int idx = cb.Items.IndexOf(cb.Text);
                DateTime from, to;
                int anno = DateTime.Today.Year;
                from = DateTime.Parse(String.Format("1/{0}/{1}", idx + 1, anno));
                to = from.AddMonths(1).AddDays(-1);
                fn(from, to);
            }
        }

        private void viaggioMeseFilterCb_TextChanged(object sender, EventArgs e)
        {
            CalcolaIntervalloDaMese(viaggioMeseFilterCb, _viaggipr.SetDateFilterFromTo);
            elencoViaggiVMBs.ResetBindings(false);
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
                _viaggipr.refreshViaggi();
            }
        }

        private void eliminaViaggioBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sicuro di voler eliminare il viaggio selezionato?", "Elimina viaggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            _viaggipr.EliminaViaggioSelezionato();
            _viaggipr.refreshViaggi();            
        }

        //End Viaggi

        private void riepilogoGeneraleBtn_Click(object sender, EventArgs e)
        {
            _riepilogopr.RiepilogoGenerale();
            riepilogoLogTb.Text += String.Format("Riepilogo per il fornitore: {0} e prodotto: {1} Dal {2} Al {3}\r\n", _riepilogovm.fornitore.RagioneSociale, _riepilogovm.prodotto.Descrizione, _riepilogovm.FiltroDal.Date.ToShortDateString(), _riepilogovm.FiltroAl.Date.ToShortDateString());
            foreach (String s in _riepilogovm.totalizzatori.Dump())
                riepilogoLogTb.Text += s + "\r\n";
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@".\Reports\RiepilogoGeneraleReport.rpt");
            rpt.SetDataSource(_riepilogovm.dataset);
            using (ReportViewer rviewer = new ReportViewer())
            {
                rviewer.SetReport(rpt);
                rviewer.ShowDialog();
            }
        }

        void IRiepiloghiView.SetVModel(StatisticheVModel model)
        {
            _riepilogovm = model;
            riepilogoBs.DataSource = _riepilogovm;
        }

        private void riepilogoFornitoriBs_CurrentChanged(object sender, EventArgs e)
        {
            //_riepilogopr.SetFornitore(riepilogoFornitoriBs.Current as Fornitore);
            //riepilogoProdottiBs.ResetBindings(false);
        }

        private void riepilogoProdottiBs_CurrentChanged(object sender, EventArgs e)
        {
            _riepilogopr.SetProdotto(riepilogoProdottiBs.Current as Prodotto);
        }

        private void riepilogoMeseCb_TextChanged(object sender, EventArgs e)
        {
            CalcolaIntervalloDaMese(riepilogoMeseCb, _riepilogopr.SetDateFilterFromTo);
        }

        void _riepilogopr_RiepilogoDateRangeInvalidError(DateTime from, DateTime to)
        {
            MessageBox.Show("L'intervallo specificato NON è valido!", "Intervallo date", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void _riepilogopr_DatiInsufficientiError()
        {
            MessageBox.Show("Non sono stati individuati viaggi con i parametri impostati!", "Calcolo statistiche", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pulisciLogBtn_Click(object sender, EventArgs e)
        {
            riepilogoLogTb.Text = "";
        }

        private void riepilogoFornitoreCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _riepilogopr.SetFornitore(riepilogoFornitoriBs.Current as Fornitore);
            riepilogoProdottiBs.ResetBindings(false);
        }

    }
}
