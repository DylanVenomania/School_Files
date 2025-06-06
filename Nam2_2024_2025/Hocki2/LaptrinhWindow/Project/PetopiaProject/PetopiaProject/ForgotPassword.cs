using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Pet_Shop_Management_interface
{
    public partial class ForgotPassword : Form
    {
        PETSHOPDataContext context = new PETSHOPDataContext();
        public int otp;
        public USER user;

        int expiryMinutes = 1; // OTP expiry time
        DateTime expiryTime;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter your email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            user = context.USERs.FirstOrDefault(x => x.Email == txtEmail.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("Email not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Random random = new Random();
            bool IsDuplicate;
            do
            {
                otp = random.Next(100000, 999999); // random OTP 6 numbers

                // Check exist OTP in DB
                IsDuplicate = context.USERs.Any(x => x.OTP == otp);

            } while (IsDuplicate);

            user.OTP = otp;
            context.SubmitChanges();

            var fromAddress = new MailAddress("petopiashop.services@gmail.com");
            var toAddress = new MailAddress(txtEmail.Text.Trim());
            const string fromPass = "fftb mpsa zzax ptuw";
            const string subject = "OTP Verification - Petopia 🐾";
            string username = context.USERs.FirstOrDefault(x => x.Email == txtEmail.Text.Trim()).Name;
            string body = $"Hello {username},\n\n" +
                          $"Thank you for using Petopia's services!\n" +
                          $"Your OTP code is: {otp}\n" +
                          $"(This code is valid for {expiryMinutes} minutes.)\n\n" +
                          "Please do not share this OTP with anyone to protect your account.\n\n" +
                          "If you did not request this code, please ignore this email.\n\n" +
                          "Best regards,\n" +
                          "Petopia Team 🐾";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPass),
                Timeout = 200000
            };

            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("OTP is sent to mail!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                expiryTime = DateTime.Now.AddMinutes(expiryMinutes);
                timer1.Start();
                timer1.Interval = 1000; // 1 second
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOTP.Text.Trim()))
            {
                MessageBox.Show("Please enter your OTP", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (user == null)
            {
                MessageBox.Show("Email not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTime.Now > expiryTime)
            {
                user.OTP = null;
                context.SubmitChanges();
                MessageBox.Show("Your OTP has expired!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChangePassword changePasswordForm = new ChangePassword(this);
            if (txtOTP.Text.Trim() == user.OTP.ToString())
            {
                user.OTP = null;
                context.SubmitChanges();
                this.Dispose();
                changePasswordForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your OTP is not correct!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            LoginForm loginform = new LoginForm();
            loginform.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (user.OTP != null)
            {
                txtOTPTimer.Text = (expiryTime - DateTime.Now).ToString(@"mm\:ss");
            }
            if (DateTime.Now > expiryTime && user.OTP != null)
            {
                user.OTP = null;
                context.SubmitChanges();
                txtOTPTimer.Text = "Expired";
            }
        }
    }
}
