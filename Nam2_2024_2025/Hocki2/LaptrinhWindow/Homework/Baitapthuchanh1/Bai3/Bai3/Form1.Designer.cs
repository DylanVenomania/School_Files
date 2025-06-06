namespace Bai3
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
            this.lbl_lienketwebsite = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lstkhungsite = new System.Windows.Forms.ListBox();
            this.khungketqua = new System.Windows.Forms.TextBox();
            this.lbl_chonsite = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_lienketwebsite
            // 
            this.lbl_lienketwebsite.AutoSize = true;
            this.lbl_lienketwebsite.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lienketwebsite.ForeColor = System.Drawing.Color.Red;
            this.lbl_lienketwebsite.Location = new System.Drawing.Point(246, 33);
            this.lbl_lienketwebsite.Name = "lbl_lienketwebsite";
            this.lbl_lienketwebsite.Size = new System.Drawing.Size(176, 25);
            this.lbl_lienketwebsite.TabIndex = 0;
            this.lbl_lienketwebsite.Tag = "";
            this.lbl_lienketwebsite.Text = "Liên kết Website";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(341, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lstkhungsite
            // 
            this.lstkhungsite.FormattingEnabled = true;
            this.lstkhungsite.ItemHeight = 16;
            this.lstkhungsite.Location = new System.Drawing.Point(53, 115);
            this.lstkhungsite.Name = "lstkhungsite";
            this.lstkhungsite.Size = new System.Drawing.Size(219, 164);
            this.lstkhungsite.TabIndex = 2;
            // 
            // khungketqua
            // 
            this.khungketqua.BackColor = System.Drawing.SystemColors.Menu;
            this.khungketqua.Location = new System.Drawing.Point(317, 115);
            this.khungketqua.Multiline = true;
            this.khungketqua.Name = "khungketqua";
            this.khungketqua.Size = new System.Drawing.Size(292, 164);
            this.khungketqua.TabIndex = 3;
            this.khungketqua.TextChanged += new System.EventHandler(this.khungketqua_TextChanged);
            // 
            // lbl_chonsite
            // 
            this.lbl_chonsite.AutoSize = true;
            this.lbl_chonsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_chonsite.Location = new System.Drawing.Point(49, 81);
            this.lbl_chonsite.Name = "lbl_chonsite";
            this.lbl_chonsite.Size = new System.Drawing.Size(112, 16);
            this.lbl_chonsite.TabIndex = 4;
            this.lbl_chonsite.Text = "Bạn hãy chọn site";
            // 
            // btn_ok
            // 
            this.btn_ok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ok.Location = new System.Drawing.Point(155, 304);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(73, 37);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_reset.Location = new System.Drawing.Point(276, 304);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(73, 37);
            this.btn_reset.TabIndex = 6;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_thoat
            // 
            this.btn_thoat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_thoat.Location = new System.Drawing.Point(394, 304);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(73, 37);
            this.btn_thoat.TabIndex = 7;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 353);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_chonsite);
            this.Controls.Add(this.khungketqua);
            this.Controls.Add(this.lstkhungsite);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lbl_lienketwebsite);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Liên kết";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_lienketwebsite;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox lstkhungsite;
        private System.Windows.Forms.TextBox khungketqua;
        private System.Windows.Forms.Label lbl_chonsite;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_thoat;
    }
}

