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
    public partial class MainForm : Form, IAnagraficaClientiView
    {
        private Dal _dal;
        private AnagraficaClientiVModel _anaclievm = null;
        private AnagraficaClientiPresenter _anacliepr = null;

        public MainForm()
        {
            InitializeComponent();
            Setup();
            //foreach (int i in Enumerable.Range(1, 10))
            //{
            //    testData();
            //}
        }

        private void testData()
        {
            Dal.connection.Open();

            Cliente c = new Cliente
            {
                RagioneSociale = "Cliente di prova " + DateTime.Now.Millisecond.ToString(),
                Tariffa = Decimal.Parse(new Random(DateTime.Now.Millisecond).Next(100).ToString())
            };
            c.Id = Dal.connection.Insert(c);

            Prodotto p = new Prodotto
            {
                Descrizione = "Prodotto di prova " + DateTime.Now.Millisecond.ToString()
            };
            p.Id = Dal.connection.Insert(p);

            Viaggio v = new Viaggio
            {
                ClienteId = c.Id,
                ProdottoId = p.Id,
                Data = DateTime.Now,
                TargaAutomezzo = "EF158NN",
                Conducente = "Carmine Moleti",
                Pesata = Decimal.Parse(new Random(DateTime.Now.Millisecond).Next(10000).ToString()),
                CaloPesoPercentuale = new Random(DateTime.Now.Millisecond).Next(100)
            };
            v.Id = Dal.connection.Insert(v);

//            String sql = @"select * from Viaggio
//                        inner join Cliente on Cliente.Id = Viaggio.ClienteId
//                        inner join Prodotto on Prodotto.Id = Viaggio.ProdottoId";
//            Viaggio viaggio = Dal.connection.Query<Viaggio, Cliente, Prodotto>(sql).First();

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
            _anacliepr = new AnagraficaClientiPresenter(this as IAnagraficaClientiView);
            _anacliepr.onClientiRefreshed += new ClientiRefreshedDelegate(_anacliepr_onClientiRefreshed);
            _anacliepr.onClientiSaveError += new NotifyMessagesDelegate(_anacliepr_onClientiSaveError);
            _anacliepr.onClientiRemoveError += new NotifyMessagesDelegate(_anacliepr_onClientiSaveError);
            _anacliepr.refreshClienti();
        }

        void _anacliepr_onClientiSaveError(List<string> messages)
        {
            MessageBox.Show(String.Join("\n", messages));
        }

        void _anacliepr_onClientiRefreshed(List<Cliente> clienti)
        {
            elencoClientiBs.DataSource = clienti;
            elencoClientiDg.DataSource = elencoClientiBs;
        }

        void IAnagraficaClientiView.SetVModel(AnagraficaClientiVModel model)
        {
            _anaclievm = model;
            anagraficaClientiVMBs.DataSource = _anaclievm;
        }

        private void elencoClientiBs_CurrentChanged(object sender, EventArgs e)
        {
            _anaclievm.currentClient = (elencoClientiBs.Current as Cliente).Clone();
            currentClientBs.DataSource = _anaclievm.currentClient;
            anagraficaClientiVMBs.ResetBindings(false);
        }

        private void salvaBtn_Click(object sender, EventArgs e)
        {
            _anacliepr.SaveClient(_anaclievm.currentClient);
        }

        private void nuovoBtn_Click(object sender, EventArgs e)
        {
            _anaclievm.currentClient = new Cliente();
            currentClientBs.DataSource = _anaclievm.currentClient;
            anagraficaClientiVMBs.ResetBindings(false);
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
