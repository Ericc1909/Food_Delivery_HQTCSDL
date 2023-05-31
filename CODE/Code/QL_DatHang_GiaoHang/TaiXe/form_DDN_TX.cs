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
    public partial class form_DDN_TX : Form
    {
        public form_DDN_TX()
        {
            InitializeComponent();
        }

        private void bt_XemCT_Click(object sender, EventArgs e)
        {
            Form f = new form_CTDon_TX();

            f.Show();
        }

        private void form_DDN_TX_Load(object sender, EventArgs e)
        {

        }
    }
}
