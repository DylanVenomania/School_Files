using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Pet_Shop_Management_interface
{
    public partial class HistoryForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        int CustomerID;
        public bool Is_Empty_HisTory = false;
        public HistoryForm(int Customer_ID)
        {
            InitializeComponent();
            CustomerID = Customer_ID;
            HistoryForm_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvHistory.AutoGenerateColumns = false;
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                HistoryForm_Load();
                return;
            }

            try
            {
                DateTime? searchDate = null;
                bool isDateSearch = false;
                if (keyword.Contains("/"))
                {
                    string[] formats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };
                    isDateSearch = DateTime.TryParseExact(keyword, formats,
                                                        System.Globalization.CultureInfo.InvariantCulture,
                                                        System.Globalization.DateTimeStyles.None,
                                                        out DateTime parsedDate);
                    if (isDateSearch)
                    {
                        searchDate = parsedDate.Date;
                    }
                }

                var query = from bill in context.BILLs
                            join cash in context.CASHes on new { bill.TransNo, bill.Pcode } equals new { cash.TransNo, cash.Pcode }
                            join product in context.PRODUCTs on bill.Pcode equals product.Pcode
                            join user in context.USERs on cash.CashierID equals user.ID
                            where bill.CustomerID == CustomerID
                            select new
                            {
                                bill.Pcode,
                                ProductName = product.Name,
                                cash.Qty,
                                cash.Price,
                                Total = cash.Qty * cash.Price,
                                user.Name,
                                bill.BillDate
                            };

                var filteredList = query
                    .AsEnumerable() // LINQ to Objects
                    .Where(item =>
                        item.Pcode.ToString().Contains(keyword) ||
                        item.ProductName.ToLower().Contains(keyword) ||
                        item.Qty.ToString().Contains(keyword) ||
                        item.Price.ToString().Contains(keyword) ||
                        item.Total.ToString().Contains(keyword) ||
                        item.Name.ToLower().Contains(keyword) ||
                        (isDateSearch && item.BillDate.HasValue && item.BillDate.Value.Date == searchDate.Value) ||
                        (!isDateSearch && item.BillDate.HasValue && item.BillDate.Value.ToString("dd/MM/yyyy").Contains(keyword))
                    )
                    .ToList();

                var displayList = filteredList
                    .OrderByDescending(item => item.BillDate)
                    .Select((item, index) => new
                    {
                        No = index + 1,
                        item.Pcode,
                        item.ProductName,
                        item.Qty,
                        item.Price,
                        item.Total,
                        item.Name,
                        TransDate = item.BillDate.HasValue
                            ? item.BillDate.Value.ToString("dd/MM/yyyy HH:mm")
                            : string.Empty
                    }).ToList();

                dgvHistory.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region method
        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Sheet1");
            ws.Cell(1, 1).Value = "Exported on: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string creator = context.USERs.FirstOrDefault(u => u.ID == LoginForm.ACCOUNT_ID).Name;
            ws.Cell(2, 1).Value = "Generated by: " + creator;

            // Add headers
            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                ws.Cell(3, i + 1).Value = dgv.Columns[i].HeaderText;
            }

            // Add rows
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count - 1; j++)
                {
                    ws.Cell(i + 4, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString();
                }
            }

            wb.SaveAs(filePath);
        }

        private void ExportToPDF(DataGridView dgv, string filePath)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Load file TTF
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);

            // Add Information
            Paragraph header1 = new Paragraph("Exported on: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            header1.Alignment = Element.ALIGN_LEFT;
            header1.SpacingAfter = 10f;
            string creator = context.USERs.FirstOrDefault(u => u.ID == LoginForm.ACCOUNT_ID).Name;
            Paragraph header2 = new Paragraph("Generated by: " + creator, font);
            header2.Alignment = Element.ALIGN_LEFT;
            header2.SpacingAfter = 10f;
            doc.Add(header1);
            doc.Add(header2);


            int columnCount = dgv.Columns.Count - 1;
            PdfPTable table = new PdfPTable(columnCount);
            table.WidthPercentage = 100;

            // Add headers
            for (int i = 0; i < columnCount; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dgv.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            // Add rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        string cellText = row.Cells[i].Value?.ToString() ?? "";
                        PdfPCell cell = new PdfPCell(new Phrase(cellText, font));
                        table.AddCell(cell);
                    }
                }
            }

            doc.Add(table);
            doc.Close();
        }

        private void HistoryForm_Load()
        {
            dgvHistory.AutoGenerateColumns = false;
            try
            {
                if (context != null)
                    context.Dispose();
                context = new PETSHOPDataContext();

                var historyList = (from bill in context.BILLs
                                   join cash in context.CASHes on new { bill.TransNo, bill.Pcode } equals new { cash.TransNo, cash.Pcode }
                                   join product in context.PRODUCTs on bill.Pcode equals product.Pcode
                                   join user in context.USERs on cash.CashierID equals user.ID
                                   where bill.CustomerID == CustomerID
                                   select new
                                   {
                                       bill.Pcode,
                                       bill.BillID,
                                       ProductName = product.Name,
                                       cash.Qty,
                                       cash.Price,
                                       Total = cash.Qty * cash.Price,
                                       user.Name,
                                       bill.BillDate
                                   }).Distinct().ToList();

                if (historyList.Count == 0)
                {
                    MessageBox.Show("No history found for this customer!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Is_Empty_HisTory = true;
                    return;
                }
                var displayList = historyList
                    .OrderByDescending(item => item.BillDate)
                    .Select((item, index) => new
                    {
                        No = index + 1,
                        item.Pcode,
                        item.BillID,
                        item.ProductName,
                        item.Qty,
                        item.Price,
                        item.Total,
                        item.Name,
                        TransDate = item.BillDate.HasValue
                            ? item.BillDate.Value.ToString("dd/MM/yyyy HH:mm")
                            : string.Empty
                    }).ToList();

                dgvHistory.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion method

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|PDF File (*.pdf)|*.pdf";
            sfd.Title = "Export file";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(sfd.FileName);

                if (fileExtension.ToLower() == ".xlsx")
                {
                    ExportToExcel(dgvHistory, sfd.FileName);
                }
                else if (fileExtension.ToLower() == ".pdf")
                {
                    ExportToPDF(dgvHistory, sfd.FileName);
                }

                MessageBox.Show("Export thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvHistory.Columns[e.ColumnIndex].Name;
            if (dgvHistory.Rows.Count == 0 || e.RowIndex < 0)
            {
                return;
            }
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        int BillID = int.Parse(dgvHistory.Rows[e.RowIndex].Cells["BillID"].Value.ToString());

                        var billToDelete = context.BILLs.FirstOrDefault(b => b.BillID == BillID);

                        if (billToDelete != null)
                        {
                            context.BILLs.DeleteOnSubmit(billToDelete);
                            context.SubmitChanges();

                            HistoryForm_Load();

                            MessageBox.Show("History data has been successfully removed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            HistoryForm_Load();
        }
    }
}
