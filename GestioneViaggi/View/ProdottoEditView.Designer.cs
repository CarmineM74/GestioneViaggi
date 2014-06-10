namespace GestioneViaggi.View
{
    partial class ProdottoEditView
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
            this.descrizioneTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.validoDalDtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.costoTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.annullaBtn = new System.Windows.Forms.Button();
            this.salvaProdottoBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.prodottoVMBs = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoVMBs)).BeginInit();
            this.SuspendLayout();
            // 
            // descrizioneTb
            // 
            this.descrizioneTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prodottoVMBs, "Descrizione", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.descrizioneTb.Location = new System.Drawing.Point(98, 12);
            this.descrizioneTb.Name = "descrizioneTb";
            this.descrizioneTb.Size = new System.Drawing.Size(304, 20);
            this.descrizioneTb.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descrizione";
            // 
            // validoDalDtp
            // 
            this.validoDalDtp.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.prodottoVMBs, "ValidoDal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.validoDalDtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.validoDalDtp.Location = new System.Drawing.Point(98, 41);
            this.validoDalDtp.Name = "validoDalDtp";
            this.validoDalDtp.Size = new System.Drawing.Size(134, 20);
            this.validoDalDtp.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Valido dal";
            // 
            // costoTb
            // 
            this.costoTb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.prodottoVMBs, "costo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.costoTb.Location = new System.Drawing.Point(98, 70);
            this.costoTb.Name = "costoTb";
            this.costoTb.Size = new System.Drawing.Size(54, 20);
            this.costoTb.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Costo (€)";
            // 
            // annullaBtn
            // 
            this.annullaBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annullaBtn.Location = new System.Drawing.Point(344, 113);
            this.annullaBtn.Name = "annullaBtn";
            this.annullaBtn.Size = new System.Drawing.Size(68, 23);
            this.annullaBtn.TabIndex = 23;
            this.annullaBtn.Text = "Annulla";
            this.annullaBtn.UseVisualStyleBackColor = true;
            // 
            // salvaProdottoBtn
            // 
            this.salvaProdottoBtn.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.prodottoVMBs, "CanSave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.salvaProdottoBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.salvaProdottoBtn.Location = new System.Drawing.Point(6, 113);
            this.salvaProdottoBtn.Name = "salvaProdottoBtn";
            this.salvaProdottoBtn.Size = new System.Drawing.Size(83, 23);
            this.salvaProdottoBtn.TabIndex = 22;
            this.salvaProdottoBtn.Text = "Salva";
            this.salvaProdottoBtn.UseVisualStyleBackColor = true;
            this.salvaProdottoBtn.Click += new System.EventHandler(this.salvaProdottoBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.prodottoVMBs;
            // 
            // prodottoVMBs
            // 
            this.prodottoVMBs.DataSource = typeof(GestioneViaggi.ViewModel.ProdottoEditVModel);
            // 
            // ProdottoEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 147);
            this.Controls.Add(this.annullaBtn);
            this.Controls.Add(this.salvaProdottoBtn);
            this.Controls.Add(this.costoTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.validoDalDtp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.descrizioneTb);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProdottoEditView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProdottoEditView";
            this.Shown += new System.EventHandler(this.ProdottoEditView_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoVMBs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descrizioneTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker validoDalDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox costoTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button annullaBtn;
        private System.Windows.Forms.Button salvaProdottoBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource prodottoVMBs;
    }
}