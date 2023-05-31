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
using System.Threading;


namespace QL_DatHang_GiaoHang
{
    public partial class Login : Form
    {
        SqlConnection connect;
        Thread t;
        string USERNAME = "";
        string PASSWORD = "";
        string MAKH = "";
        string MACH = "";
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(@"Data Source=DESKTOP-G8E20U2;Initial Catalog=Ql_DATHANG_BANHANG_HQTCSDL;Integrated Security=True");
            connect.Open();
        }

        private void Login_Close(object sender, FormClosingEventArgs e)
        {
            connect.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DKi DK = new DKi();
            DK.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            USERNAME = username;
            PASSWORD = password;
           
            string role = comboBox1.Text.ToString();
            int rolenumber = 0;
            if (role == "Nhân viên"){rolenumber = 3;}
            if (role == "Đối tác(Cửa hàng)"){rolenumber = 0;}
            if (role == "Khách hàng"){rolenumber = 1;}
            if (role == "Tài xế"){rolenumber = 2;}
            if (role == "Admin"){rolenumber = 4;}

            //string sqlselect = "SELECT * FROM dbo.TAIKHOAN WHERE TEN_DANG_NHAP = '" + username + "' AND MAT_KHAU = '" + password + "' AND LOAI_TK = " + rolenumber ;
            //SqlDataAdapter sda = new SqlDataAdapter(sqlselect, connect);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);


            string query = "select count(*) from TAIKHOAN where TRANG_THAI = 1 and TEN_DANG_NHAP = @username and MAT_KHAU = @password and LOAI_TK = @rolenumber ";
            if ((int)Dataprovider.Instance.ExecuteScalar(query, new object[] { username, password, rolenumber }) == 1)
            {
                DialogResult res = MessageBox.Show("Đăng nhập thành công!", "Thông báo!");
                if (res == DialogResult.OK)
                {
                    if (rolenumber == 4) // admin
                    {
                        t = new Thread(runAminForm);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        this.Hide();
                       
                    }
                    else if(rolenumber == 3) // nhân viên 
                    {
                        t = new Thread(runNhanVienForm);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        this.Hide();
                    }
                    else if (rolenumber == 2) // tài xế
                    {
                       
                        t = new Thread(runTaiXeForm);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        this.Hide();
                    }
                    else if (rolenumber == 1) // khách hàng
                    {
                        MAKH = getID_KhachHang(username, password);

                        t = new Thread(runKhachHangForm);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        this.Hide();
                    }
                    else // cửa hàng
                    {
                        MACH = getID_CuaHang(username, password);
                        t = new Thread(runCuaHangForm);
                        t.SetApartmentState(ApartmentState.STA);
                        t.Start();
                        this.Hide();
                    }

                }
            }
            else
            {
                //MessageBox.Show(sqlselect);
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo!");
            }
        }

        public void runCuaHangForm(object obj)
        {
            Application.Run(new CuaHang(MACH));// có thể truyền tham số 
        }
        public void runAminForm(object obj)
        {
            Application.Run(new Admin());// có thể truyền tham số 
        }
        public void runKhachHangForm(object obj)
        {
            Application.Run(new form_khachhang(MAKH));// có thể truyền tham số 
        }
        public void runTaiXeForm(object obj)
        {
            Application.Run(new form_main_TX());// có thể truyền tham số 
        }
        public void runNhanVienForm(object obj)
        {
            Application.Run(new NhanVien_main(USERNAME,PASSWORD));
        }



        public string GetFieldValues(string sql) // lấy maKH từ câu lệnh sql
        {
            string ma = "";
            using (SqlConnection connection = new SqlConnection(Connection.conectionstring))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    ma = reader.GetValue(0).ToString();
                reader.Close();
            }
            return ma;
        }
        public string getID_KhachHang( string username , string password)
        {
            string sql = "select KH.MA_KHACH_HANG from KHACHHANG KH, TAIKHOAN TK where KH.ID_TAI_KHOAN = TK.ID_TAI_KHOAN and TK.TEN_DANG_NHAP = '"+username+"' and TK.MAT_KHAU = '"+password+"'";
            string MaKhachHang = GetFieldValues(sql);
            return MaKhachHang;
        }

        public string getID_CuaHang(string username, string password)
        {
    
            string sql = "select CH.MA_CUA_HANG from CUAHANG CH, TAIKHOAN TK where CH.ID_TAI_KHOAN = TK.ID_TAI_KHOAN and TK.TEN_DANG_NHAP = '" + username + "' and TK.MAT_KHAU = '" + password + "'";
            string MaCuaHang = GetFieldValues(sql);
            return MaCuaHang;
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
