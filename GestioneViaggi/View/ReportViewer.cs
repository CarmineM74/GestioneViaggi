using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace GestioneViaggi.View
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        public void SetReport(ReportDocument rpt)
        {
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void ReportViewer_Shown(object sender, EventArgs e)
        {
            crystalReportViewer1.Refresh();
        }

    }
}
