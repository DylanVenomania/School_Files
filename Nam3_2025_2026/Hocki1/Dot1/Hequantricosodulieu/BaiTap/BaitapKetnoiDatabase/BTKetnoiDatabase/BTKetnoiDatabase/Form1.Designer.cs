namespace BTKetnoiDatabase
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
            ketnoi_btn = new Button();
            dongketnoi_btn = new Button();
            SuspendLayout();
            // 
            // ketnoi_btn
            // 
            ketnoi_btn.Location = new Point(144, 161);
            ketnoi_btn.Name = "ketnoi_btn";
            ketnoi_btn.Size = new Size(190, 124);
            ketnoi_btn.TabIndex = 0;
            ketnoi_btn.Text = "Mở kết nối";
            ketnoi_btn.UseVisualStyleBackColor = true;
            ketnoi_btn.Click += ketnoi_btn_Click;
            // 
            // dongketnoi_btn
            // 
            dongketnoi_btn.Location = new Point(463, 161);
            dongketnoi_btn.Name = "dongketnoi_btn";
            dongketnoi_btn.Size = new Size(180, 124);
            dongketnoi_btn.TabIndex = 1;
            dongketnoi_btn.Text = "Đóng kết nối";
            dongketnoi_btn.UseVisualStyleBackColor = true;
            dongketnoi_btn.Click += dongketnoi_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dongketnoi_btn);
            Controls.Add(ketnoi_btn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button ketnoi_btn;
        private Button dongketnoi_btn;
    }
}
