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
    public partial class DKi : Form
    {
        public DKi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DKi_KH KH = new DKi_KH();
            KH.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DKi_TX TX = new DKi_TX();
            TX.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DKi_CH CH = new DKi_CH();
            CH.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login DN = new Login();
            DN.Show();
            this.Hide();
        }

        private void DKi_Load(object sender, EventArgs e)
        {

        }
    }
}
