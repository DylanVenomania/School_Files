using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pet_Shop_Management_interface
{
    public partial class CashForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();

        #region method
        public void LoadCash()
        {
            dgvCash.AutoGenerateColumns = false;
            try
            {
                if (context != null)
                    context.Dispose();
                context = new PETSHOPDataContext();

                string cashier_name = context.USERs.FirstOrDefault(u => u.ID == LoginForm.ACCOUNT_ID).Name.Trim();

                var cashList = (from cash in context.CASHes
                                where cash.TransNo == lblTransno.Text.Trim()
                                join product in context.PRODUCTs
                                on cash.Pcode equals product.Pcode
                                join customer in context.CUSTOMERs
                                on cash.CustomerID equals customer.ID into customerGroup
                                join user in context.USERs
                                on cash.CashierID equals user.ID
                                from customer in customerGroup.DefaultIfEmpty()
                                select new
                                {
                                    cash.CashID,
                                    cash.Pcode,
                                    ProductName = product.Name,
                                    cash.Qty,
                                    cash.Price,
                                    cash.Total,
                                    CustomerName = customer != null ? customer.Name : "",
                                    user.Name
                                }).ToList();

                var list = cashList
                    .Select((c, index) => new
                    {
                        c.CashID,
                        No = index + 1,
                        c.Pcode,
                        c.ProductName,
                        c.Qty,
                        c.Price,
                        c.Total,
                        c.CustomerName,
                        c.Name
                    }).ToList();

                dgvCash.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public int CheckProductQuantity(int productCode)
        {
            var product = context.PRODUCTs.FirstOrDefault(p => p.Pcode == productCode);
            if (product == null)
            {
                MessageBox.Show("Product not found", "Error");
                return 0;
            }
            return (int)product.Qty;
        }

        public void LoadTransno()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transno;

                // Truy vấn từ bảng BILL thay vì CASH
                var latestTransno = context.BILLs
                    .Where(b => b.TransNo.StartsWith(sdate)) // Lọc theo ngày hiện tại
                    .OrderByDescending(b => b.BillID) // Sắp xếp giảm dần theo BillID
                    .Select(b => b.TransNo)
                    .FirstOrDefault();

                if (latestTransno != null)
                {
                    // Lấy 4 chữ số cuối từ TransNo và tăng giá trị
                    count = int.Parse(latestTransno.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1).ToString("D4"); // Định dạng 4 chữ số
                }
                else
                {
                    // Khởi tạo TransNo đầu tiên trong ngày: yyyyMMdd1001
                    transno = sdate + "1001";
                    lblTransno.Text = transno;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void UpdateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCash.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            lblTotal.Text = $"{total:N0}";
        }

        #endregion method
        public CashForm()
        {
            InitializeComponent();
            LoadTransno();
            LoadCash();
            UpdateTotal();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            if (dgvCash.Rows.Count == 0)
            {
                MessageBox.Show("Please add products to the cart!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CashCustomer customer = new CashCustomer(this);
            customer.ShowDialog();

            if (MessageBox.Show("Are you sure you want to cash this product?", "Cashing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thêm vào bảng BILL
                int latestBillId = 1;
                if (context.BILLs.Any())
                {
                    latestBillId = context.BILLs.Max(b => b.BillID) + 1;
                }

                CASH cashRecord = context.CASHes.FirstOrDefault(c => c.TransNo == lblTransno.Text.Trim());
                if (cashRecord == null || cashRecord.CustomerID == null)
                {
                    MessageBox.Show("Customer not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int customerId = cashRecord.CustomerID.Value;

                for (int i = 0; i < dgvCash.Rows.Count; i++)
                {
                    BILL bill = new BILL()
                    {
                        BillID = latestBillId++,
                        TransNo = lblTransno.Text.Trim(),
                        CustomerID = customerId,
                        Pcode = int.Parse(dgvCash.Rows[i].Cells["Pcode"].Value.ToString()),
                        BillDate = DateTime.Now
                    };
                    context.BILLs.InsertOnSubmit(bill);

                    PRODUCT product = context.PRODUCTs.FirstOrDefault(p => p.Pcode == bill.Pcode);
                    if (product != null)
                    {
                        product.Qty -= int.Parse(dgvCash.Rows[i].Cells["Qty"].Value.ToString());
                    }
                }

                context.SubmitChanges();
                if (MessageBox.Show("Invoice generated successfully. Do you want to print it?", "Print Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Invoice invoice = new Invoice(this);
                    invoice.ShowDialog();
                }


                dgvCash.DataSource = null;
                lblTotal.Text = "0.00";
                LoadTransno();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            CashProduct product = new CashProduct(this);
            product.ShowDialog();
        }

        private void dgvCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCash.Rows.Count) return;

            try
            {
                string colName = dgvCash.Columns[e.ColumnIndex].Name;
                var row = dgvCash.Rows[e.RowIndex];
                int currentQty = int.Parse(row.Cells["Qty"].Value.ToString());
                int availableQty = CheckProductQuantity(int.Parse(row.Cells["Pcode"].Value.ToString()));



                var cashItem = context.CASHes.FirstOrDefault(c => c.CashID == int.Parse(row.Cells["CashID"].Value.ToString()));

                if (cashItem == null)
                {
                    MessageBox.Show("Item not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (colName)
                {
                    case "Delete":
                        if (MessageBox.Show("Are you sure you want to delete this item?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            context.CASHes.DeleteOnSubmit(cashItem);
                            context.SubmitChanges();
                            LoadCash();
                        }
                        break;

                    case "Increase":
                        if (currentQty < availableQty)
                        {
                            cashItem.Qty++;
                            cashItem.Total = cashItem.Price * cashItem.Qty;
                            context.SubmitChanges();
                            LoadCash();
                        }
                        else
                        {
                            MessageBox.Show($"Remaining quantity on hand is {availableQty}!",
                                "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case "Decrease":
                        if (currentQty == 1)
                        {
                            if (MessageBox.Show("Are you sure you want to delete this item?",
                            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                context.CASHes.DeleteOnSubmit(cashItem);
                                context.SubmitChanges();
                                LoadCash();
                            }
                        }
                        else
                        {
                            cashItem.Qty--;
                            cashItem.Total = cashItem.Price * cashItem.Qty;
                            context.SubmitChanges();
                            LoadCash();
                        }
                        break;
                }
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
