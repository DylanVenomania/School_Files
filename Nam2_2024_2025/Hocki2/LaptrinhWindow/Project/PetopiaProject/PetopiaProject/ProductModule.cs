using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class ProductModule : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        int Pcode;
        public ProductModule(int Pcode)
        {
            InitializeComponent();
            this.Pcode = Pcode;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int newPcode = 100;
            if (context.PRODUCTs.Any())
            {
                newPcode = context.PRODUCTs.Max(u => u.Pcode) + 1;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()) ||
                string.IsNullOrEmpty(txtPrice.Text.Trim()) ||
                string.IsNullOrEmpty(txtQty.Text.Trim()) ||
                cbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Quantity must be a non-negative number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPrice.Text, out int price) || price <= 0)
            {
                MessageBox.Show("Price must be a positive number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PRODUCT product = new PRODUCT();
            product.Pcode = newPcode;
            product.Name = txtName.Text.Trim();
            product.Category = cbCategory.SelectedItem.ToString();
            product.Qty = qty;
            product.Price = price;
            context.PRODUCTs.InsertOnSubmit(product);
            context.SubmitChanges();
            MessageBox.Show("Add successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PRODUCT product = context.PRODUCTs.FirstOrDefault(x => x.Pcode == Pcode);
            if (product != null)
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Length > 50)
                {
                    MessageBox.Show("Name cannot be empty and must not exceed 50 characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbCategory.SelectedItem == null || string.IsNullOrEmpty(cbCategory.SelectedItem.ToString()))
                {
                    MessageBox.Show("Please select a valid category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
                {
                    MessageBox.Show("Quantity must be a non-negative integer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPrice.Text, out int price) || price <= 0)
                {
                    MessageBox.Show("Price must be a positive integer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                context.SubmitChanges();
                MessageBox.Show("Update successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            cbCategory.SelectedIndex = -1;
        }
    }
}
