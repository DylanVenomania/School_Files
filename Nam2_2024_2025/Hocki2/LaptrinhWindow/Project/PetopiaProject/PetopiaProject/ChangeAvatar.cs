using ClosedXML.Excel;
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
    public partial class ChangeAvatar : Form
    {
        public ChangeAvatar()
        {
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (picAvatar.Image != null)
            {
                string saveDirectory = "D:/Nam2_2024_2025/Hocki2/LaptrinhWindow/Do_an/Avatar/";
                string savePath = saveDirectory + "avatar.png";

                // Đảm bảo thư mục tồn tại trước khi lưu
                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }

                // Tạo bản sao ảnh để tránh lỗi khóa file
                using (Bitmap bmp = new Bitmap(picAvatar.Image))
                {
                    bmp.Save(savePath, ImageFormat.Png);
                }

                MessageBox.Show("Avatar đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ChangeAvatar_Load(object sender, EventArgs e)
        {

        }

        private void btnChoose_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Choose avatar";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (picAvatar.Image != null)
            {
                string saveDirectory = @"D:\Nam2_2024_2025\Hocki2\LaptrinhWindow\Do_an\Avatar1\";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int employeeId = LoginForm.ACCOUNT_ID;
            try
            {
                PETSHOPDataContext db = new PETSHOPDataContext();
                {
                    // Giả sử bạn đã có biến `employeeId` chứa ID nhân viên cần sửa
                    var employee = db.USERs.FirstOrDefault(p => p.ID == employeeId);
                    if (employee != null)
                    {
                        // Kiểm tra tên (không rỗng và có ít nhất 2 ký tự)
                        if (!string.IsNullOrWhiteSpace(txtName.Text) && txtName.Text.Trim().Length >= 2)
                        {
                            employee.Name = txtName.Text.Trim();
                        }
                        else
                        {
                            MessageBox.Show("Tên không được để trống và phải có ít nhất 2 ký tự.");
                            return;
                        }

                        // Kiểm tra địa chỉ (không rỗng)
                        if (!string.IsNullOrWhiteSpace(txt_Address.Text))
                        {
                            employee.Address = txt_Address.Text.Trim();
                        }
                        else
                        {
                            MessageBox.Show("Địa chỉ không được để trống.");
                            return;
                        }

                        // Kiểm tra số điện thoại (10 chữ số, chỉ chứa số)
                        if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                        {
                            string phone = txtPhone.Text.Trim();
                            if (phone.Length == 10 && phone.All(char.IsDigit))
                            {
                                employee.Phone = phone;
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại phải có 10 chữ số và chỉ chứa số.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại không được để trống.");
                            return;
                        }

                        // Kiểm tra ngày sinh (phải là trong quá khứ và người đó trên 18 tuổi)
                        DateTime dob = dtDoB.Value.Date;
                        int age = DateTime.Now.Year - dob.Year;
                        if (dob < DateTime.Now.Date && age >= 18)
                        {
                            employee.Dateofbirth = dob;
                        }
                        else
                        {
                            MessageBox.Show("Ngày sinh không hợp lệ. Nhân viên phải trên 18 tuổi.");
                            return;
                        }


                        db.SubmitChanges();

                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txt_Address.Clear();
            txtPhone.Clear();
            dtDoB.Value = DateTime.Now;
        }
    }
}
