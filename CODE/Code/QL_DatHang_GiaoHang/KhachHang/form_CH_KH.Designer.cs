
namespace QL_DatHang_GiaoHang
{
    partial class form_CH_KH
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txbox_tendoitac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tx_box_diachi = new System.Windows.Forms.TextBox();
            this.bt_xemDs = new System.Windows.Forms.Button();
            this.bt_ch_view = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_dathang = new System.Windows.Forms.Button();
            this.txb_maCH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(178, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH ĐỐI TÁC";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(41, 396);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(703, 165);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Đối Tác";
            // 
            // txbox_tendoitac
            // 
            this.txbox_tendoitac.Location = new System.Drawing.Point(22, 127);
            this.txbox_tendoitac.Name = "txbox_tendoitac";
            this.txbox_tendoitac.Size = new System.Drawing.Size(217, 26);
            this.txbox_tendoitac.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa Chỉ";
            // 
            // tx_box_diachi
            // 
            this.tx_box_diachi.Location = new System.Drawing.Point(22, 193);
            this.tx_box_diachi.Name = "tx_box_diachi";
            this.tx_box_diachi.Size = new System.Drawing.Size(217, 26);
            this.tx_box_diachi.TabIndex = 5;
            // 
            // bt_xemDs
            // 
            this.bt_xemDs.Location = new System.Drawing.Point(309, 590);
            this.bt_xemDs.Name = "bt_xemDs";
            this.bt_xemDs.Size = new System.Drawing.Size(105, 38);
            this.bt_xemDs.TabIndex = 6;
            this.bt_xemDs.Text = "LOAD";
            this.bt_xemDs.UseVisualStyleBackColor = true;
            this.bt_xemDs.Click += new System.EventHandler(this.bt_xemDs_Click);
            // 
            // bt_ch_view
            // 
            this.bt_ch_view.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bt_ch_view.ForeColor = System.Drawing.Color.DarkBlue;
            this.bt_ch_view.Location = new System.Drawing.Point(405, 182);
            this.bt_ch_view.Name = "bt_ch_view";
            this.bt_ch_view.Size = new System.Drawing.Size(133, 37);
            this.bt_ch_view.TabIndex = 7;
            this.bt_ch_view.Text = "XEM MÓN ĂN";
            this.bt_ch_view.UseVisualStyleBackColor = false;
            this.bt_ch_view.Click += new System.EventHandler(this.bt_ch_view_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_dathang);
            this.panel1.Controls.Add(this.txb_maCH);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tx_box_diachi);
            this.panel1.Controls.Add(this.bt_ch_view);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbox_tendoitac);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(41, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 240);
            this.panel1.TabIndex = 8;
            // 
            // bt_dathang
            // 
            this.bt_dathang.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_dathang.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_dathang.Location = new System.Drawing.Point(405, 84);
            this.bt_dathang.Name = "bt_dathang";
            this.bt_dathang.Size = new System.Drawing.Size(133, 40);
            this.bt_dathang.TabIndex = 11;
            this.bt_dathang.Text = "ĐẶT HÀNG";
            this.bt_dathang.UseVisualStyleBackColor = false;
            this.bt_dathang.Click += new System.EventHandler(this.bt_dathang_Click);
            // 
            // txb_maCH
            // 
            this.txb_maCH.Location = new System.Drawing.Point(22, 55);
            this.txb_maCH.Name = "txb_maCH";
            this.txb_maCH.Size = new System.Drawing.Size(217, 26);
            this.txb_maCH.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã Cửa Hàng";
            // 
            // form_CH_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 654);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_xemDs);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "form_CH_KH";
            this.Text = "Danh Sách Đối Tác";
            this.Load += new System.EventHandler(this.form_CH_KH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbox_tendoitac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tx_box_diachi;
        private System.Windows.Forms.Button bt_xemDs;
        private System.Windows.Forms.Button bt_ch_view;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox MaCH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_maCH;
        private System.Windows.Forms.Button bt_dathang;
    }
}