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
    public partial class form_CH_KH : Form
    {
        string macuahang;
        public string makh;
        public form_CH_KH(string maKH)
        {
            makh = maKH;
            InitializeComponent();
        }

        private void bt_xemDs_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = GetDSDoiTac().Tables[0];
        }

        DataSet GetDSDoiTac()
        {
            DataSet data = new DataSet();

            string query2 = "exec sp_KH_XemDSDoiTac";

            using (SqlConnection connection = new SqlConnection(ConnectionString.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        private void bt_ch_view_Click(object sender, EventArgs e)
        {

            macuahang = txb_maCH.Text.Trim().ToString();
            if (macuahang.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã cửa hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                form_xemDSmon dsmon = new form_xemDSmon(macuahang);

                dsmon.Show();

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txb_maCH.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txbox_tendoitac.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tx_box_diachi.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + ", " + dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void bt_dathang_Click(object sender, EventArgs e)
        {
            macuahang = txb_maCH.Text.Trim().ToString();
            if (macuahang.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã cửa hàng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string madon;
                madon = "";
                string sqlnew = "select count(*) from DONDATHANG";
                int ma = (int)Dataprovider.Instance.ExecuteScalar(sqlnew) + 1;
                if (ma > 10)
                {
                    madon = "DH0" + ma;
                }
                else if (ma > 100)
                {
                    madon = "DH" + ma;
                }
                else if (ma < 10)
                {
                    madon = "DH00" + ma;
                }
                DS_Mon dsmon = new DS_Mon(macuahang, madon, makh);

                dsmon.Show();

                // DS_Mon dsmon = new DS_Mon(macuahang, madon);


            }
        }

        private void form_CH_KH_Load(object sender, EventArgs e)
        {

        }
    }
}
