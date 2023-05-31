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
    public partial class DKi_TX : Form
    {
        public DKi_TX()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "select count(*) from TAIKHOAN";
            int id = 0;
            id = (int)Dataprovider.Instance.ExecuteScalar(sqlselect1) + 1;
            string username = textBox9.Text;
            string password = textBox10.Text;
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
                string sql4 = "update TAIXE set ID_TAI_KHOAN = @id where email = @email";
                string email = textBox6.Text;
                Dataprovider.Instance.ExecuteQuery(sql4, new object[] { id, email });
                MessageBox.Show("Đăng kí thành công!", "Thông báo!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql1 = "select count(*) from TAIXE";
            int ma = (int)Dataprovider.Instance.ExecuteScalar(sql1) + 1;
            string matx = "";
            if (ma > 10)
            {
                matx = "TX0" + ma;
            }
            if (ma > 100)
            {
                matx = "TX" + ma;
            }
            if (ma < 10)
            {
                matx = "TX00" + ma;
            }
            string sqlselect1 = "select count(*) from TAIKHOAN";
            int id = 0;
            id = (int)Dataprovider.Instance.ExecuteScalar(sqlselect1) + 1;
            string hoten = textBox1.Text;

            string sdt = textBox2.Text;
            string email = textBox6.Text;
            string cmnd = textBox4.Text;
            string bienso = textBox7.Text;
            string mathue = textBox5.Text;
            string khuvuchd = comboBox1.Text;
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty || textBox5.Text.Trim() == string.Empty || textBox6.Text.Trim() == string.Empty || textBox7.Text.Trim() == string.Empty || comboBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!");
            }
            else
            {
                string sqlTX = "exec ThemTX @matx , @hoten , @sdt , @bienso , @cmnd , @mathue , @email , @khuvuc ";
                Dataprovider.Instance.ExecuteQuery(sqlTX, new object[] { matx, hoten, sdt, bienso, cmnd, mathue, email, khuvuchd });
                groupBox2.Visible = true;
                button3.Visible = false;
            }
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

        private void DKi_TX_Load(object sender, EventArgs e)
        {

        }
    }
}
