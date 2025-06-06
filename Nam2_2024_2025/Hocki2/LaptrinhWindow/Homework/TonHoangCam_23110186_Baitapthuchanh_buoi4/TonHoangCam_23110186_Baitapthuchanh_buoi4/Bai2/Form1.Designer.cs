namespace Bai2
{
    partial class frm_themhanghoa
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
            this.components = new System.ComponentModel.Container();
            this.txt_hanghoa = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txt_soluong = new System.Windows.Forms.TextBox();
            this.lbl_hanghoa = new System.Windows.Forms.Label();
            this.lbl_soluong = new System.Windows.Forms.Label();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.grid_hanghoa = new System.Windows.Forms.DataGridView();
            this.col_hanghoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_tongsoluong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hanghoa)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_hanghoa
            // 
            this.txt_hanghoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_hanghoa.Location = new System.Drawing.Point(156, 58);
            this.txt_hanghoa.Name = "txt_hanghoa";
            this.txt_hanghoa.Size = new System.Drawing.Size(315, 22);
            this.txt_hanghoa.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txt_soluong
            // 
            this.txt_soluong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_soluong.Location = new System.Drawing.Point(156, 113);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(315, 22);
            this.txt_soluong.TabIndex = 2;
            // 
            // lbl_hanghoa
            // 
            this.lbl_hanghoa.AutoSize = true;
            this.lbl_hanghoa.Location = new System.Drawing.Point(60, 61);
            this.lbl_hanghoa.Name = "lbl_hanghoa";
            this.lbl_hanghoa.Size = new System.Drawing.Size(66, 16);
            this.lbl_hanghoa.TabIndex = 3;
            this.lbl_hanghoa.Text = "Hàng hoá";
            // 
            // lbl_soluong
            // 
            this.lbl_soluong.AutoSize = true;
            this.lbl_soluong.Location = new System.Drawing.Point(66, 115);
            this.lbl_soluong.Name = "lbl_soluong";
            this.lbl_soluong.Size = new System.Drawing.Size(60, 16);
            this.lbl_soluong.TabIndex = 4;
            this.lbl_soluong.Text = "Số lượng";
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(176, 162);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(100, 35);
            this.btn_them.TabIndex = 5;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(343, 162);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(97, 35);
            this.btn_xoa.TabIndex = 6;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // grid_hanghoa
            // 
            this.grid_hanghoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_hanghoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_hanghoa,
            this.col_soluong});
            this.grid_hanghoa.Location = new System.Drawing.Point(28, 219);
            this.grid_hanghoa.Name = "grid_hanghoa";
            this.grid_hanghoa.RowHeadersWidth = 51;
            this.grid_hanghoa.RowTemplate.Height = 24;
            this.grid_hanghoa.Size = new System.Drawing.Size(580, 182);
            this.grid_hanghoa.TabIndex = 7;
            // 
            // col_hanghoa
            // 
            this.col_hanghoa.HeaderText = "Hàng hoá";
            this.col_hanghoa.MinimumWidth = 6;
            this.col_hanghoa.Name = "col_hanghoa";
            this.col_hanghoa.Width = 125;
            // 
            // col_soluong
            // 
            this.col_soluong.HeaderText = "Số lượng";
            this.col_soluong.MinimumWidth = 6;
            this.col_soluong.Name = "col_soluong";
            this.col_soluong.Width = 125;
            // 
            // txt_tongsoluong
            // 
            this.txt_tongsoluong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_tongsoluong.Location = new System.Drawing.Point(242, 424);
            this.txt_tongsoluong.Name = "txt_tongsoluong";
            this.txt_tongsoluong.Size = new System.Drawing.Size(146, 22);
            this.txt_tongsoluong.TabIndex = 8;
            // 
            // frm_themhanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 553);
            this.Controls.Add(this.txt_tongsoluong);
            this.Controls.Add(this.grid_hanghoa);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.lbl_soluong);
            this.Controls.Add(this.lbl_hanghoa);
            this.Controls.Add(this.txt_soluong);
            this.Controls.Add(this.txt_hanghoa);
            this.Name = "frm_themhanghoa";
            this.Text = "frm_themhanghoa ";
            ((System.ComponentModel.ISupportInitialize)(this.grid_hanghoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_hanghoa;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txt_soluong;
        private System.Windows.Forms.Label lbl_hanghoa;
        private System.Windows.Forms.Label lbl_soluong;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.DataGridView grid_hanghoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_hanghoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_soluong;
        private System.Windows.Forms.TextBox txt_tongsoluong;
    }
}

