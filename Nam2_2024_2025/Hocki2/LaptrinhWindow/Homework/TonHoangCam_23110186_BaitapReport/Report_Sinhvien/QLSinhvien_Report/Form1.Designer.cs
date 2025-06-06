namespace QLSinhvien_Report
{
    partial class frm_sinhvien_report
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
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(104, 10);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(134, 24);
            this.cmbKhoa.TabIndex = 0;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(269, 8);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(134, 29);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Khoa";
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(12, 43);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.Size = new System.Drawing.Size(768, 372);
            this.crystalReportViewer.TabIndex = 4;
            // 
            // frm_sinhvien_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.cmbKhoa);
            this.Name = "frm_sinhvien_report";
            this.Text = "Quản lý sinh viên _ Tôn Hoàng Cầm _ 23110186";
            this.Load += new System.EventHandler(this.frm_sinhvien_report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
    }
}

