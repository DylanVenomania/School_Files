using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    public partial class ChangeAvatarAdmin : Form
    {
        public ChangeAvatarAdmin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Choose avatar";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void ChangeAvatarAdmin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (picAvatar.Image != null)
            {
                string saveDirectory = @"D:\Nam2_2024_2025\Hocki2\LaptrinhWindow\Do_an\Avatar\";
                string savePath = Path.Combine(saveDirectory, "avatar.png");

                try
                {
                    // Tạo thư mục nếu chưa có
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                    // Tạo bản sao ảnh để tránh lỗi do ảnh đang bị PictureBox giữ lock
                    using (Bitmap bmp = new Bitmap(picAvatar.Image))
                    {
                        bmp.Save(savePath, ImageFormat.Png);
                    }

                    MessageBox.Show("Avatar đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa có ảnh để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
