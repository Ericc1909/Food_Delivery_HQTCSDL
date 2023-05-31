using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace QL_DatHang_GiaoHang
{
    public partial class CuaHang : Form
    {
        SqlConnection connect;
        public string temp;
        public string temp1;
        Thread t;

        public bool MultipleActiveResultSets { get; private set; }

        public CuaHang(string MACH)
        {
            temp = MACH;
            InitializeComponent();
        }

        public void display1()
        {
            string sqlselect1 = "SELECT * FROM HOPDONG WHERE MA_HOP_DONG = '" + textBox7.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(sqlselect1, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            dataGridView2.RowHeadersVisible = false;
        }

        public void displaySP()
        {
            string sqlselect1 = "SELECT MON_AN.MA_MON_AN AS N'Mã Món Ăn', TEN_MON AS N'Tên món', TINH_TRANG AS N'Tình Trạng', DON_GIA AS N'Đơn giá', MA_CHI_NHANH AS N'Chi nhánh',SO_LUONG AS 'Số lượng' FROM MON_AN, MON_AN_CHI_NHANH WHERE MON_AN.MA_MON_AN = MON_AN_CHI_NHANH.MA_MON_AN AND MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd = new SqlCommand(sqlselect1, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView5.DataSource = dt;
            dataGridView5.RowHeadersVisible = false;
        }

        private void CuaHang_Load(object sender, EventArgs e)
        {
            //connect = new SqlConnection(@"Data Source=DESKTOP-CROF7BN\SQLEXPRESS;Initial Catalog=Ql_DATHANG_BANHANG;Integrated Security=True;MultipleActiveResultSets=true");
            connect = new SqlConnection(@"data Source=DESKTOP-GFADSU2\SQLEXPRESS;Initial Catalog=Ql_DATHANG_BANHANG;Integrated Security=True");

            connect.Open();

            label3.Text = temp;
        

            textBox1.Text = temp;
            textBox2.Text = temp;
            textBox19.Text = temp1;

            string sqlselect3 = "SELECT SDT FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd3 = new SqlCommand(sqlselect3, connect);
            textBox20.Text = Convert.ToString(cmd3.ExecuteScalar());

            string sqlselect4 = "SELECT SO_CHI_NHANH FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd4 = new SqlCommand(sqlselect4, connect);
            textBox22.Text = Convert.ToString(cmd4.ExecuteScalar());

            string sqlselect7 = "SELECT QUAN FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd7 = new SqlCommand(sqlselect7, connect);
            textBox21.Text = Convert.ToString(cmd7.ExecuteScalar());

            string sqlselect8 = "SELECT THANH_PHO FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd8 = new SqlCommand(sqlselect8, connect);
            comboBox1.Text = Convert.ToString(cmd8.ExecuteScalar());

            string sqlselect9 = "SELECT EMAIL FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd9 = new SqlCommand(sqlselect9, connect);
            textBox23.Text = Convert.ToString(cmd9.ExecuteScalar());

            string sqlselect10 = "SELECT MA_SO_THUE FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd10 = new SqlCommand(sqlselect10, connect);
            textBox24.Text = Convert.ToString(cmd10.ExecuteScalar());


            string sqlselect11 = "SELECT NGUOI_DAI_DIEN FROM CUAHANG WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd11 = new SqlCommand(sqlselect11, connect);
            textBox25.Text = Convert.ToString(cmd11.ExecuteScalar());


            //display1();
            displaySP();
            displayCN();
            button6.Enabled = false;
            button13.Enabled = false;
        }

        public void open_FormDangNhap(object obj)
        {
            Application.Run(new Login());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                connect.Close();
                t = new Thread(open_FormDangNhap);
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            display1();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlselect4 = "UPDATE CUAHANG SET SDT = @SDT, QUAN = @QUAN, SO_CHI_NHANH = @SCN, EMAIL = @EM WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd4 = new SqlCommand(sqlselect4, connect);
            cmd4.Parameters.Add(new SqlParameter("@SDT", textBox20.Text.Trim()));
            cmd4.Parameters.Add(new SqlParameter("@QUAN", textBox21.Text.Trim()));
            cmd4.Parameters.Add(new SqlParameter("@EM", textBox23.Text.Trim()));
            cmd4.Parameters.Add(new SqlParameter("@SCN", textBox22.Text.Trim()));
            cmd4.ExecuteNonQuery();

            DialogResult res = MessageBox.Show("Cập nhật thành công!", "Thông báo");
            if (res == DialogResult.OK)
            {
                return;
            }

        }


        private void button6_Click(object sender, EventArgs e)
        {
            string sqlselect4 = "EXEC dbo.USP_DT_CAPNHAT_GIA_MONAN @MA_MON_AN, @GIA_UPDATE";
            SqlCommand cmd4 = new SqlCommand(sqlselect4, connect);
            cmd4.Parameters.Add(new SqlParameter("@MA_MON_AN", textBox8.Text.Trim()));
            cmd4.Parameters.Add(new SqlParameter("@GIA_UPDATE", textBox18.Text.Trim()));
            cmd4.ExecuteNonQuery();
            displaySP();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            string sqlselect4 = "EXEC dbo.SP_CH_CAP_NHAT_SL_MON_AN @MA_CHI_NHANH, @MA_MON_AN, @SO_LUONG_THEM";
            SqlCommand cmd4 = new SqlCommand(sqlselect4, connect);
            cmd4.Parameters.Add(new SqlParameter("@MA_MON_AN", textBox8.Text.Trim()));
            cmd4.Parameters.Add(new SqlParameter("@MA_CHI_NHANH", textBox9.Text.Trim()));
            cmd4.Parameters.Add(new SqlParameter("@SO_LUONG_THEM", numericUpDown2.Text.Trim()));
            cmd4.ExecuteNonQuery();
            displaySP();

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox9.Text = dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox17.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            //numericUpDown2.Text = dataGridView5.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox18.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();

            button6.Enabled = true;
            button13.Enabled = true;
            textBox17.Enabled = false;
            numericUpDown2.Enabled = true;
        }




        public void displayCN()
        {
            string sqlselect1 = "SELECT MA_CHI_NHANH AS N'Mã CN', SL_DON_MOINGAY AS N'SL đơn mỗi ngày', DIA_CHI AS 'Địa chỉ', SDT AS N'SDT', TINH_TRANG AS N'Tình trạng', MA_HOP_DONG AS N'Mã HĐ', KHUVUC AS N'Khu vực' FROM CHINHANH WHERE MA_CUA_HANG = '" + temp + "'";
            SqlCommand cmd = new SqlCommand(sqlselect1, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView4.DataSource = dt;
            dataGridView4.RowHeadersVisible = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string sqlselect1 = "SELECT MA_DON AS N'Mã ĐH', MA_KHACH_HANG AS N'Mã khách hàng', TINH_TRANG AS N'Tình trạng ĐH', CAST(PHI_VAN_CHUYEN AS NUMERIC(10,0)) AS N'Phí vận chuyển', CAST(TONG_TIEN AS NUMERIC(10,0)) AS N'Tổng tiền' FROM DONDATHANG ";
            SqlCommand cmd = new SqlCommand(sqlselect1, connect);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;
            //displayDH();
            button3.Enabled = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string sqlselect4 = "SELECT MA_HOP_DONG AS N'Mã HĐ', MA_CUA_HANG AS N'Mã CH', NGAY_TAO AS N'Ngày tạo', TG_BAT_DAU AS 'TG bắt đầu', TG_KET_THUC AS N'TG kết thúc', STK AS N'STK', MA_NHAN_VIEN AS N'Mã nhân viên',TRANG_THAI AS N'Trạng thái' FROM HOPDONG WHERE MA_HOP_DONG = '" + textBox7.Text.Trim() + "'";
                SqlCommand cmd4 = new SqlCommand(sqlselect4, connect);
                SqlDataReader dr = cmd4.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dataGridView2.RowHeadersVisible = false;

            }
            //displayHD();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlselect4 = "EXEC dbo.sp_DT_ThemChiNhanh @machinhanh, @diachi, @sdt, @macuahang, @mahopdong, @khuvuc";
                SqlCommand cmd4 = new SqlCommand(sqlselect4, connect);
                cmd4.Parameters.Add(new SqlParameter("@machinhanh", textBox3.Text.Trim()));
                cmd4.Parameters.Add(new SqlParameter("@diachi", textBox5.Text.Trim()));
                cmd4.Parameters.Add(new SqlParameter("@sdt", textBox6.Text.Trim()));
                cmd4.Parameters.Add(new SqlParameter("@macuahang", textBox2.Text.Trim()));
                cmd4.Parameters.Add(new SqlParameter("@mahopdong", textBox11.Text.Trim()));
                cmd4.Parameters.Add(new SqlParameter("@khuvuc", textBox13.Text.Trim()));
                cmd4.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã có lỗi xảy ra\nVui lòng kiểm tra thông tin đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            displayCN();
        }

    }
}