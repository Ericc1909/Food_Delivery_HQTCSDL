
namespace QL_DatHang_GiaoHang
{
    partial class form_khachhang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_kh_tt = new System.Windows.Forms.Button();
            this.bt_kh_cn = new System.Windows.Forms.Button();
            this.bt_kh_dh = new System.Windows.Forms.Button();
            this.bt_kh_donhang = new System.Windows.Forms.Button();
            this.bt_kh_dx = new System.Windows.Forms.Button();
            this.pnChildFormKH = new System.Windows.Forms.Panel();
            this.flpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flpMenu.Controls.Add(this.panel2);
            this.flpMenu.Controls.Add(this.bt_kh_tt);
            this.flpMenu.Controls.Add(this.bt_kh_cn);
            this.flpMenu.Controls.Add(this.bt_kh_dh);
            this.flpMenu.Controls.Add(this.bt_kh_donhang);
            this.flpMenu.Controls.Add(this.bt_kh_dx);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpMenu.ForeColor = System.Drawing.Color.Black;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(232, 704);
            this.flpMenu.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 240);
            this.panel2.TabIndex = 1;
            // 
            // bt_kh_tt
            // 
            this.bt_kh_tt.BackColor = System.Drawing.SystemColors.Control;
            this.bt_kh_tt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_kh_tt.Location = new System.Drawing.Point(3, 249);
            this.bt_kh_tt.Name = "bt_kh_tt";
            this.bt_kh_tt.Size = new System.Drawing.Size(232, 93);
            this.bt_kh_tt.TabIndex = 0;
            this.bt_kh_tt.Text = "Thông Tin Tài Khoản";
            this.bt_kh_tt.UseVisualStyleBackColor = false;
            this.bt_kh_tt.Click += new System.EventHandler(this.bt_tx_tt_Click);
            // 
            // bt_kh_cn
            // 
            this.bt_kh_cn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_kh_cn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bt_kh_cn.Location = new System.Drawing.Point(3, 348);
            this.bt_kh_cn.Name = "bt_kh_cn";
            this.bt_kh_cn.Size = new System.Drawing.Size(232, 93);
            this.bt_kh_cn.TabIndex = 0;
            this.bt_kh_cn.Text = "Cập Nhật Mật Khẩu";
            this.bt_kh_cn.UseVisualStyleBackColor = true;
            this.bt_kh_cn.Click += new System.EventHandler(this.bt_kh_cn_Click);
            // 
            // bt_kh_dh
            // 
            this.bt_kh_dh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_kh_dh.Location = new System.Drawing.Point(3, 447);
            this.bt_kh_dh.Name = "bt_kh_dh";
            this.bt_kh_dh.Size = new System.Drawing.Size(232, 80);
            this.bt_kh_dh.TabIndex = 0;
            this.bt_kh_dh.Text = "Đặt Hàng";
            this.bt_kh_dh.UseVisualStyleBackColor = true;
            this.bt_kh_dh.Click += new System.EventHandler(this.bt_kh_dh_Click);
            // 
            // bt_kh_donhang
            // 
            this.bt_kh_donhang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_kh_donhang.Location = new System.Drawing.Point(3, 533);
            this.bt_kh_donhang.Name = "bt_kh_donhang";
            this.bt_kh_donhang.Size = new System.Drawing.Size(232, 89);
            this.bt_kh_donhang.TabIndex = 0;
            this.bt_kh_donhang.Text = "Đơn Hàng";
            this.bt_kh_donhang.UseVisualStyleBackColor = true;
            this.bt_kh_donhang.Click += new System.EventHandler(this.bt_kh_donhang_Click);
            // 
            // bt_kh_dx
            // 
            this.bt_kh_dx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_kh_dx.Location = new System.Drawing.Point(3, 628);
            this.bt_kh_dx.Name = "bt_kh_dx";
            this.bt_kh_dx.Size = new System.Drawing.Size(232, 80);
            this.bt_kh_dx.TabIndex = 1;
            this.bt_kh_dx.Text = "Đăng Xuất";
            this.bt_kh_dx.UseVisualStyleBackColor = true;
            this.bt_kh_dx.Click += new System.EventHandler(this.bt_tx_dx_Click);
            // 
            // pnChildFormKH
            // 
            this.pnChildFormKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChildFormKH.Location = new System.Drawing.Point(232, 0);
            this.pnChildFormKH.Name = "pnChildFormKH";
            this.pnChildFormKH.Size = new System.Drawing.Size(764, 704);
            this.pnChildFormKH.TabIndex = 3;
            // 
            // form_khachhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 704);
            this.Controls.Add(this.pnChildFormKH);
            this.Controls.Add(this.flpMenu);
            this.Name = "form_khachhang";
            this.Text = "Khách Hàng";
            this.Load += new System.EventHandler(this.form_khachhang_Load);
            this.flpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_kh_tt;
        private System.Windows.Forms.Button bt_kh_cn;
        private System.Windows.Forms.Button bt_kh_dh;
        private System.Windows.Forms.Button bt_kh_donhang;
        private System.Windows.Forms.Button bt_kh_dx;
        private System.Windows.Forms.Panel pnChildFormKH;
    }
}
