using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class CashCustomer : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        CashForm CASHFORM;
        public CashCustomer(CashForm cashform)
        {
            InitializeComponent();
            CASHFORM = cashform;
        }
        private void CashCustomer_Load(object sender, EventArgs e)
        {
            dgvCustomer.AutoGenerateColumns = false;
            try
            {
                if (context != null)
                    context.Dispose();
                context = new PETSHOPDataContext();
                string cashier_name = context.USERs.FirstOrDefault(u => u.ID == LoginForm.ACCOUNT_ID).Name.Trim();

                var cashList = (from customer in context.CUSTOMERs
                                select new
                                {
                                    customer.ID,
                                    customer.Name,
                                    customer.Phone,
                                }).ToList();

                var list = cashList
                    .Select((c, index) => new
                    {
                        No = index + 1,
                        c.ID,
                        c.Name,
                        c.Phone,
                    }).ToList();

                dgvCustomer.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Choice1")
            {
                int customerId = (int)dgvCustomer.Rows[e.RowIndex].Cells["ID"].Value;
                var cashRecords = context.CASHes.Where(c => c.TransNo == CASHFORM.lblTransno.Text.Trim());

                foreach (var record in cashRecords)
                {
                    record.CustomerID = customerId;
                }

                context.SubmitChanges();
                CASHFORM.LoadCash();

                this.Close();
            }
        }
    }
}
