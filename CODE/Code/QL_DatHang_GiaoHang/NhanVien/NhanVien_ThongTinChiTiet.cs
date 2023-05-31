using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_DatHang_GiaoHang
{
    public partial class NhanVien_ThongTinChiTiet : Form
    {
        NhanVien_main NV;
        string userName = "";
        string passWord = "";
        public NhanVien_ThongTinChiTiet(string username , string password)
        {
            InitializeComponent();
            panel_CapNhatHopDong.Hide();
            pictureBox_avt.SizeMode = PictureBoxSizeMode.StretchImage;

            userName = username;
            passWord = password;
        }

        public int GetIDTaIKhoan_byUserName(string UserName)
        {
            
            return 0;
        }


        private void btn_changePicture_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                             // "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox_avt.ImageLocation = imageLocation;
                }
            }
            catch (Exception) { 

                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Get_Updated_SatffDetail()
        {
           
        }
        private void hanlde_updateInfor(string HoTen , string MatKhauMoi , string Gmail , string DiaChi , string SDT)
        {
            //sql
        }

        private void btn_LuuThayDoi_Click(object sender, EventArgs e)
        {
            string HoTen = textb_HoTen.Text;
            string MatKhau = textb_Matkhau.Text;
            string MatKhauMoi = textb_MatKhauMoi.Text;
            string MatKhauXacNhan = textb_XacNhanMatKhau.Text;
            string Gmail = textb_Gmail.Text;
            string DiaChi = textb_DiaChi.Text;
            string SDT = textb_SDT.Text;

            DialogResult result = MessageBox.Show("", "thông báo", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                return;
            }



            panel_CapNhatHopDong.Hide();
            textb_MatKhauMoi.Text = "";
            textb_XacNhanMatKhau.Text = "";
        }

        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            panel_CapNhatHopDong.Show();
        }

        private void textb_MatKhauMoi_TextChanged(object sender, EventArgs e)
        {

        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            panel_CapNhatHopDong.Hide();
            textb_MatKhauMoi.Text = "";
            textb_XacNhanMatKhau.Text = "";
            DialogResult result = MessageBox.Show("Bạn muốn thoát ?", "thông báo", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void NhanVien_ThongTinChiTiet_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_avt_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
