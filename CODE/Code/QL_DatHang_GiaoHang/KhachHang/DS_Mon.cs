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
    public partial class DS_Mon : Form
    {
        private string MaCH, MaDon, makh;
        public DS_Mon(string MaCH, string MaDon, string maKH)
        {
            this.MaCH = MaCH;
            this.MaDon = MaDon;
            this.makh = maKH;
            InitializeComponent();
            refresh_dataGridView_chinhanh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = GetDSMon().Tables[0];
        }

        DataSet GetDSMon()
        {
            DataSet data1 = new DataSet();

            string query1 = "exec sp_KH_xem_MonAN  '" + MaCH + "'";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter(query1, connection);
                adapter1.Fill(data1);
                connection.Close();
            }
            return data1;
        }

        private void refresh_dataGridView_chinhanh()
        {
            dataGridView2.Refresh();
            string query = "select MA_CHI_NHANH, DIA_CHI, SDT, TINH_TRANG from CHINHANH  where MA_CUA_HANG= '" + MaCH + "'";
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = Dataprovider.Instance.ExecuteQuery(query);
        }
        private void bt_ql_KH_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string test = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            float dongia = (float)Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[2].Value);
            if (test == "có bán")
            {
                tb_mamon.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tb_tenmon.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tb_giamon.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
            else
            {
                MessageBox.Show("Món ăn này không còn hôm nay", "Thông báo");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đặt hàng thành công", "Thông báo");
        }

        private void DS_Mon_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tb_chinhanh.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void bt_themmon_KH_Click(object sender, EventArgs e)
        {
            string mamon = tb_mamon.Text.Trim().ToString();
            string tenmon = tb_tenmon.Text.Trim().ToString();
            string soluong = tb_soluong.Text.Trim();
            int phivc = 15000;
            string maChiNhanh = tb_chinhanh.Text.Trim().ToString();
            string diachi = tb_diachi.Text.Trim().ToString();
            if( mamon.Length==0 | soluong.Length==0| maChiNhanh.Length==0| diachi.Length==0)
            {
                MessageBox.Show("Đặt hàng không thành công", "Thông báo");
            }
            else
            {
                string sql1 = " exec SP_KHACH_HANG_DAT_HANG_MON_AN @MA_DON , @MA_MON_AN , @SO_LUONG , @DIA_CHI , @PHI_VAN_CHUYEN , @MA_KHACH_HANG , @MA_CHI_NHANH ";
                Dataprovider.Instance.ExecuteNonQuery(sql1, new object[] { MaDon, mamon, soluong, diachi, phivc, makh, maChiNhanh });
                dataGridView1.Refresh();
                MessageBox.Show("Đặt hàng thành công", "Thông báo");
                this.Close();
            }
           
        }
    }
}
