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
    public partial class NhanVien_QuanLyHopDong : Form
    {
        private string query = "";
        private string MaHD = "";

        public NhanVien_QuanLyHopDong()
        {
            InitializeComponent();

            reset_tab_GiaHan();

            refresh_dataGridView_tabDuyet();
            refresh_dataGridView_tabGiaHang();
            refresh_dataGridView_tabTraCuu();

        }
        void reset_tab_GiaHan()
        {

            btn_giahan_tabGiaHan.Enabled = false;

            dateTimePicker_tabGiaHan.Enabled = false;
            numericUpDown_tabGiaHan.Enabled = false;

            panel_SortDL_tabDuyet.Enabled = false;
            panel_search_TabDuyet.Enabled = false;
            btn_PheDuyet_tabDuyet.Enabled = false;


            panel_option_tab_giaHan.Enabled = false;
        }

        void centerAlign_TabGiaHang_TabDuyet(DataGridView temp)
        {
            temp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["MA_HOP_DONG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["NGAY_TAO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["TG_BAT_DAU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["TG_KET_THUC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["MA_CUA_HANG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["STK"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["MA_NHAN_VIEN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["TRANG_THAI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        void centerAlign_TabTraCuu(DataGridView temp)
        {
            temp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["MA_HOP_DONG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["MA_CUA_HANG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["TEN_CUA_HANG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["MA_CHI_NHANH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["SDT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["DIA_CHI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            temp.Columns["KHUVUC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void NhanVien_QuanLyHopDong_Load(object sender, EventArgs e)
        {

            ////căn giữa data
            centerAlign_TabGiaHang_TabDuyet(dataGridView_tabGiaHang);
            centerAlign_TabGiaHang_TabDuyet(dataGridView_tabDuyet);
            centerAlign_TabTraCuu(dataGridView_TabTraCuu);
        }

        private void btn_giahan_tabGiaHan_Click(object sender, EventArgs e)
        {
            if(checkBox_ChonNgay_TabGiaHan.Checked == true)
            {
                DateTime NgayKetThuc = dateTimePicker_tabGiaHan.Value;
                if (XuLyGiaHan_NgayKetThucMoi(MaHD, NgayKetThuc))
                {
                    refresh_dataGridView_tabGiaHang();
                    MessageBox.Show("gia hạn thành công!", "thông báo", MessageBoxButtons.YesNoCancel);
                }
                else
                    MessageBox.Show("gia hạn thất bại !", "thông báo", MessageBoxButtons.YesNoCancel);
            }    
            else if(checkBox_NhapNgayGiaHan.Checked ==true)
            {
                int SoNgayThem = (int)(numericUpDown_tabGiaHan.Value);
                if (XuLyGiaHan_ThemNgayGiaHan(MaHD, SoNgayThem))
                {
                    refresh_dataGridView_tabGiaHang();
                    MessageBox.Show("gia hạn thành công!", "thông báo", MessageBoxButtons.YesNoCancel);
                }
                else
                    MessageBox.Show("gia hạn thất bại !", "thông báo", MessageBoxButtons.YesNoCancel);
            }    
        }

        private void refresh_dataGridView_tabGiaHang()
        {
            dataGridView_tabGiaHang.Refresh();
            query = "SELECT * FROM HOPDONG WHERE TRANG_THAI = 1";
            dataGridView_tabGiaHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_tabGiaHang.DataSource = Dataprovider.Instance.ExecuteQuery(query);
        }

        public bool XuLyGiaHan_ThemNgayGiaHan(string MaHD   , int SoNgayThem)
        {
            query = "select count(*) from HOPDONG where MA_HOP_DONG = @MaHD and TRANG_THAI = 1";
            if ((int)Dataprovider.Instance.ExecuteScalar(query, new object[] { MaHD }) != 1)
            {
                MessageBox.Show("Không tồn tại hợp đồng" + MaHD + " Trong database");
                return false;
            }
            else
            {
                try
                {
                    query = "exec dbo.gia_han_hop_dong @MaHD , @SoNgayThem";
                    dataGridView_tabGiaHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_tabGiaHang.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { MaHD, SoNgayThem });
                    //MessageBox.Show(Dataprovider.Instance.ExecuteNonQuery(query, new object[] { MaHD, NgayKetThuc }).ToString());
                }
                catch (Exception error)
                {
                    MessageBox.Show("lỗi Xử lý gia hạn : " + error.ToString());
                    return false;
                }
            }
            return true;
        }

        public bool XuLyGiaHan_NgayKetThucMoi(string MaHD, DateTime NgayKetThuc)
        {
            query = "select count(*) from HOPDONG where MA_HOP_DONG = @MaHD and TRANG_THAI = 1";
            if ((int)Dataprovider.Instance.ExecuteScalar(query, new object[] { MaHD }) != 1)
            {
                MessageBox.Show("Không tồn tại hợp đồng" + MaHD + " Trong database");
                return false;
            }
            else
            {
                try
                {
                    query = "exec dbo.UpdateThoiHanHopDong @MaHD , @NgayKetThuc";
                    dataGridView_tabGiaHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_tabGiaHang.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { MaHD, NgayKetThuc });
                    //MessageBox.Show(Dataprovider.Instance.ExecuteNonQuery(query, new object[] { MaHD, NgayKetThuc }).ToString());
                }
                catch (Exception error)
                {
                    MessageBox.Show("Xử lý gia hạn : " + error.ToString());
                    return false;
                }
            }
            return true;
        }

     
        private void btn_TimKiem_TabGiaHan_Click(object sender, EventArgs e)
        {
            //string MaHD = "";
             string mahd = TextBox_MaHD_TabGiaHan.Text.ToString();
            if (mahd == "")
            {
                query = "SELECT * FROM HOPDONG WHERE TRANG_THAI = 1";
                dataGridView_tabGiaHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_tabGiaHang.DataSource = Dataprovider.Instance.ExecuteQuery(query);

                return;
            }
            try
            {
                query = "exec dbo.sp_getHopDongByMaHD @maHD , 1";

                dataGridView_tabGiaHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_tabGiaHang.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { mahd, 1 });

                if (dataGridView_tabGiaHang.Rows.Count == 0)
                {
                    dataGridView_tabGiaHang.Refresh();
                }
            }
            catch (Exception error)
            {
                DialogResult result = MessageBox.Show("Error: " + error.ToString(), "ERORR", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes || result == DialogResult.OK)
                {
                    this.Close();
                }
            }

        }

        void updateStatusOptionGiaHan()
        {
            if (checkBox_NhapNgayGiaHan.Checked == true)
            {
                dateTimePicker_tabGiaHan.Enabled = false;
                dateTimePicker_tabGiaHan.Refresh();
                checkBox_ChonNgay_TabGiaHan.Checked = false;
                return;
            }
            if (checkBox_ChonNgay_TabGiaHan.Checked == true)
            {
                numericUpDown_tabGiaHan.Enabled = false;
                numericUpDown_tabGiaHan.Refresh();
                checkBox_NhapNgayGiaHan.Checked = false;
                return;
            }
            dateTimePicker_tabGiaHan.Enabled = true;
            numericUpDown_tabGiaHan.Enabled = true;
        }


        private void dataGridView_tabGiaHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dateTimePicker_tabGiaHan.Enabled = false;
            numericUpDown_tabGiaHan.Enabled =false;

            panel_option_tab_giaHan.Enabled = true;

            //updateStatusOptionGiaHan();
            DataGridViewRow row = dataGridView_tabGiaHang.Rows[e.RowIndex];
            string Ma_Hop_Dong = row.Cells[0].Value.ToString();
            //string Ngay_Tao = row.Cells[1].Value.ToString();
            //string Ma_Nhan_vien = row.Cells[6].Value.ToString();
            MaHD = Ma_Hop_Dong;
            MessageBox.Show(" Bạn đang chọn " + Ma_Hop_Dong + " để gia hạn !!");//
            btn_giahan_tabGiaHan.Enabled = true;

            if(checkBox_ChonNgay_TabGiaHan.Checked == true)
            {
                dateTimePicker_tabGiaHan.Enabled = true;
            }
            else if (checkBox_NhapNgayGiaHan.Checked == true)
            {
                numericUpDown_tabGiaHan.Enabled = true;
            }

        }
        private void checkBox_ChonNgay_TabGiaHan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ChonNgay_TabGiaHan.Checked == true)
            {
                numericUpDown_tabGiaHan.Enabled = false;
                checkBox_NhapNgayGiaHan.Checked = false;
                dateTimePicker_tabGiaHan.Enabled = true;
            }
            else
            {
                numericUpDown_tabGiaHan.Enabled = true;
            }

            if (checkBox_ChonNgay_TabGiaHan.Checked == false && checkBox_NhapNgayGiaHan.Checked == false)
            {
                numericUpDown_tabGiaHan.Enabled = true;
                dateTimePicker_tabGiaHan.Enabled = true;
            }
        }
        private void checkBox_NhapNgayGiaHan_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_NhapNgayGiaHan.Checked == true)
            {
                dateTimePicker_tabGiaHan.Enabled = false;
                checkBox_ChonNgay_TabGiaHan.Checked = false;
                numericUpDown_tabGiaHan.Enabled = true;
            }
            else
            {
                dateTimePicker_tabGiaHan.Enabled = true;
            }

            if(checkBox_ChonNgay_TabGiaHan.Checked == false && checkBox_NhapNgayGiaHan.Checked == false)
            {
                numericUpDown_tabGiaHan.Enabled = true;
                dateTimePicker_tabGiaHan.Enabled = true;
            }    
        }

        //============================================================= TAB DUYET Hop DONG ==================================================================
        private void refresh_dataGridView_tabDuyet()
        {
            dataGridView_tabDuyet.Refresh();
            query = "SELECT * FROM HOPDONG WHERE TRANG_THAI = 0";
            dataGridView_tabDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_tabDuyet.DataSource = Dataprovider.Instance.ExecuteQuery(query);
        }


        private void check_sort_tabDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_timkiem_tabDuyet.Checked == false && check_sort_tabDuyet.Checked == false)
            {
                refresh_dataGridView_tabDuyet();
            }
            if (check_sort_tabDuyet.Checked == false)
            {
                panel_SortDL_tabDuyet.Enabled = false;
            }
            else
            {
                panel_SortDL_tabDuyet.Enabled = true;
                checkBox_timkiem_tabDuyet.Checked = false;
                panel_search_TabDuyet.Enabled = false;
            }

            //check_sort_tabDuyet.Checked = true;
        }

        private void checkBox_timkiem_tabDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_timkiem_tabDuyet.Checked == false && check_sort_tabDuyet.Checked == false)
            {
                refresh_dataGridView_tabDuyet();
            }
            if (checkBox_timkiem_tabDuyet.Checked == false)
            {
                panel_search_TabDuyet.Enabled = false;
            }
            else
            {
                panel_search_TabDuyet.Enabled = true;
                check_sort_tabDuyet.Checked = false;
                panel_SortDL_tabDuyet.Enabled = false;
            }

            //checkBox_timkiem_tabDuyet.Checked = true;
        }

        private void handleSortByTime_TabDuyet(DateTime TG_BatDau, DateTime TG_KetThuc)
        {
            if (TG_BatDau == null || TG_KetThuc == null)
            {
                MessageBox.Show(" Thời gian không hơp lệ ");
                return;
            }
            else
            {
                try
                {
                    query = "exec dbo.SelectHopDong_ThoiGian_BD_ThoiGian_KT @TG_BatDau , @TG_KetThuc";
                    dataGridView_tabDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView_tabDuyet.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { TG_BatDau, TG_KetThuc });
                }
                catch (Exception error)
                {
                    DialogResult result = MessageBox.Show("Error: " + error.ToString(), "ERORR", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes || result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btn_Sort_tabDuyet_Click(object sender, EventArgs e)
        {
            DateTime TGBD = (DateTime)dateTimePicker_DB_TabDuyet.Value;
            DateTime TGKT = (DateTime)dateTimePicker_KT_TabDuyet.Value;
            handleSortByTime_TabDuyet(TGBD, TGKT);
        }

        private void handleSerchInfor_TabDuyet(string MaCuaHang, string TenCuaHang)
        {
            if (MaCuaHang == "" && TenCuaHang == "")
            {
                refresh_dataGridView_tabDuyet();
            }
            else if (MaCuaHang == "" && TenCuaHang != "")
            {

                query = "exec dbo.SlectHopDong_TenCuaHangGanDung @TenCuaHang , 0";
                dataGridView_tabDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_tabDuyet.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { TenCuaHang });
                //textBox_TenCuaHang_TabDuyet.Text = "";
                //textBox_maCH_tabDuyet.Text = "";
            }

            else
            {
                query = "exec dbo.sp_getHopDongByMaCH @MaCuaHang , 0";
                dataGridView_tabDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_tabDuyet.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { MaCuaHang });
                //textBox_TenCuaHang_TabDuyet.Text = "";
                //textBox_maCH_tabDuyet.Text = "";
            }

        }

        private void textBox_maCH_tabDuyet_TextChanged(object sender, EventArgs e)
        {
            textBox_TenCuaHang_TabDuyet.Text = "";
        }

        private void textBox_TenCuaHang_TabDuyet_TextChanged(object sender, EventArgs e)
        {
            textBox_maCH_tabDuyet.Text = "";
        }

        private void btn_search_TabDuyet_Click(object sender, EventArgs e)
        {
            string MaCH = (string)textBox_maCH_tabDuyet.Text;
            string TenCuaHang = (string)textBox_TenCuaHang_TabDuyet.Text;
            handleSerchInfor_TabDuyet(MaCH, TenCuaHang);
        }

        private void btn_PheDuyet_tabDuyet_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn duyệt hợp đồng " + MaHD, "Thông báo", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes || result == DialogResult.OK)
            {
                handle_DuyetHopDong_TabDuyet();
                refresh_dataGridView_tabGiaHang();

            }
        }

        private void handle_DuyetHopDong_TabDuyet()
        {
            if (MaHD == "")
            {
                MessageBox.Show("Chọn hợp đồng duyệt không thành công , vui lòng chọn lại", "Thông báo", MessageBoxButtons.YesNoCancel);
                return;
            }
            else
            {
                query = "exec dbo.sq_updateStatus_HopDong @MaHD , 1";
                dataGridView_tabDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_tabDuyet.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { MaHD });
                if (Dataprovider.Instance.ExecuteNonQuery(query, new object[] { MaHD }) < 1)
                {
                    MessageBox.Show("Phê duyệt không thành công", "thông báo", MessageBoxButtons.YesNoCancel);
                    refresh_dataGridView_tabDuyet();
                    return;
                }
                else
                {
                    MessageBox.Show("Phê duyệt thành công", "thông báo", MessageBoxButtons.YesNoCancel);
                    refresh_dataGridView_tabDuyet();
                    return;
                }

            }
        }

        private void handle_LoaiBoHopDong_TabDuyet()
        {
            if (MaHD == "")
            {
                MessageBox.Show("Chọn hợp đồng duyệt không thành công, vui lòng thực hiện lại", "Thông báo", MessageBoxButtons.YesNoCancel);
                return;
            }
            else
            {
                query = "exec dbo.sq_updateStatus_HopDong @MaHD , 2";
                dataGridView_tabDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_tabDuyet.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { MaHD });
                if (Dataprovider.Instance.ExecuteNonQuery(query, new object[] { MaHD }) < 1)
                {
                    MessageBox.Show("Loại bỏ hợp đồng không thành công", "Thông báo", MessageBoxButtons.YesNoCancel);
                    refresh_dataGridView_tabDuyet();
                    refresh_dataGridView_tabGiaHang();
                    refresh_dataGridView_tabTraCuu();
                    return;
                }
                else
                {
                    MessageBox.Show("Loại bỏ thanh công", "Thông báo", MessageBoxButtons.YesNoCancel);
                    refresh_dataGridView_tabDuyet();
                    return;
                }

            }
        }

        private void btn_Loaibo_TabDuyet_Click(object sender, EventArgs e)
        {
            handle_LoaiBoHopDong_TabDuyet();
        }

        private void dataGridView_tabDuyet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            MaHD = "";
            DataGridViewRow row = dataGridView_tabDuyet.Rows[e.RowIndex];
            string Ma_Hop_Dong = row.Cells[0].Value.ToString();
            //string Ngay_Tao = row.Cells[1].Value.ToString();
            //string Ma_Nhan_vien = row.Cells[6].Value.ToString();
            MaHD = Ma_Hop_Dong;
            MessageBox.Show(" bạn đang chọn " + Ma_Hop_Dong + " để duyệt !!");//
            btn_PheDuyet_tabDuyet.Enabled = true;
            btn_Loaibo_TabDuyet.Enabled = true;

        }

        void refresh_dataGridView_tabTraCuu()
        {
            try
            {

                query = "select HD.MA_HOP_DONG, CH.MA_CUA_HANG,CH.TEN_CUA_HANG,CN.MA_CHI_NHANH,CN.SDT,CN.DIA_CHI,CN.KHUVUC " +
                        "from HOPDONG HD, CUAHANG CH, CHINHANH CN "
                       + " WHERE HD.MA_HOP_DONG = CN.MA_HOP_DONG AND CN.MA_CUA_HANG = CH.MA_CUA_HANG AND HD.TRANG_THAI = 1";

                dataGridView_TabTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_TabTraCuu.DataSource = Dataprovider.Instance.ExecuteQuery(query);
            }

            catch (Exception erorr)
            {
                MessageBox.Show(erorr.ToString(), "ERORR");
            }
        }

        private void dataGridView_TabTraCuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Search_tabTraCuu_Click(object sender, EventArgs e)
        {
            if(textBox_MaChiNhanh_TabTraCuu.Text=="")
            {
                refresh_dataGridView_tabTraCuu();
                return;
            }
            else
            {
                query = "exec dbo.SP_ThongTinChiNhanh_Ma @MaChiNhanh";
                string MaChiNhanh = textBox_MaChiNhanh_TabTraCuu.Text;
                dataGridView_TabTraCuu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView_TabTraCuu.DataSource = Dataprovider.Instance.ExecuteQuery(query, new object[] { MaChiNhanh });
            }    
        }

        private void panel_NhapNgay_tabGiaHan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tab_duyet_Click(object sender, EventArgs e)
        {

        }

        private void tab_Giahan_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


//https://www.youtube.com/watch?v=XzW8Ph9BnBQ
//https://www.youtube.com/playlist?list=PLFDH5bKmoNqyDKntkVv-NURTAlPIhMPqA