using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop_Management_interface
{
    internal static class Program
    {
        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(int value);

        [STAThread]
        static void Main()
        {
            SetProcessDpiAwareness(2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////Hiển thị SplashForm :
            SplashForm splash = new SplashForm();
            splash.Show();
            Application.Run(splash);

            
            


            //Mở LoginForm
            LoginForm login = new LoginForm();
            if (login.ShowDialog() == DialogResult.OK)
            {
                //Đăng nhập thành công --> mở MainForm
                Application.Run(new MainForm());
            }


        }
    }
}
