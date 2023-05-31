using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_DatHang_GiaoHang
{
    public partial class form_xemDSmon : Form
    {
        private string MaCH;

        public form_xemDSmon(string MaCH)
        {
            this.MaCH = MaCH;
            InitializeComponent();
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

        private void form_xemDSmon_Load(object sender, EventArgs e)
        {

        }
    }
}
