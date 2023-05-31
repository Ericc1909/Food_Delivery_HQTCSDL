using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DatHang_GiaoHang
{
    public partial class DKi_CH : Form
    {
        public DKi_CH()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql1 = "select count(*) from CUAHANG";
            int ma = (int)Dataprovider.Instance.ExecuteScalar(sql1) + 1;
            string mach = "";
            if (ma > 10)
            {
                mach = "CH0" + ma;
            }
            if (ma > 100)
            {
                mach = "CH" + ma;
            }
            if (ma < 10)
            {
                mach = "CH00" + ma;
            }
            string sqlselect1 = "select count(*) from TAIKHOAN";
            int id = 0;
            id = (int)Dataprovider.Instance.ExecuteScalar(sqlselect1) + 1;
            string tench = textBox1.Text;

            string tp = textBox2.Text;
            string email = textBox4.Text;
            string sochinhanh = textBox3.Text;
            string quan = textBox5.Text;
            string masothue = textBox6.Text;
            string nguoidaidien = textBox7.Text;
            string sdt = textBox10.Text;
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!");
            }
            else
            {
                string sqlCH = "exec ThemCH @mach , @tench , @email , @tp , @quan , @sdt , @sochinhanh , @nguoidaidien , @masothue";
                Dataprovider.Instance.ExecuteQuery(sqlCH, new object[] { mach, tench, email, tp, quan, sdt, sochinhanh, nguoidaidien, masothue });
                groupBox2.Visible = true;
                button3.Visible = false;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "select count(*) from TAIKHOAN";
            int id = 0;
            id = (int)Dataprovider.Instance.ExecuteScalar(sqlselect1) + 1;
            string username = textBox8.Text;
            string password = textBox9.Text;
            int loaitk = 2;
            string sqlselect2 = "select count(*) from TAIKHOAN where TEN_DANG_NHAP = @username";
            if ((int)Dataprovider.Instance.ExecuteScalar(sqlselect2, new object[] { username }) == 1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo!");
            }
            else
            {
                string sql3 = "exec ThemTK @idtk , @username , @pass , @loaitk";
                Dataprovider.Instance.ExecuteQuery(sql3, new object[] { id, username, password, loaitk });
                string sql4 = "update CUAHANG set ID_TAI_KHOAN = @id where email = @email";
                string email = textBox4.Text;
                Dataprovider.Instance.ExecuteQuery(sql4, new object[] { id, email });
                MessageBox.Show("Đăng kí thành công!", "Thông báo!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DKi DK = new DKi();
            DK.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void DKi_CH_Load(object sender, EventArgs e)
        {

        }
    }
}
