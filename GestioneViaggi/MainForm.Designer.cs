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
            this.clientiTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.elencoClientiDg = new System.Windows.Forms.DataGridView();
            this.ragioneSocialeFilterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prodottiTabPage = new System.Windows.Forms.TabPage();
            this.viaggiTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.ragioneSocialeTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tariffaMTb = new System.Windows.Forms.MaskedTextBox();
            this.nuovoBtn = new System.Windows.Forms.Button();
            this.salvaBtn = new System.Windows.Forms.Button();
            this.eliminaBtn = new System.Windows.Forms.Button();
            this.currentClientBs = new System.Windows.Forms.BindingSource(this.components);
            this.anagraficaClientiVMBs = new System.Windows.Forms.BindingSource(this.components);
            this.ragioneSocialeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tariffaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elencoClientiBs = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.clientiTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoClientiDg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentClientBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anagraficaClientiVMBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoClientiBs)).BeginInit();
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
            this.mainTabControl.Controls.Add(this.clientiTabPage);
            this.mainTabControl.Controls.Add(this.prodottiTabPage);
            this.mainTabControl.Controls.Add(this.viaggiTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 24);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(784, 538);
            this.mainTabControl.TabIndex = 1;
            // 
            // clientiTabPage
            // 
            this.clientiTabPage.Controls.Add(this.groupBox2);
            this.clientiTabPage.Controls.Add(this.groupBox1);
            this.clientiTabPage.Location = new System.Drawing.Point(4, 22);
            this.clientiTabPage.Name = "clientiTabPage";
            this.clientiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.clientiTabPage.Size = new System.Drawing.Size(776, 512);
            this.clientiTabPage.TabIndex = 0;
            this.clientiTabPage.Text = "Anagrafica clienti";
            this.clientiTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.eliminaBtn);
            this.groupBox2.Controls.Add(this.salvaBtn);
            this.groupBox2.Controls.Add(this.nuovoBtn);
            this.groupBox2.Controls.Add(this.tariffaMTb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ragioneSocialeTb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.anagraficaClientiVMBs, "isSelectedClient", true));
            this.groupBox2.Location = new System.Drawing.Point(401, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 411);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dettaglio cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.elencoClientiDg);
            this.groupBox1.Controls.Add(this.ragioneSocialeFilterTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 411);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elenco clienti";
            // 
            // elencoClientiDg
            // 
            this.elencoClientiDg.AllowUserToAddRows = false;
            this.elencoClientiDg.AllowUserToDeleteRows = false;
            this.elencoClientiDg.AutoGenerateColumns = false;
            this.elencoClientiDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elencoClientiDg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ragioneSocialeDataGridViewTextBoxColumn,
            this.tariffaDataGridViewTextBoxColumn});
            this.elencoClientiDg.DataSource = this.elencoClientiBs;
            this.elencoClientiDg.Location = new System.Drawing.Point(9, 58);
            this.elencoClientiDg.Name = "elencoClientiDg";
            this.elencoClientiDg.ReadOnly = true;
            this.elencoClientiDg.Size = new System.Drawing.Size(352, 347);
            this.elencoClientiDg.TabIndex = 2;
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
            this.prodottiTabPage.Location = new System.Drawing.Point(4, 22);
            this.prodottiTabPage.Name = "prodottiTabPage";
            this.prodottiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.prodottiTabPage.Size = new System.Drawing.Size(776, 512);
            this.prodottiTabPage.TabIndex = 1;
            this.prodottiTabPage.Text = "Anagrafica prodotti";
            this.prodottiTabPage.UseVisualStyleBackColor = true;
            // 
            // viaggiTabPage
            // 
            this.viaggiTabPage.Location = new System.Drawing.Point(4, 22);
            this.viaggiTabPage.Name = "viaggiTabPage";
            this.viaggiTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.viaggiTabPage.Size = new System.Drawing.Size(776, 512);
            this.viaggiTabPage.TabIndex = 2;
            this.viaggiTabPage.Text = "Storico viaggi";
            this.viaggiTabPage.UseVisualStyleBackColor = true;
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
            // ragioneSocialeTb
            // 
            this.ragioneSocialeTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentClientBs, "RagioneSociale", true));
            this.ragioneSocialeTb.Location = new System.Drawing.Point(6, 32);
            this.ragioneSocialeTb.Name = "ragioneSocialeTb";
            this.ragioneSocialeTb.Size = new System.Drawing.Size(352, 20);
            this.ragioneSocialeTb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tariffa";
            // 
            // tariffaMTb
            // 
            this.tariffaMTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentClientBs, "Tariffa", true));
            this.tariffaMTb.Location = new System.Drawing.Point(9, 85);
            this.tariffaMTb.Name = "tariffaMTb";
            this.tariffaMTb.Size = new System.Drawing.Size(100, 20);
            this.tariffaMTb.TabIndex = 4;
            this.tariffaMTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nuovoBtn
            // 
            this.nuovoBtn.Location = new System.Drawing.Point(9, 382);
            this.nuovoBtn.Name = "nuovoBtn";
            this.nuovoBtn.Size = new System.Drawing.Size(75, 23);
            this.nuovoBtn.TabIndex = 5;
            this.nuovoBtn.Text = "Nuovo";
            this.nuovoBtn.UseVisualStyleBackColor = true;
            this.nuovoBtn.Click += new System.EventHandler(this.nuovoBtn_Click);
            // 
            // salvaBtn
            // 
            this.salvaBtn.Location = new System.Drawing.Point(99, 382);
            this.salvaBtn.Name = "salvaBtn";
            this.salvaBtn.Size = new System.Drawing.Size(75, 23);
            this.salvaBtn.TabIndex = 6;
            this.salvaBtn.Text = "Salva";
            this.salvaBtn.UseVisualStyleBackColor = true;
            this.salvaBtn.Click += new System.EventHandler(this.salvaBtn_Click);
            // 
            // eliminaBtn
            // 
            this.eliminaBtn.Location = new System.Drawing.Point(283, 382);
            this.eliminaBtn.Name = "eliminaBtn";
            this.eliminaBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminaBtn.TabIndex = 7;
            this.eliminaBtn.Text = "Elimina";
            this.eliminaBtn.UseVisualStyleBackColor = true;
            this.eliminaBtn.Click += new System.EventHandler(this.eliminaBtn_Click);
            // 
            // currentClientBs
            // 
            this.currentClientBs.DataSource = typeof(GestioneViaggi.Model.Cliente);
            // 
            // anagraficaClientiVMBs
            // 
            this.anagraficaClientiVMBs.DataSource = typeof(GestioneViaggi.ViewModel.AnagraficaClientiVModel);
            // 
            // ragioneSocialeDataGridViewTextBoxColumn
            // 
            this.ragioneSocialeDataGridViewTextBoxColumn.DataPropertyName = "RagioneSociale";
            this.ragioneSocialeDataGridViewTextBoxColumn.HeaderText = "RagioneSociale";
            this.ragioneSocialeDataGridViewTextBoxColumn.Name = "ragioneSocialeDataGridViewTextBoxColumn";
            this.ragioneSocialeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ragioneSocialeDataGridViewTextBoxColumn.Width = 230;
            // 
            // tariffaDataGridViewTextBoxColumn
            // 
            this.tariffaDataGridViewTextBoxColumn.DataPropertyName = "Tariffa";
            this.tariffaDataGridViewTextBoxColumn.HeaderText = "Tariffa";
            this.tariffaDataGridViewTextBoxColumn.Name = "tariffaDataGridViewTextBoxColumn";
            this.tariffaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tariffaDataGridViewTextBoxColumn.Width = 55;
            // 
            // elencoClientiBs
            // 
            this.elencoClientiBs.DataMember = "Clienti";
            this.elencoClientiBs.DataSource = typeof(GestioneViaggi.ViewModel.AnagraficaClientiVModel);
            this.elencoClientiBs.CurrentChanged += new System.EventHandler(this.elencoClientiBs_CurrentChanged);
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
            this.clientiTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elencoClientiDg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentClientBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anagraficaClientiVMBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elencoClientiBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminaToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage clientiTabPage;
        private System.Windows.Forms.TabPage prodottiTabPage;
        private System.Windows.Forms.TabPage viaggiTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ragioneSocialeFilterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView elencoClientiDg;
        private System.Windows.Forms.BindingSource elencoClientiBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ragioneSocialeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tariffaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource anagraficaClientiVMBs;
        private System.Windows.Forms.MaskedTextBox tariffaMTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ragioneSocialeTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button eliminaBtn;
        private System.Windows.Forms.Button salvaBtn;
        private System.Windows.Forms.Button nuovoBtn;
        private System.Windows.Forms.BindingSource currentClientBs;
    }
}

