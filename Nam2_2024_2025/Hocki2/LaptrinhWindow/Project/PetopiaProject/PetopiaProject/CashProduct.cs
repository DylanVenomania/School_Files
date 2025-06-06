using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pet_Shop_Management_interface
{
    public partial class CashProduct : Form
    {

        PETSHOPDataContext context = new PETSHOPDataContext();
        CashForm CASHFORM = new CashForm();
        public CashProduct(CashForm cashform)
        {
            InitializeComponent();
            LoadCash();
            CASHFORM = cashform;
        }
        #region method

        public void LoadCash()
        {
            dgvProduct.AutoGenerateColumns = false;
            try
            {
                if (context != null)
                    context.Dispose();
                context = new PETSHOPDataContext();
                var cashList = (from product in context.PRODUCTs
                                select new
                                {
                                    product.Pcode,
                                    product.Name,
                                    product.Category,
                                    product.Qty,
                                    product.Price
                                }).ToList();

                var list = cashList
                    .Where(u => u.Qty > 0)
                    .Select((c, index) => new
                    {
                        No = index + 1,
                        c.Pcode,
                        c.Name,
                        c.Category,
                        c.Qty,
                        c.Price
                    }).ToList();

                dgvProduct.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion method

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvProduct.AutoGenerateColumns = false;
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadCash();
                return;
            }

            var filteredList = context.PRODUCTs
                .Where(u =>
                    u.Pcode.ToString().Contains(keyword) ||
                    u.Name.ToLower().Contains(keyword) ||
                    u.Category.ToLower().Contains(keyword) ||
                    u.Qty.ToString().Contains(keyword) ||
                    u.Price.ToString().Contains(keyword)
                    )
                .ToList();

            var displayList = filteredList
                .Where(u => u.Qty > 0)
                .Select((u, index) => new
                {
                    No = index + 1,
                    u.Pcode,
                    u.Name,
                    u.Category,
                    u.Qty,
                    u.Price
                })
                .ToList();

            dgvProduct.DataSource = displayList;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            int newId = 50000;
            foreach (DataGridViewRow dr in dgvProduct.Rows)
            {
                bool checkbox = Convert.ToBoolean(dr.Cells["Select"].Value);

                int maxCashId = context.CASHes.Any() ? context.CASHes.Max(u => u.CashID) + 1 : 0;

                newId = Math.Max(maxCashId, 50000);

                if (checkbox)
                {
                    try
                    {
                        int pcode = int.Parse(dr.Cells["Pcode"].Value.ToString());
                        var existingCash = context.CASHes.FirstOrDefault(c => c.Pcode == pcode && c.TransNo == CASHFORM.lblTransno.Text.Trim());

                        if (existingCash != null)
                        {
                            existingCash.Qty += 1;
                            existingCash.Total = existingCash.Qty * existingCash.Price;
                            context.SubmitChanges();
                        }
                        else
                        {
                            CASH cash = new CASH();
                            cash.CashID = newId;
                            cash.TransNo = CASHFORM.lblTransno.Text.Trim();
                            cash.Pcode = pcode;
                            cash.Qty = 1;
                            cash.Price = int.Parse(dr.Cells["Price"].Value.ToString());
                            cash.Total = cash.Qty * cash.Price;
                            cash.CustomerID = null;
                            cash.CashierID = LoginForm.ACCOUNT_ID;
                            context.CASHes.InsertOnSubmit(cash);
                            context.SubmitChanges();
                        }

                        CASHFORM.LoadCash();
                        CASHFORM.UpdateTotal();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            this.Close();
        }
    }
}