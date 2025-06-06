using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Bai2
{
    public partial class fIn : Form
    {
        public fIn()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void fIn_Load(object sender, EventArgs e)
        {

        }
        public void LoadReport(ReportDocument rpt)
        {
            this.crystalReportViewer1.ReportSource = rpt;
            this.crystalReportViewer1.Refresh();
        }
    }
}
