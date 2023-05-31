using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DatHang_GiaoHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new NhanVien_main());
            //Application.Run(new Login());
            //Application.Run(new CuaHang());
            //Application.Run(new form_khachhang());
            Application.Run(new Login());
        }
    }
}
