using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QL_DatHang_GiaoHang
{
   
    public partial class NhanVien_main : Form
    {
        Thread t;
        public string USERNAME = "";
        public string PASSWORD = "";
        public NhanVien_main(string username , string password)
        {
            InitializeComponent();
            USERNAME = username;
            PASSWORD = password;
        }
                
        private void btn_TaiKhoan_Click(object sender, EventArgs e)
        {
            Form f = new NhanVien_ThongTinChiTiet(USERNAME,PASSWORD);
            f.ShowDialog();
        
        }

        // xử lí đăng xuất + đăng nhập lại
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Login());
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn muốn đăng xuất tài khoản ?", "thông báo", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                t = new Thread(open_FormDangNhap);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                this.Close();

            }
        }

        private void btnQL_HopDong_Click(object sender, EventArgs e)
        {
            Form f = new NhanVien_QuanLyHopDong();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void NhanVien_main_Load(object sender, EventArgs e)
        {

        }

        private void panelForChilForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
