namespace GestioneViaggi.View
{
    partial class ViaggioEditView
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
            this.label1 = new System.Windows.Forms.Label();
            this.idViaggioTb = new System.Windows.Forms.TextBox();
            this.viaggioBs = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.fornitoreCb = new System.Windows.Forms.ComboBox();
            this.viaggioVMBs = new System.Windows.Forms.BindingSource(this.components);
            this.fornitoriBs = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.conducenteTb = new System.Windows.Forms.TextBox();
            this.targaTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataViaggioDtp = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.annullaNuovaRigaBtn = new System.Windows.Forms.Button();
            this.rigaViaggioPnl = new System.Windows.Forms.Panel();
            this.costoTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pesataTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.prodottoCb = new System.Windows.Forms.ComboBox();
            this.prodottiBs = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.eliminaRigaBtn = new System.Windows.Forms.Button();
            this.aggiungiRigaBtn = new System.Windows.Forms.Button();
            this.nuovaRigaBtn = new System.Windows.Forms.Button();
            this.righeDg = new System.Windows.Forms.DataGridView();
            this.Prodotto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.righeBs = new System.Windows.Forms.BindingSource(this.components);
            this.salvaViaggioBtn = new System.Windows.Forms.Button();
            this.annullaBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.caloPesoTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viaggioBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viaggioVMBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.rigaViaggioPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.righeDg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.righeBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Progressivo";
            // 
            // idViaggioTb
            // 
            this.idViaggioTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viaggioBs, "Id", true));
            this.idViaggioTb.Location = new System.Drawing.Point(107, 8);
            this.idViaggioTb.Name = "idViaggioTb";
            this.idViaggioTb.ReadOnly = true;
            this.idViaggioTb.Size = new System.Drawing.Size(82, 20);
            this.idViaggioTb.TabIndex = 1;
            // 
            // viaggioBs
            // 
            this.viaggioBs.DataSource = typeof(GestioneViaggi.Model.Viaggio);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fornitore";
            // 
            // fornitoreCb
            // 
            this.fornitoreCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.viaggioVMBs, "fornitoreId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fornitoreCb.DataSource = this.fornitoriBs;
            this.fornitoreCb.DisplayMember = "RagioneSociale";
            this.fornitoreCb.FormattingEnabled = true;
            this.fornitoreCb.Location = new System.Drawing.Point(107, 41);
            this.fornitoreCb.Name = "fornitoreCb";
            this.fornitoreCb.Size = new System.Drawing.Size(325, 21);
            this.fornitoreCb.TabIndex = 3;
            this.fornitoreCb.ValueMember = "Id";
            // 
            // viaggioVMBs
            // 
            this.viaggioVMBs.DataSource = typeof(GestioneViaggi.ViewModel.ViaggioEditVModel);
            // 
            // fornitoriBs
            // 
            this.fornitoriBs.DataMember = "fornitori";
            this.fornitoriBs.DataSource = this.viaggioVMBs;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Conducente";
            // 
            // conducenteTb
            // 
            this.conducenteTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viaggioBs, "Conducente", true));
            this.conducenteTb.Location = new System.Drawing.Point(107, 76);
            this.conducenteTb.Name = "conducenteTb";
            this.conducenteTb.Size = new System.Drawing.Size(325, 20);
            this.conducenteTb.TabIndex = 5;
            // 
            // targaTb
            // 
            this.targaTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viaggioBs, "TargaAutomezzo", true));
            this.targaTb.Location = new System.Drawing.Point(107, 111);
            this.targaTb.Name = "targaTb";
            this.targaTb.Size = new System.Drawing.Size(325, 20);
            this.targaTb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Targa automezzo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data";
            // 
            // dataViaggioDtp
            // 
            this.dataViaggioDtp.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.viaggioVMBs, "DataViaggio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataViaggioDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataViaggioDtp.Location = new System.Drawing.Point(298, 8);
            this.dataViaggioDtp.Name = "dataViaggioDtp";
            this.dataViaggioDtp.Size = new System.Drawing.Size(134, 20);
            this.dataViaggioDtp.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.annullaNuovaRigaBtn);
            this.groupBox1.Controls.Add(this.rigaViaggioPnl);
            this.groupBox1.Controls.Add(this.eliminaRigaBtn);
            this.groupBox1.Controls.Add(this.aggiungiRigaBtn);
            this.groupBox1.Controls.Add(this.nuovaRigaBtn);
            this.groupBox1.Controls.Add(this.righeDg);
            this.groupBox1.Location = new System.Drawing.Point(15, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 289);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elenco prodotti nel viaggio";
            // 
            // annullaNuovaRigaBtn
            // 
            this.annullaNuovaRigaBtn.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viaggioVMBs, "canCancelRiga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.annullaNuovaRigaBtn.Location = new System.Drawing.Point(203, 256);
            this.annullaNuovaRigaBtn.Name = "annullaNuovaRigaBtn";
            this.annullaNuovaRigaBtn.Size = new System.Drawing.Size(68, 23);
            this.annullaNuovaRigaBtn.TabIndex = 3;
            this.annullaNuovaRigaBtn.Text = "Annulla";
            this.annullaNuovaRigaBtn.UseVisualStyleBackColor = true;
            this.annullaNuovaRigaBtn.Click += new System.EventHandler(this.annullaNuovaRigaBtn_Click);
            // 
            // rigaViaggioPnl
            // 
            this.rigaViaggioPnl.Controls.Add(this.costoTb);
            this.rigaViaggioPnl.Controls.Add(this.label8);
            this.rigaViaggioPnl.Controls.Add(this.pesataTb);
            this.rigaViaggioPnl.Controls.Add(this.label7);
            this.rigaViaggioPnl.Controls.Add(this.prodottoCb);
            this.rigaViaggioPnl.Controls.Add(this.label6);
            this.rigaViaggioPnl.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viaggioVMBs, "isSelectedRiga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rigaViaggioPnl.Location = new System.Drawing.Point(6, 184);
            this.rigaViaggioPnl.Name = "rigaViaggioPnl";
            this.rigaViaggioPnl.Size = new System.Drawing.Size(405, 66);
            this.rigaViaggioPnl.TabIndex = 15;
            // 
            // costoTb
            // 
            this.costoTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viaggioVMBs, "costo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.costoTb.Location = new System.Drawing.Point(266, 36);
            this.costoTb.Name = "costoTb";
            this.costoTb.Size = new System.Drawing.Size(54, 20);
            this.costoTb.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Costo (€)";
            // 
            // pesataTb
            // 
            this.pesataTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viaggioVMBs, "pesata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.errorProvider1.SetError(this.pesataTb, "Pesata non valida!");
            this.pesataTb.Location = new System.Drawing.Point(97, 36);
            this.pesataTb.Name = "pesataTb";
            this.pesataTb.Size = new System.Drawing.Size(83, 20);
            this.pesataTb.TabIndex = 1;
            this.pesataTb.Leave += new System.EventHandler(this.pesataTb_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Pesata (T)";
            // 
            // prodottoCb
            // 
            this.prodottoCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.viaggioVMBs, "prodottoId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prodottoCb.DataSource = this.prodottiBs;
            this.prodottoCb.DisplayMember = "Descrizione";
            this.prodottoCb.FormattingEnabled = true;
            this.prodottoCb.Location = new System.Drawing.Point(97, 3);
            this.prodottoCb.Name = "prodottoCb";
            this.prodottoCb.Size = new System.Drawing.Size(305, 21);
            this.prodottoCb.TabIndex = 0;
            this.prodottoCb.ValueMember = "Id";
            this.prodottoCb.SelectedIndexChanged += new System.EventHandler(this.prodottoCb_SelectedIndexChanged);
            // 
            // prodottiBs
            // 
            this.prodottiBs.DataMember = "prodotti";
            this.prodottiBs.DataSource = this.viaggioVMBs;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Prodotto";
            // 
            // eliminaRigaBtn
            // 
            this.eliminaRigaBtn.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viaggioVMBs, "canDeleteRiga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.eliminaRigaBtn.Location = new System.Drawing.Point(313, 256);
            this.eliminaRigaBtn.Name = "eliminaRigaBtn";
            this.eliminaRigaBtn.Size = new System.Drawing.Size(98, 23);
            this.eliminaRigaBtn.TabIndex = 4;
            this.eliminaRigaBtn.Text = "Elimina riga";
            this.eliminaRigaBtn.UseVisualStyleBackColor = true;
            this.eliminaRigaBtn.Click += new System.EventHandler(this.eliminaRigaBtn_Click);
            // 
            // aggiungiRigaBtn
            // 
            this.aggiungiRigaBtn.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viaggioVMBs, "canAddRiga", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.aggiungiRigaBtn.Location = new System.Drawing.Point(114, 256);
            this.aggiungiRigaBtn.Name = "aggiungiRigaBtn";
            this.aggiungiRigaBtn.Size = new System.Drawing.Size(83, 23);
            this.aggiungiRigaBtn.TabIndex = 2;
            this.aggiungiRigaBtn.Text = "Salva";
            this.aggiungiRigaBtn.UseVisualStyleBackColor = true;
            this.aggiungiRigaBtn.Click += new System.EventHandler(this.aggiungiRigaBtn_Click);
            // 
            // nuovaRigaBtn
            // 
            this.nuovaRigaBtn.Location = new System.Drawing.Point(10, 256);
            this.nuovaRigaBtn.Name = "nuovaRigaBtn";
            this.nuovaRigaBtn.Size = new System.Drawing.Size(98, 23);
            this.nuovaRigaBtn.TabIndex = 1;
            this.nuovaRigaBtn.Text = "Nuova riga";
            this.nuovaRigaBtn.UseVisualStyleBackColor = true;
            this.nuovaRigaBtn.Click += new System.EventHandler(this.nuovaRigaBtn_Click);
            // 
            // righeDg
            // 
            this.righeDg.AllowUserToAddRows = false;
            this.righeDg.AllowUserToDeleteRows = false;
            this.righeDg.AutoGenerateColumns = false;
            this.righeDg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.righeDg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prodotto,
            this.pesataDataGridViewTextBoxColumn,
            this.costoDataGridViewTextBoxColumn});
            this.righeDg.DataSource = this.righeBs;
            this.righeDg.Location = new System.Drawing.Point(6, 19);
            this.righeDg.Name = "righeDg";
            this.righeDg.ReadOnly = true;
            this.righeDg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.righeDg.Size = new System.Drawing.Size(405, 159);
            this.righeDg.TabIndex = 0;
            this.righeDg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.righeDg_CellClick);
            this.righeDg.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.righeDg_CellFormatting);
            // 
            // Prodotto
            // 
            this.Prodotto.DataPropertyName = "Prodotto.Descrizione";
            this.Prodotto.HeaderText = "Prodotto";
            this.Prodotto.Name = "Prodotto";
            this.Prodotto.ReadOnly = true;
            this.Prodotto.Width = 140;
            // 
            // pesataDataGridViewTextBoxColumn
            // 
            this.pesataDataGridViewTextBoxColumn.DataPropertyName = "Pesata";
            this.pesataDataGridViewTextBoxColumn.HeaderText = "Pesata";
            this.pesataDataGridViewTextBoxColumn.Name = "pesataDataGridViewTextBoxColumn";
            this.pesataDataGridViewTextBoxColumn.ReadOnly = true;
            this.pesataDataGridViewTextBoxColumn.Width = 60;
            // 
            // costoDataGridViewTextBoxColumn
            // 
            this.costoDataGridViewTextBoxColumn.DataPropertyName = "Costo";
            this.costoDataGridViewTextBoxColumn.HeaderText = "Costo";
            this.costoDataGridViewTextBoxColumn.Name = "costoDataGridViewTextBoxColumn";
            this.costoDataGridViewTextBoxColumn.ReadOnly = true;
            this.costoDataGridViewTextBoxColumn.Width = 70;
            // 
            // righeBs
            // 
            this.righeBs.DataMember = "Righe";
            this.righeBs.DataSource = this.viaggioBs;
            // 
            // salvaViaggioBtn
            // 
            this.salvaViaggioBtn.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viaggioVMBs, "CanSaveViaggio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.salvaViaggioBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.salvaViaggioBtn.Location = new System.Drawing.Point(15, 489);
            this.salvaViaggioBtn.Name = "salvaViaggioBtn";
            this.salvaViaggioBtn.Size = new System.Drawing.Size(111, 23);
            this.salvaViaggioBtn.TabIndex = 11;
            this.salvaViaggioBtn.Text = "Salva modifiche";
            this.salvaViaggioBtn.UseVisualStyleBackColor = true;
            this.salvaViaggioBtn.Click += new System.EventHandler(this.salvaViaggioBtn_Click);
            // 
            // annullaBtn
            // 
            this.annullaBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annullaBtn.Location = new System.Drawing.Point(357, 489);
            this.annullaBtn.Name = "annullaBtn";
            this.annullaBtn.Size = new System.Drawing.Size(75, 23);
            this.annullaBtn.TabIndex = 12;
            this.annullaBtn.Text = "Annulla";
            this.annullaBtn.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.viaggioVMBs;
            // 
            // caloPesoTb
            // 
            this.caloPesoTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viaggioVMBs, "caloPeso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.caloPesoTb.Location = new System.Drawing.Point(107, 140);
            this.caloPesoTb.Name = "caloPesoTb";
            this.caloPesoTb.Size = new System.Drawing.Size(68, 20);
            this.caloPesoTb.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Calo peso";
            // 
            // ViaggioEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 521);
            this.Controls.Add(this.caloPesoTb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.annullaBtn);
            this.Controls.Add(this.salvaViaggioBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataViaggioDtp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.targaTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.conducenteTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fornitoreCb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idViaggioTb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "ViaggioEditView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViaggioEditView";
            this.Shown += new System.EventHandler(this.ViaggioEditView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.viaggioBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viaggioVMBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornitoriBs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.rigaViaggioPnl.ResumeLayout(false);
            this.rigaViaggioPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.righeDg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.righeBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idViaggioTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fornitoreCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox conducenteTb;
        private System.Windows.Forms.TextBox targaTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dataViaggioDtp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView righeDg;
        private System.Windows.Forms.Button salvaViaggioBtn;
        private System.Windows.Forms.Button annullaBtn;
        private System.Windows.Forms.Button eliminaRigaBtn;
        private System.Windows.Forms.Button aggiungiRigaBtn;
        private System.Windows.Forms.Button nuovaRigaBtn;
        private System.Windows.Forms.BindingSource viaggioVMBs;
        private System.Windows.Forms.BindingSource viaggioBs;
        private System.Windows.Forms.BindingSource righeBs;
        private System.Windows.Forms.BindingSource prodottiBs;
        private System.Windows.Forms.BindingSource fornitoriBs;
        private System.Windows.Forms.Panel rigaViaggioPnl;
        private System.Windows.Forms.TextBox costoTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox pesataTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox prodottoCb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button annullaNuovaRigaBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prodotto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caloPesoPercentualeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox caloPesoTb;
        private System.Windows.Forms.Label label9;
    }
}