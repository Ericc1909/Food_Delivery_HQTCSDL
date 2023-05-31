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
    public partial class form_DH_KH : Form
    {
        string MaKH;
        public form_DH_KH(string makh)
        {
            MaKH = makh;
            InitializeComponent();
            refresh_dataGridView1();
            refresh_dataGridView2();
            refresh_dataGridView3();
        }

        private void refresh_dataGridView1()
        {
            dataGridView1.Refresh();
            string query = "select * from DONDATHANG where MA_KHACH_HANG = '" + MaKH + "' and TINH_TRANG= N'đang giao'";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Dataprovider.Instance.ExecuteQuery(query);
        }

        private void refresh_dataGridView2()
        {
            dataGridView2.Refresh();
            string query = "select * from DONDATHANG where MA_KHACH_HANG = '" + MaKH + "' and TINH_TRANG= N'đang giao'";
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.DataSource = Dataprovider.Instance.ExecuteQuery(query);
        }
        private void refresh_dataGridView3()
        {
            dataGridView3.Refresh();
            string query = "select * from DONDATHANG where MA_KHACH_HANG = '" + MaKH + "' and TINH_TRANG= N'chờ xác nhận'";
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.DataSource = Dataprovider.Instance.ExecuteQuery(query);
        }
        private void bt_huy_dh_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void form_DH_KH_Load(object sender, EventArgs e)
        {

        }
    }
}

