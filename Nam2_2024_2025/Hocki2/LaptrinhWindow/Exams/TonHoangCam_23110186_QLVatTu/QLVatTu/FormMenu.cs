using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVatTu
{
    public partial class frm_menu : Form
    {
        public frm_menu()
        {
            InitializeComponent();
        }

        private void quảnLýVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_qlvattu form = new frm_qlvattu();
            form.ShowDialog();
        }
    }
}
