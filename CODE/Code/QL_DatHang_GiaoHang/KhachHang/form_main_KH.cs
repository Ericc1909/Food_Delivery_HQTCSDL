using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QL_DatHang_GiaoHang
{
    public partial class form_khachhang : Form
    {
        private string MaKH;

        Thread t;
        public form_khachhang(string maKH)
        {
            MaKH = maKH;
            InitializeComponent();
        }

        private Button currentButton;
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = ColorTranslator.FromHtml("#4169E1");
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in flpMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(255, 255, 255);
                    previousBtn.ForeColor = Color.Black;
                }
            }
        }

        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnChildFormKH.Controls.Add(childForm);
            pnChildFormKH.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void open_FormDangNhap(object obj)
        {
            // Application.Run(new Form_DangNhap());
        }

        private Form activeform = null;

        private void bt_tx_tt_Click(object sender, EventArgs e)
        {
            openChildForm(new form_thongtinKH(MaKH));
            ActivateButton(sender);
        }

        private void bt_tx_dx_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("bạn muốn đăng xuất tài khoản ?", "thông báo", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                t = new Thread(open_FormDangNhap);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                this.Close();

            }
        }

        private void bt_kh_cn_Click(object sender, EventArgs e)
        {
            openChildForm(new form_CapNhat_KH(MaKH));
            ActivateButton(sender);
        }

        private void bt_kh_dh_Click(object sender, EventArgs e)
        {
            openChildForm(new form_CH_KH(MaKH));
            ActivateButton(sender);
        }

        private void bt_kh_donhang_Click(object sender, EventArgs e)
        {
            openChildForm(new form_DH_KH(MaKH));
            ActivateButton(sender);
        }

        private void form_khachhang_Load(object sender, EventArgs e)
        {

        }
    }
}
