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
    public partial class DKi_KH : Form
    {
        SqlConnection connect;
        public DKi_KH()
        {
            InitializeComponent();
        }
        private void KH_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(@"Data Source=HONGQUAN\SQLEXPRESS;Initial Catalog=QL_DH_GH_ONLINE;Integrated Security=True");
            connect.Open();
        }

        private void KH_Close(object sender, FormClosingEventArgs e)
        {
            connect.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql1 = "select count(*) from KHACHHANG";
            int ma = (int)Dataprovider.Instance.ExecuteScalar(sql1) + 1;
            string makh = "";
            if (ma > 10)
            {
                makh = "KH0" + ma;
            }
            if (ma > 100)
            {
                makh = "KH" + ma;
            }
            if (ma < 10)
            {
                makh = "KH00" + ma;
            }
            string sqlselect1 = "select count(*) from TAIKHOAN";
            int id = 0;
            id = (int)Dataprovider.Instance.ExecuteScalar(sqlselect1) + 1;
            string hoten = textBox1.Text;
            string diachi = textBox2.Text;
            string sdt = textBox3.Text;
            string email = textBox4.Text;
            if (textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty || textBox3.Text.Trim() == string.Empty || textBox4.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo!");
            }
            else
            {
                string sqlKH = "exec ThemKH @makh , @hoten , @diachi , @sdt , @email ";
                Dataprovider.Instance.ExecuteQuery(sqlKH, new object[] { makh, hoten, diachi, sdt, email });
                groupBox2.Visible = true;
                button2.Visible = false;
            }
        }

        private void textBox6_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sqlselect1 = "select count(*) from TAIKHOAN";
            int id = 0;
            id = (int)Dataprovider.Instance.ExecuteScalar(sqlselect1) + 1;
            string username = textBox5.Text;
            string password = textBox6.Text;
            int loaitk = 1;
            string sqlselect2 = "select count(*) from TAIKHOAN where TEN_DANG_NHAP = @username";
            if ((int)Dataprovider.Instance.ExecuteScalar(sqlselect2, new object[] { username }) == 1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo!");
            }
            else
            {
                string sql3 = "exec ThemTK @idtk , @username , @pass , @loaitk";
                Dataprovider.Instance.ExecuteQuery(sql3, new object[] { id, username, password, loaitk });

                string sql4 = "update KHACHHANG set ID_TAI_KHOAN = @id where email = @email";
                string email = textBox4.Text;
                Dataprovider.Instance.ExecuteQuery(sql4, new object[] { id, email });
                MessageBox.Show("Đăng kí thành công!", "Thông báo!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void DKi_KH_Load(object sender, EventArgs e)
        {

        }
    }
}
