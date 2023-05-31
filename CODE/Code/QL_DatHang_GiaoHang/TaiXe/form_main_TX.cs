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
    public partial class form_main_TX : Form
    {
        Thread t;
        public form_main_TX()
        {
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
            foreach (Control previousBtn in flpMenuTX.Controls)
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
            pnChildFormTX.Controls.Add(childForm);
            pnChildFormTX.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private Form activeform = null;
        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Login());
        }

        private void bt_tt_tx_Click(object sender, EventArgs e)
        {
            openChildForm(new form_ThongTin_TX());
            ActivateButton(sender);
        }

        private void bt_dsd_tx_Click(object sender, EventArgs e)
        {
            openChildForm(new form_DSDon_TX());
            ActivateButton(sender);
        }

        private void bt_dx_tx_Click(object sender, EventArgs e)
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



        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new form_CN_TX());
            ActivateButton(sender);
        }

        private void bt_ddn_tx_Click(object sender, EventArgs e)
        {
            openChildForm(new form_DDN_TX());
            ActivateButton(sender);
        }

        private void form_main_TX_Load(object sender, EventArgs e)
        {

        }
    }
}
