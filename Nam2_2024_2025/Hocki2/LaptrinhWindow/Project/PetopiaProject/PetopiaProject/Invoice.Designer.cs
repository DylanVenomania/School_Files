namespace Pet_Shop_Management_interface
{
    partial class Invoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CRvInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRvInvoice
            // 
            this.CRvInvoice.ActiveViewIndex = 0;
            this.CRvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRvInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRvInvoice.Location = new System.Drawing.Point(0, 0);
            this.CRvInvoice.Name = "CRvInvoice";
            this.CRvInvoice.ReportSource = "D:\\Nam2_2024_2025\\Hocki2\\LaptrinhWindow\\Do_an\\PetopiaProject\\PetopiaProject\\Report_Cash.rpt";
            this.CRvInvoice.ShowCopyButton = false;
            this.CRvInvoice.ShowGotoPageButton = false;
            this.CRvInvoice.ShowGroupTreeButton = false;
            this.CRvInvoice.ShowPageNavigateButtons = false;
            this.CRvInvoice.ShowParameterPanelButton = false;
            this.CRvInvoice.ShowPrintButton = false;
            this.CRvInvoice.Size = new System.Drawing.Size(1362, 827);
            this.CRvInvoice.TabIndex = 0;
            this.CRvInvoice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 827);
            this.Controls.Add(this.CRvInvoice);
            this.Name = "Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRvInvoice;
    }
}