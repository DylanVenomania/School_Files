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
    public partial class StatisticsForm : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public StatisticsForm()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var salesData = context.BILLs
                .Where(b => b.BillDate.HasValue)
                .Join(context.CASHes,
                      bill => new { bill.TransNo, bill.Pcode },
                      cash => new { cash.TransNo, cash.Pcode },
                      (bill, cash) => new { bill.BillDate, cash.Total })
                .GroupBy(b => b.BillDate.Value.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    TotalSales = g.Sum(x => x.Total)
                }).ToList();

            dataGridView1.DataSource = salesData;

            chart1.Series.Clear();
            var series = new Series("Sales");
            series.ChartType = SeriesChartType.Line;
            foreach (var data in salesData)
            {
                series.Points.AddXY(data.Date, data.TotalSales);
            }
            chart1.Series.Add(series);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
