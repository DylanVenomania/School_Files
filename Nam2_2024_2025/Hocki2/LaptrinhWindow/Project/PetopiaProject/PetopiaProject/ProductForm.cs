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
    public partial class ProductForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public ProductForm()
        {
            InitializeComponent();
            ProductForm_Load();
            if (LoginForm.ACCOUNT_ROLE == "User")
                btnAdd.Visible = false;
        }

        private void ProductForm_Load()
        {
            dgvProduct.AutoGenerateColumns = false;
            if (context != null)
                context.Dispose();
            context = new PETSHOPDataContext();

            var userList = context.PRODUCTs.ToList();

            var List = userList
                .Select((u, index) => new
                {
                    No = index + 1,
                    u.Pcode,
                    u.Name,
                    u.Category,
                    u.Qty,
                    u.Price
                }).ToList();

            dgvProduct.DataSource = List;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule module = new ProductModule(0);
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
            ProductForm_Load();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                int Pcode = int.Parse(dgvProduct.Rows[e.RowIndex].Cells["Pcode"].Value.ToString());
                string productName = dgvProduct.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                string productCategory = dgvProduct.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                string productQty = dgvProduct.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                string productPrice = dgvProduct.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                ProductModule module = new ProductModule(Pcode);
                module.txtName.Text = productName;
                module.txtPrice.Text = productPrice;
                module.cbCategory.SelectedItem = productCategory;
                module.txtQty.Text = productQty;
                module.btnSave.Enabled = false;

                module.ShowDialog();
                ProductForm_Load();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int Pcode = int.Parse(dgvProduct.Rows[e.RowIndex].Cells["Pcode"].Value.ToString());
                    var product = context.PRODUCTs.FirstOrDefault(x => x.Pcode == Pcode);
                    if (product != null)
                    {
                        context.PRODUCTs.DeleteOnSubmit(product);
                        context.SubmitChanges();
                        MessageBox.Show("Delete successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProductForm_Load();
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvProduct.AutoGenerateColumns = false;
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                ProductForm_Load();
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
            .Select((u, index) => new
            {
                No = index + 1,
                u.Pcode,
                u.Name,
                u.Category,
                u.Qty,
                u.Price
            }).ToList();

            dgvProduct.DataSource = displayList;
        }
    }
}
