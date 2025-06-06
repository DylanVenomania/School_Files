namespace Bai1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bindingSource1 = new BindingSource(components);
            groupBox1 = new GroupBox();
            btn_thoat = new Button();
            btn_dangnhap = new Button();
            txt_matkhau = new TextBox();
            txt_tennguoidung = new TextBox();
            lbl_matkhau = new Label();
            lbl_tennguoidung = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_thoat);
            groupBox1.Controls.Add(btn_dangnhap);
            groupBox1.Controls.Add(txt_matkhau);
            groupBox1.Controls.Add(txt_tennguoidung);
            groupBox1.Controls.Add(lbl_matkhau);
            groupBox1.Controls.Add(lbl_tennguoidung);
            groupBox1.Font = new Font("Times New Roman", 10F);
            groupBox1.Location = new Point(59, 48);
            groupBox1.MinimumSize = new Size(200, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(461, 255);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đăng nhập";
            // 
            // btn_thoat
            // 
            btn_thoat.Location = new Point(255, 162);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(112, 35);
            btn_thoat.TabIndex = 5;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = true;
            btn_thoat.Click += btn_thoat_Click;
            // 
            // btn_dangnhap
            // 
            btn_dangnhap.Location = new Point(91, 162);
            btn_dangnhap.Name = "btn_dangnhap";
            btn_dangnhap.Size = new Size(119, 33);
            btn_dangnhap.TabIndex = 4;
            btn_dangnhap.Text = "Đăng nhập";
            btn_dangnhap.UseVisualStyleBackColor = true;
            btn_dangnhap.Click += btn_dangnhap_Click;
            // 
            // txt_matkhau
            // 
            txt_matkhau.BorderStyle = BorderStyle.FixedSingle;
            txt_matkhau.Location = new Point(174, 79);
            txt_matkhau.Name = "txt_matkhau";
            txt_matkhau.Size = new Size(229, 27);
            txt_matkhau.TabIndex = 3;
            txt_matkhau.UseSystemPasswordChar = true;
            // 
            // txt_tennguoidung
            // 
            txt_tennguoidung.BorderStyle = BorderStyle.FixedSingle;
            txt_tennguoidung.Location = new Point(174, 34);
            txt_tennguoidung.Name = "txt_tennguoidung";
            txt_tennguoidung.Size = new Size(229, 27);
            txt_tennguoidung.TabIndex = 2;
            // 
            // lbl_matkhau
            // 
            lbl_matkhau.AutoSize = true;
            lbl_matkhau.Font = new Font("Times New Roman", 10F);
            lbl_matkhau.Location = new Point(35, 79);
            lbl_matkhau.Name = "lbl_matkhau";
            lbl_matkhau.Size = new Size(80, 19);
            lbl_matkhau.TabIndex = 1;
            lbl_matkhau.Text = "Mật khẩu :";
            // 
            // lbl_tennguoidung
            // 
            lbl_tennguoidung.AutoSize = true;
            lbl_tennguoidung.Font = new Font("Times New Roman", 10F);
            lbl_tennguoidung.Location = new Point(35, 37);
            lbl_tennguoidung.Name = "lbl_tennguoidung";
            lbl_tennguoidung.Size = new Size(122, 19);
            lbl_tennguoidung.TabIndex = 0;
            lbl_tennguoidung.Text = "Tên người dùng :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(groupBox1);
            Name = "Form1";
            RightToLeftLayout = true;
            Text = "Đăng nhập hệ thống";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private BindingSource bindingSource1;
        private GroupBox groupBox1;
        private Label lbl_matkhau;
        private Label lbl_tennguoidung;
        private Button btn_thoat;
        private Button btn_dangnhap;
        private TextBox txt_matkhau;
        private TextBox txt_tennguoidung;
    }
}
