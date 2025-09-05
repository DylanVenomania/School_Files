namespace QLSinhvien
{
    partial class Form1
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
            this.ketnoi_btn = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_age = new System.Windows.Forms.TextBox();
            this.txt_gpa = new System.Windows.Forms.TextBox();
            this.getgpa_btn = new System.Windows.Forms.Button();
            this.lbl_program = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_UpdateLog = new System.Windows.Forms.DataGridView();
            this.showUpdateLog_btn = new System.Windows.Forms.Button();
            this.showAddLog_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_sinhvien = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_AddLog = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UpdateLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sinhvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddLog)).BeginInit();
            this.SuspendLayout();
            // 
            // ketnoi_btn
            // 
            this.ketnoi_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketnoi_btn.Location = new System.Drawing.Point(1059, 107);
            this.ketnoi_btn.Name = "ketnoi_btn";
            this.ketnoi_btn.Size = new System.Drawing.Size(179, 41);
            this.ketnoi_btn.TabIndex = 0;
            this.ketnoi_btn.Text = "Mở kết nối";
            this.ketnoi_btn.UseVisualStyleBackColor = true;
            this.ketnoi_btn.Click += new System.EventHandler(this.ketnoi_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_btn.Location = new System.Drawing.Point(1059, 268);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(179, 37);
            this.update_btn.TabIndex = 1;
            this.update_btn.Text = "Cập nhật sinh viên";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_btn.Location = new System.Drawing.Point(1059, 162);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(179, 37);
            this.add_btn.TabIndex = 2;
            this.add_btn.Text = "Thêm sinh viên";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // txt_id
            // 
            this.txt_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_id.Location = new System.Drawing.Point(447, 118);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(218, 22);
            this.txt_id.TabIndex = 5;
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Location = new System.Drawing.Point(447, 168);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(218, 22);
            this.txt_name.TabIndex = 6;
            // 
            // txt_age
            // 
            this.txt_age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_age.Location = new System.Drawing.Point(447, 226);
            this.txt_age.Name = "txt_age";
            this.txt_age.Size = new System.Drawing.Size(218, 22);
            this.txt_age.TabIndex = 7;
            // 
            // txt_gpa
            // 
            this.txt_gpa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_gpa.Location = new System.Drawing.Point(447, 282);
            this.txt_gpa.Name = "txt_gpa";
            this.txt_gpa.Size = new System.Drawing.Size(218, 22);
            this.txt_gpa.TabIndex = 8;
            // 
            // getgpa_btn
            // 
            this.getgpa_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getgpa_btn.Location = new System.Drawing.Point(1059, 220);
            this.getgpa_btn.Name = "getgpa_btn";
            this.getgpa_btn.Size = new System.Drawing.Size(179, 35);
            this.getgpa_btn.TabIndex = 9;
            this.getgpa_btn.Text = "Tìm GPA";
            this.getgpa_btn.UseVisualStyleBackColor = true;
            this.getgpa_btn.Click += new System.EventHandler(this.getgpa_btn_Click);
            // 
            // lbl_program
            // 
            this.lbl_program.AutoSize = true;
            this.lbl_program.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_program.Location = new System.Drawing.Point(726, 50);
            this.lbl_program.Name = "lbl_program";
            this.lbl_program.Size = new System.Drawing.Size(243, 38);
            this.lbl_program.TabIndex = 12;
            this.lbl_program.Text = "Quản lý sinh viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã sinh viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tuổi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "GPA";
            // 
            // dgv_UpdateLog
            // 
            this.dgv_UpdateLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UpdateLog.Location = new System.Drawing.Point(1161, 395);
            this.dgv_UpdateLog.Name = "dgv_UpdateLog";
            this.dgv_UpdateLog.RowHeadersWidth = 51;
            this.dgv_UpdateLog.Size = new System.Drawing.Size(514, 210);
            this.dgv_UpdateLog.TabIndex = 11;
            // 
            // showUpdateLog_btn
            // 
            this.showUpdateLog_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showUpdateLog_btn.Location = new System.Drawing.Point(1449, 353);
            this.showUpdateLog_btn.Name = "showUpdateLog_btn";
            this.showUpdateLog_btn.Size = new System.Drawing.Size(226, 37);
            this.showUpdateLog_btn.TabIndex = 17;
            this.showUpdateLog_btn.Text = "Xem log cập nhật sinh viên";
            this.showUpdateLog_btn.UseVisualStyleBackColor = true;
            this.showUpdateLog_btn.Click += new System.EventHandler(this.showUpdateLog_btn_Click);
            // 
            // showAddLog_btn
            // 
            this.showAddLog_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAddLog_btn.Location = new System.Drawing.Point(299, 352);
            this.showAddLog_btn.Name = "showAddLog_btn";
            this.showAddLog_btn.Size = new System.Drawing.Size(215, 36);
            this.showAddLog_btn.TabIndex = 10;
            this.showAddLog_btn.Text = "Xem log thêm sinh viên";
            this.showAddLog_btn.UseVisualStyleBackColor = true;
            this.showAddLog_btn.Click += new System.EventHandler(this.showAddLog_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(762, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Danh sách sinh viên";
            // 
            // dgv_sinhvien
            // 
            this.dgv_sinhvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sinhvien.Location = new System.Drawing.Point(551, 395);
            this.dgv_sinhvien.Name = "dgv_sinhvien";
            this.dgv_sinhvien.RowHeadersWidth = 51;
            this.dgv_sinhvien.RowTemplate.Height = 24;
            this.dgv_sinhvien.Size = new System.Drawing.Size(573, 210);
            this.dgv_sinhvien.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Log thêm sinh viên";
            // 
            // dgv_AddLog
            // 
            this.dgv_AddLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_AddLog.Location = new System.Drawing.Point(12, 395);
            this.dgv_AddLog.Name = "dgv_AddLog";
            this.dgv_AddLog.RowHeadersWidth = 51;
            this.dgv_AddLog.RowTemplate.Height = 24;
            this.dgv_AddLog.Size = new System.Drawing.Size(502, 210);
            this.dgv_AddLog.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1169, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 23);
            this.label7.TabIndex = 20;
            this.label7.Text = "Log cập nhật sinh viên";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1689, 617);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_AddLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_sinhvien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showAddLog_btn);
            this.Controls.Add(this.lbl_program);
            this.Controls.Add(this.showUpdateLog_btn);
            this.Controls.Add(this.txt_gpa);
            this.Controls.Add(this.dgv_UpdateLog);
            this.Controls.Add(this.txt_age);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.getgpa_btn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.ketnoi_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UpdateLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sinhvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_AddLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ketnoi_btn;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_age;
        private System.Windows.Forms.TextBox txt_gpa;
        private System.Windows.Forms.Button getgpa_btn;
        private System.Windows.Forms.Label lbl_program;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_UpdateLog;
        private System.Windows.Forms.Button showUpdateLog_btn;
        private System.Windows.Forms.Button showAddLog_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_sinhvien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_AddLog;
        private System.Windows.Forms.Label label7;
    }
}

