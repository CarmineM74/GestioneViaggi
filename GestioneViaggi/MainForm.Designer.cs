namespace GestioneViaggi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.FornitoriTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.eliminaFornitoreBtn = new System.Windows.Forms.Button();
            this.salvaFornitoreBtn = new System.Windows.Forms.Button();
            this.nuovoFornitoreBtn = new System.Windows.Forms.Button();
            this.ragioneSocialeTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.elencoFornitoriDg = new System.Windows.Forms.DataGridView();
            this.ragioneSocialeFilterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prodottiTabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.elencoProdottiDg = new System.Windows.Forms.DataGridView();
            this.viaggiTabPage = new System.Windows.Forms.TabPage();
            this.nuovoViaggioBtn = new System.Windows.Forms.Button();
            this.elencoViaggiDg = new System.Windows.Forms.DataGridView();
            this.elencoViaggiVMBs = new System.Windows.Forms.BindingSource(this.components);
            this.Fornitore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.currentFornitoreBs = new System.Windows.Forms.BindingSource(this.components);
            this.anagraficaFornitoriVMBs = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elencoFornitoriBs = new System.Windows.Forms.BindingSource(this.components);
            this.anagraficaProdottiVMBs = new System.Windows.Forms.BindingSource(this.components);
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elencoProdottiBs = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targaAutomezzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conducenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elencoViaggiBs = new System.Windows.Forms.BindingSource(this.components);
            this.currentProdottoBs = new System.Windows.Forms.BindingSource(this.components);
            this.descrizioneProdottoTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.FornitoriTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoFornitoriDg)).BeginInit();
            this.prodottiTabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoProdottiDg)).BeginInit();
            this.viaggiTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoViaggiDg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoViaggiVMBs)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFornitoreBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anagraficaFornitoriVMBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoFornitoriBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anagraficaProdottiVMBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoProdottiBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoViaggiBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentProdottoBs)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminaToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // terminaToolStripMenuItem
            // 
            this.terminaToolStripMenuItem.Name = "terminaToolStripMenuItem";
            this.terminaToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.terminaToolStripMenuItem.Text = "Termina";
            this.terminaToolStripMenuItem.Click += new System.EventHandler(this.terminaToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.FornitoriTabPage);
            this.mainTabControl.Controls.Add(this.prodottiTabPage);
            this.mainTabControl.Controls.Add(this.viaggiTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 24);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(784, 538);
            this.mainTabControl.TabIndex = 1;
            // 
            // FornitoriTabPage
            // 
            this.FornitoriTabPage.Controls.Add(this.groupBox2);
            this.FornitoriTabPage.Controls.Add(this.groupBox1);
            this.FornitoriTabPage.Location = new System.Drawing.Point(4, 22);
            this.FornitoriTabPage.Name = "FornitoriTabPage";
            this.FornitoriTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FornitoriTabPage.Size = new System.Drawing.Size(776, 512);
            this.FornitoriTabPage.TabIndex = 0;
            this.FornitoriTabPage.Text = "Anagrafica Fornitori";
            this.FornitoriTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.eliminaFornitoreBtn);
            this.groupBox2.Controls.Add(this.salvaFornitoreBtn);
            this.groupBox2.Controls.Add(this.nuovoFornitoreBtn);
            this.groupBox2.Controls.Add(this.ragioneSocialeTb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(401, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 492);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dettaglio fornitore";
            // 
            // eliminaFornitoreBtn
            // 
            this.eliminaFornitoreBtn.Location = new System.Drawing.Point(283, 463);
            this.eliminaFornitoreBtn.Name = "eliminaFornitoreBtn";
            this.eliminaFornitoreBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminaFornitoreBtn.TabIndex = 7;
            this.eliminaFornitoreBtn.Text = "Elimina";
            this.eliminaFornitoreBtn.UseVisualStyleBackColor = true;
            this.eliminaFornitoreBtn.Click += new System.EventHandler(this.eliminaFornitoreBtn_Click);
            // 
            // salvaFornitoreBtn
            // 
            this.salvaFornitoreBtn.Location = new System.Drawing.Point(99, 463);
            this.salvaFornitoreBtn.Name = "salvaFornitoreBtn";
            this.salvaFornitoreBtn.Size = new System.Drawing.Size(75, 23);
            this.salvaFornitoreBtn.TabIndex = 6;
            this.salvaFornitoreBtn.Text = "Salva";
            this.salvaFornitoreBtn.UseVisualStyleBackColor = true;
            this.salvaFornitoreBtn.Click += new System.EventHandler(this.salvaFornitoreBtn_Click);
            // 
            // nuovoFornitoreBtn
            // 
            this.nuovoFornitoreBtn.Location = new System.Drawing.Point(9, 463);
            this.nuovoFornitoreBtn.Name = "nuovoFornitoreBtn";
            this.nuovoFornitoreBtn.Size = new System.Drawing.Size(75, 23);
            this.nuovoFornitoreBtn.TabIndex = 5;
            this.nuovoFornitoreBtn.Text = "Nuovo";
            this.nuovoFornitoreBtn.UseVisualStyleBackColor = true;
            this.nuovoFornitoreBtn.Click += new System.EventHandler(this.nuovoFornitoreBtn_Click);
            // 
            // ragioneSocialeTb
            // 
            this.ragioneSocialeTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentFornitoreBs, "RagioneSociale", true));
            this.ragioneSocialeTb.Location = new System.Drawing.Point(6, 32);
            this.ragioneSocialeTb.Name = "ragioneSocialeTb";
            this.ragioneSocialeTb.Size = new System.Drawing.Size(352, 20);
            this.ragioneSocialeTb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ragione Sociale";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.elencoFornitoriDg);
            this.groupBox1.Controls.Add(this.ragioneSocialeFilterTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 498);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elenco Fornitori";
            // 
            // elencoFornitoriDg
            // 
            this.elencoFornitoriDg.AllowUserToAddRows = false;
            this.elencoFornitoriDg.AllowUserToDeleteRows = false;
            this.elencoFornitoriDg.AutoGenerateColumns = false;
            this.elencoFornitoriDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elencoFornitoriDg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.elencoFornitoriDg.DataSource = this.elencoFornitoriBs;
            this.elencoFornitoriDg.Location = new System.Drawing.Point(9, 58);
            this.elencoFornitoriDg.Name = "elencoFornitoriDg";
            this.elencoFornitoriDg.ReadOnly = true;
            this.elencoFornitoriDg.Size = new System.Drawing.Size(352, 434);
            this.elencoFornitoriDg.TabIndex = 2;
            // 
            // ragioneSocialeFilterTextBox
            // 
            this.ragioneSocialeFilterTextBox.Location = new System.Drawing.Point(9, 32);
            this.ragioneSocialeFilterTextBox.Name = "ragioneSocialeFilterTextBox";
            this.ragioneSocialeFilterTextBox.Size = new System.Drawing.Size(352, 20);
            this.ragioneSocialeFilterTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtra per Ragione Sociale";
            // 
            // prodottiTabPage
            // 
            this.prodottiTabPage.Controls.Add(this.groupBox4);
            this.prodottiTabPage.Controls.Add(this.groupBox3);
            this.prodottiTabPage.Location = new System.Drawing.Point(4, 22);
            this.prodottiTabPage.Name = "prodottiTabPage";
            this.prodottiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.prodottiTabPage.Size = new System.Drawing.Size(776, 512);
            this.prodottiTabPage.TabIndex = 1;
            this.prodottiTabPage.Text = "Anagrafica prodotti";
            this.prodottiTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.elencoProdottiDg);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 498);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Elenco prodotti";
            // 
            // elencoProdottiDg
            // 
            this.elencoProdottiDg.AllowUserToAddRows = false;
            this.elencoProdottiDg.AllowUserToDeleteRows = false;
            this.elencoProdottiDg.AutoGenerateColumns = false;
            this.elencoProdottiDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elencoProdottiDg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descrizioneDataGridViewTextBoxColumn,
            this.costoDataGridViewTextBoxColumn});
            this.elencoProdottiDg.DataSource = this.elencoProdottiBs;
            this.elencoProdottiDg.Location = new System.Drawing.Point(6, 58);
            this.elencoProdottiDg.Name = "elencoProdottiDg";
            this.elencoProdottiDg.ReadOnly = true;
            this.elencoProdottiDg.Size = new System.Drawing.Size(352, 434);
            this.elencoProdottiDg.TabIndex = 3;
            // 
            // viaggiTabPage
            // 
            this.viaggiTabPage.Controls.Add(this.nuovoViaggioBtn);
            this.viaggiTabPage.Controls.Add(this.elencoViaggiDg);
            this.viaggiTabPage.Location = new System.Drawing.Point(4, 22);
            this.viaggiTabPage.Name = "viaggiTabPage";
            this.viaggiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.viaggiTabPage.Size = new System.Drawing.Size(776, 512);
            this.viaggiTabPage.TabIndex = 2;
            this.viaggiTabPage.Text = "Storico viaggi";
            this.viaggiTabPage.UseVisualStyleBackColor = true;
            // 
            // nuovoViaggioBtn
            // 
            this.nuovoViaggioBtn.Location = new System.Drawing.Point(6, 483);
            this.nuovoViaggioBtn.Name = "nuovoViaggioBtn";
            this.nuovoViaggioBtn.Size = new System.Drawing.Size(75, 23);
            this.nuovoViaggioBtn.TabIndex = 1;
            this.nuovoViaggioBtn.Text = "Nuovo";
            this.nuovoViaggioBtn.UseVisualStyleBackColor = true;
            // 
            // elencoViaggiDg
            // 
            this.elencoViaggiDg.AllowUserToAddRows = false;
            this.elencoViaggiDg.AllowUserToDeleteRows = false;
            this.elencoViaggiDg.AutoGenerateColumns = false;
            this.elencoViaggiDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elencoViaggiDg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.Fornitore,
            this.targaAutomezzoDataGridViewTextBoxColumn,
            this.conducenteDataGridViewTextBoxColumn});
            this.elencoViaggiDg.DataSource = this.elencoViaggiBs;
            this.elencoViaggiDg.Location = new System.Drawing.Point(6, 73);
            this.elencoViaggiDg.Name = "elencoViaggiDg";
            this.elencoViaggiDg.ReadOnly = true;
            this.elencoViaggiDg.Size = new System.Drawing.Size(762, 399);
            this.elencoViaggiDg.TabIndex = 0;
            this.elencoViaggiDg.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.elencoViaggiDg_CellFormatting);
            // 
            // Fornitore
            // 
            this.Fornitore.DataPropertyName = "Fornitore.RagioneSociale";
            this.Fornitore.HeaderText = "Fornitore";
            this.Fornitore.Name = "Fornitore";
            this.Fornitore.ReadOnly = true;
            this.Fornitore.Width = 200;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.descrizioneProdottoTb);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Location = new System.Drawing.Point(391, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 498);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dettaglio prodotto";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Elimina";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Salva";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 463);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Nuovo";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // currentFornitoreBs
            // 
            this.currentFornitoreBs.DataSource = typeof(GestioneViaggi.Model.Fornitore);
            // 
            // anagraficaFornitoriVMBs
            // 
            this.anagraficaFornitoriVMBs.DataSource = typeof(GestioneViaggi.ViewModel.AnagraficaFornitoriVModel);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RagioneSociale";
            this.dataGridViewTextBoxColumn1.HeaderText = "RagioneSociale";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 280;
            // 
            // elencoFornitoriBs
            // 
            this.elencoFornitoriBs.DataMember = "items";
            this.elencoFornitoriBs.DataSource = typeof(GestioneViaggi.ViewModel.AnagraficaFornitoriVModel);
            this.elencoFornitoriBs.CurrentChanged += new System.EventHandler(this.elencoFornitoriBs_CurrentChanged);
            // 
            // anagraficaProdottiVMBs
            // 
            this.anagraficaProdottiVMBs.DataSource = typeof(GestioneViaggi.ViewModel.AnagraficaProdottiVModel);
            // 
            // descrizioneDataGridViewTextBoxColumn
            // 
            this.descrizioneDataGridViewTextBoxColumn.DataPropertyName = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.HeaderText = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.Name = "descrizioneDataGridViewTextBoxColumn";
            this.descrizioneDataGridViewTextBoxColumn.ReadOnly = true;
            this.descrizioneDataGridViewTextBoxColumn.Width = 180;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            this.costoDataGridViewTextBoxColumn.DataPropertyName = "Costo";
            this.costoDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            this.costoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // elencoProdottiBs
            // 
            this.elencoProdottiBs.DataMember = "items";
            this.elencoProdottiBs.DataSource = typeof(GestioneViaggi.ViewModel.AnagraficaProdottiVModel);
            this.elencoProdottiBs.CurrentChanged += new System.EventHandler(this.elencoProdottiBs_CurrentChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 60;
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            this.dataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targaAutomezzoDataGridViewTextBoxColumn
            // 
            this.targaAutomezzoDataGridViewTextBoxColumn.DataPropertyName = "TargaAutomezzo";
            this.targaAutomezzoDataGridViewTextBoxColumn.HeaderText = "Targa Automezzo";
            this.targaAutomezzoDataGridViewTextBoxColumn.Name = "targaAutomezzoDataGridViewTextBoxColumn";
            this.targaAutomezzoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conducenteDataGridViewTextBoxColumn
            // 
            this.conducenteDataGridViewTextBoxColumn.DataPropertyName = "Conducente";
            this.conducenteDataGridViewTextBoxColumn.HeaderText = "Conducente";
            this.conducenteDataGridViewTextBoxColumn.Name = "conducenteDataGridViewTextBoxColumn";
            this.conducenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // elencoViaggiBs
            // 
            this.elencoViaggiBs.DataMember = "items";
            this.elencoViaggiBs.DataSource = typeof(GestioneViaggi.ViewModel.ElencoViaggiVModel);
            // 
            // currentProdottoBs
            // 
            this.currentProdottoBs.DataSource = typeof(GestioneViaggi.Model.Prodotto);
            // 
            // descrizioneProdottoTb
            // 
            this.descrizioneProdottoTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentProdottoBs, "Descrizione", true));
            this.descrizioneProdottoTb.Location = new System.Drawing.Point(6, 41);
            this.descrizioneProdottoTb.Name = "descrizioneProdottoTb";
            this.descrizioneProdottoTb.Size = new System.Drawing.Size(352, 20);
            this.descrizioneProdottoTb.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descrizione";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione Viaggi";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.FornitoriTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoFornitoriDg)).EndInit();
            this.prodottiTabPage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elencoProdottiDg)).EndInit();
            this.viaggiTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elencoViaggiDg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoViaggiVMBs)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentFornitoreBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anagraficaFornitoriVMBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoFornitoriBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anagraficaProdottiVMBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoProdottiBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoViaggiBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentProdottoBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminaToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage FornitoriTabPage;
        private System.Windows.Forms.TabPage prodottiTabPage;
        private System.Windows.Forms.TabPage viaggiTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ragioneSocialeFilterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView elencoFornitoriDg;
        private System.Windows.Forms.BindingSource elencoFornitoriBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn tariffaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource anagraficaFornitoriVMBs;
        private System.Windows.Forms.TextBox ragioneSocialeTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button eliminaFornitoreBtn;
        private System.Windows.Forms.Button salvaFornitoreBtn;
        private System.Windows.Forms.Button nuovoFornitoreBtn;
        private System.Windows.Forms.BindingSource currentFornitoreBs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource elencoProdottiBs;
        private System.Windows.Forms.DataGridView elencoProdottiDg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ragioneSocialeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource anagraficaProdottiVMBs;
        private System.Windows.Forms.BindingSource currentProdottoBs;
        private System.Windows.Forms.Button nuovoViaggioBtn;
        private System.Windows.Forms.DataGridView elencoViaggiDg;
        private System.Windows.Forms.BindingSource elencoViaggiBs;
        private System.Windows.Forms.BindingSource elencoViaggiVMBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornitore;
        private System.Windows.Forms.DataGridViewTextBoxColumn targaAutomezzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conducenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox descrizioneProdottoTb;
        private System.Windows.Forms.Label label3;
    }
}

