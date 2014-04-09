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
    public partial class MainForm : Form, IAnagraficaFornitoriView
    {
        private Dal _dal;
        private AnagraficaFornitoriVModel _anaclievm = null;
        private AnagraficaFornitoriPresenter _anacliepr = null;

        public MainForm()
        {
            InitializeComponent();
            Setup();
            testData();
        }

        private void testData()
        {
            Dal.connection.Open();
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

            List<Viaggio> viaggi = ViaggiService.All();
            foreach (Viaggio vv in viaggi) { MessageBox.Show(vv.Fornitore.RagioneSociale); }

            //String sql = @"Select * from Viaggio left outer join RigaViaggio on Viaggio.Id = RigaViaggio.ViaggioId";
            //List<Viaggio> vs = Dal.connection.QueryParentChild<Viaggio, RigaViaggio, long>(sql,
            //    viaggio => viaggio.Id,
            //    viaggio => viaggio.Righe,
            //    splitOn: "Id").ToList();

//            sql = @"select * from Viaggio
//                        inner join RigaViaggio on RigaViaggio.ViaggioId = Viaggio.Id
//                        inner join Fornitore on Fornitore.Id = Viaggio.FornitoreId
//                        inner join Prodotto on Prodotto.Id = RigaViaggio.ProdottoId";
//            Viaggio v3 =Dal.connection.Query<Viaggio, RigaViaggio, Prodotto, Fornitore>(sql).First();
//            MessageBox.Show(v3.TargaAutomezzo);

            Dal.connection.Close();
        }

        private void Setup()
        {
            try
            {
                Dal.ensureDb();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Errore configurazione DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.DoEvents();
                Process.GetCurrentProcess().Kill();
            }
        }

        private void terminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Text = String.Format("Gestione Viaggi - V{0}", Application.ProductVersion);
            _anacliepr = new AnagraficaFornitoriPresenter(this as IAnagraficaFornitoriView);
            _anacliepr.onFornitoriRefreshed += new FornitoriRefreshedDelegate(_anacliepr_onFornitoriRefreshed);
            _anacliepr.onFornitoriSaveError += new NotifyMessagesDelegate(_anacliepr_onFornitoriSaveError);
            _anacliepr.onFornitoriRemoveError += new NotifyMessagesDelegate(_anacliepr_onFornitoriSaveError);
            _anacliepr.refreshFornitori();
        }

        void _anacliepr_onFornitoriSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages));
        }

        void _anacliepr_onFornitoriRefreshed(List<Fornitore> Fornitori)
        {
            elencoFornitoriBs.DataSource = Fornitori;
            elencoFornitoriDg.DataSource = elencoFornitoriBs;
        }

        void IAnagraficaFornitoriView.SetVModel(AnagraficaFornitoriVModel model)
        {
            _anaclievm = model;
            anagraficaFornitoriVMBs.DataSource = _anaclievm;
        }

        private void elencoFornitoriBs_CurrentChanged(object sender, EventArgs e)
        {
            _anaclievm.currentClient = (elencoFornitoriBs.Current as Fornitore).Clone();
            currentFornitoreBs.DataSource = _anaclievm.currentClient;
            anagraficaFornitoriVMBs.ResetBindings(false);
        }

        private void salvaBtn_Click(object sender, EventArgs e)
        {
            _anacliepr.SaveClient(_anaclievm.currentClient);
        }

        private void nuovoBtn_Click(object sender, EventArgs e)
        {
            _anaclievm.currentClient = new Fornitore();
            currentFornitoreBs.DataSource = _anaclievm.currentClient;
            anagraficaFornitoriVMBs.ResetBindings(false);
        }

        private void eliminaBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Procedere con la rimozione del cliente selezionato?", "Rimozione cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                _anacliepr.RemoveClient(_anaclievm.currentClient);
            }
        }
    }
}
