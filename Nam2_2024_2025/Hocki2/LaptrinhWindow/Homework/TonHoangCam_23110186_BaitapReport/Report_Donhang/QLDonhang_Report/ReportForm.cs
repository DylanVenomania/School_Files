using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDonhang_Report
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewer
        {
            get { return crystalReportViewer1; }
        }

    }
}
