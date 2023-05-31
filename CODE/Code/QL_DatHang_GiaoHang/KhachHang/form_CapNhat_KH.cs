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
    public partial class form_CapNhat_KH : Form
    {
        string tendangnhap;
        string matkhau;
        string matkhaumoi;
        string confirmmatkhau;
        public form_CapNhat_KH(string makh)
        {
            InitializeComponent();
        }

        private void bt_CapNhat_Click(object sender, EventArgs e)
        {
            tendangnhap = txtBox_tendangnhap.Text.Trim().ToString();
            matkhau = txtBox_matkhau.Text.Trim().ToString();
            matkhaumoi = tb_pwnew.Text.Trim().ToString();
            confirmmatkhau = tb_confirm.Text.Trim().ToString();

            if (tendangnhap.Length == 0 | matkhau.Length == 0 | matkhaumoi.Length == 0 | confirmmatkhau.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void form_CapNhat_KH_Load(object sender, EventArgs e)
        {

        }
    }
}
