
namespace QL_DatHang_GiaoHang
{
    partial class DS_Mon
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb_tenmon = new System.Windows.Forms.TextBox();
            this.KH_tm = new System.Windows.Forms.Label();
            this.KH_sl = new System.Windows.Forms.Label();
            this.tb_soluong = new System.Windows.Forms.TextBox();
            this.bt_themmon_KH = new System.Windows.Forms.Button();
            this.bt_ql_KH = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_diachi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_chinhanh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_chonchinhanh = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tb_giamon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_mamon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 393);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(909, 187);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // tb_tenmon
            // 
            this.tb_tenmon.Location = new System.Drawing.Point(163, 57);
            this.tb_tenmon.Name = "tb_tenmon";
            this.tb_tenmon.Size = new System.Drawing.Size(161, 26);
            this.tb_tenmon.TabIndex = 7;
            // 
            // KH_tm
            // 
            this.KH_tm.AutoSize = true;
            this.KH_tm.Location = new System.Drawing.Point(21, 69);
            this.KH_tm.Name = "KH_tm";
            this.KH_tm.Size = new System.Drawing.Size(71, 20);
            this.KH_tm.TabIndex = 8;
            this.KH_tm.Text = "Tên Món";
            // 
            // KH_sl
            // 
            this.KH_sl.AutoSize = true;
            this.KH_sl.Location = new System.Drawing.Point(21, 112);
            this.KH_sl.Name = "KH_sl";
            this.KH_sl.Size = new System.Drawing.Size(78, 20);
            this.KH_sl.TabIndex = 9;
            this.KH_sl.Text = "Số Lượng";
            // 
            // tb_soluong
            // 
            this.tb_soluong.Location = new System.Drawing.Point(163, 100);
            this.tb_soluong.Name = "tb_soluong";
            this.tb_soluong.Size = new System.Drawing.Size(161, 26);
            this.tb_soluong.TabIndex = 10;
            // 
            // bt_themmon_KH
            // 
            this.bt_themmon_KH.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_themmon_KH.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.bt_themmon_KH.Location = new System.Drawing.Point(604, 218);
            this.bt_themmon_KH.Name = "bt_themmon_KH";
            this.bt_themmon_KH.Size = new System.Drawing.Size(135, 57);
            this.bt_themmon_KH.TabIndex = 13;
            this.bt_themmon_KH.Text = "ĐẶT HÀNG";
            this.bt_themmon_KH.UseVisualStyleBackColor = false;
            this.bt_themmon_KH.Click += new System.EventHandler(this.bt_themmon_KH_Click);
            // 
            // bt_ql_KH
            // 
            this.bt_ql_KH.Location = new System.Drawing.Point(28, 26);
            this.bt_ql_KH.Name = "bt_ql_KH";
            this.bt_ql_KH.Size = new System.Drawing.Size(110, 32);
            this.bt_ql_KH.TabIndex = 15;
            this.bt_ql_KH.Text = "QUAY LẠI";
            this.bt_ql_KH.UseVisualStyleBackColor = true;
            this.bt_ql_KH.Click += new System.EventHandler(this.bt_ql_KH_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 628);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 39);
            this.button2.TabIndex = 16;
            this.button2.Text = "Xem DS Món";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(205, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "DANH SÁCH MÓN";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_diachi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tb_chinhanh);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lb_chonchinhanh);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.tb_giamon);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_mamon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_themmon_KH);
            this.panel1.Controls.Add(this.tb_soluong);
            this.panel1.Controls.Add(this.KH_sl);
            this.panel1.Controls.Add(this.KH_tm);
            this.panel1.Controls.Add(this.tb_tenmon);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 286);
            this.panel1.TabIndex = 17;
            // 
            // tb_diachi
            // 
            this.tb_diachi.Location = new System.Drawing.Point(160, 236);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.Size = new System.Drawing.Size(164, 26);
            this.tb_diachi.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Địa Chỉ";
            // 
            // tb_chinhanh
            // 
            this.tb_chinhanh.Location = new System.Drawing.Point(161, 192);
            this.tb_chinhanh.Name = "tb_chinhanh";
            this.tb_chinhanh.Size = new System.Drawing.Size(163, 26);
            this.tb_chinhanh.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Mã Chi Nhánh";
            // 
            // lb_chonchinhanh
            // 
            this.lb_chonchinhanh.AutoSize = true;
            this.lb_chonchinhanh.Location = new System.Drawing.Point(366, 13);
            this.lb_chonchinhanh.Name = "lb_chonchinhanh";
            this.lb_chonchinhanh.Size = new System.Drawing.Size(125, 20);
            this.lb_chonchinhanh.TabIndex = 20;
            this.lb_chonchinhanh.Text = "Chọn Chi Nhánh";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(368, 55);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(587, 160);
            this.dataGridView2.TabIndex = 19;
            this.dataGridView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseDoubleClick);
            // 
            // tb_giamon
            // 
            this.tb_giamon.Location = new System.Drawing.Point(163, 147);
            this.tb_giamon.Name = "tb_giamon";
            this.tb_giamon.Size = new System.Drawing.Size(162, 26);
            this.tb_giamon.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Giá Món";
            // 
            // tb_mamon
            // 
            this.tb_mamon.Location = new System.Drawing.Point(163, 18);
            this.tb_mamon.Name = "tb_mamon";
            this.tb_mamon.Size = new System.Drawing.Size(161, 26);
            this.tb_mamon.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã Món";
            // 
            // DS_Mon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bt_ql_KH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DS_Mon";
            this.Text = "DS_Mon";
            this.Load += new System.EventHandler(this.DS_Mon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_tenmon;
        private System.Windows.Forms.Label KH_tm;
        private System.Windows.Forms.Label KH_sl;
        private System.Windows.Forms.TextBox tb_soluong;
        private System.Windows.Forms.Button bt_themmon_KH;
        private System.Windows.Forms.Button bt_ql_KH;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_mamon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_giamon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_chonchinhanh;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tb_chinhanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_diachi;
        private System.Windows.Forms.Label label5;
    }
}