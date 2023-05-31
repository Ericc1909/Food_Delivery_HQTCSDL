
namespace QL_DatHang_GiaoHang

{
    partial class form_CN_TX
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pn_cn_KH = new System.Windows.Forms.Panel();
            this.tb_confirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_pwnew = new System.Windows.Forms.TextBox();
            this.txtBox_matkhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_tendangnhap = new System.Windows.Forms.TextBox();
            this.pn_cn_KH.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(314, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 48);
            this.button1.TabIndex = 15;
            this.button1.Text = "CẬP NHẬT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(200, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 54);
            this.label2.TabIndex = 14;
            this.label2.Text = "CẬP NHẬT MẬT KHẨU";
            // 
            // pn_cn_KH
            // 
            this.pn_cn_KH.Controls.Add(this.tb_confirm);
            this.pn_cn_KH.Controls.Add(this.label5);
            this.pn_cn_KH.Controls.Add(this.tb_pwnew);
            this.pn_cn_KH.Controls.Add(this.txtBox_matkhau);
            this.pn_cn_KH.Controls.Add(this.label4);
            this.pn_cn_KH.Controls.Add(this.label3);
            this.pn_cn_KH.Controls.Add(this.label1);
            this.pn_cn_KH.Controls.Add(this.txtBox_tendangnhap);
            this.pn_cn_KH.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pn_cn_KH.Location = new System.Drawing.Point(82, 167);
            this.pn_cn_KH.Name = "pn_cn_KH";
            this.pn_cn_KH.Size = new System.Drawing.Size(625, 324);
            this.pn_cn_KH.TabIndex = 13;
            // 
            // tb_confirm
            // 
            this.tb_confirm.Location = new System.Drawing.Point(241, 248);
            this.tb_confirm.Name = "tb_confirm";
            this.tb_confirm.PasswordChar = '*';
            this.tb_confirm.Size = new System.Drawing.Size(271, 31);
            this.tb_confirm.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Xác Nhận Mật Khẩu";
            // 
            // tb_pwnew
            // 
            this.tb_pwnew.Location = new System.Drawing.Point(241, 180);
            this.tb_pwnew.Name = "tb_pwnew";
            this.tb_pwnew.PasswordChar = '*';
            this.tb_pwnew.Size = new System.Drawing.Size(271, 31);
            this.tb_pwnew.TabIndex = 7;
            // 
            // txtBox_matkhau
            // 
            this.txtBox_matkhau.Location = new System.Drawing.Point(241, 114);
            this.txtBox_matkhau.Name = "txtBox_matkhau";
            this.txtBox_matkhau.PasswordChar = '*';
            this.txtBox_matkhau.Size = new System.Drawing.Size(271, 31);
            this.txtBox_matkhau.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật Khẩu Mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật Khẩu Hiện Tại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Đăng Nhập";
            // 
            // txtBox_tendangnhap
            // 
            this.txtBox_tendangnhap.Location = new System.Drawing.Point(241, 48);
            this.txtBox_tendangnhap.Name = "txtBox_tendangnhap";
            this.txtBox_tendangnhap.Size = new System.Drawing.Size(271, 31);
            this.txtBox_tendangnhap.TabIndex = 0;
            // 
            // form_CN_TX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 654);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pn_cn_KH);
            this.Name = "form_CN_TX";
            this.Text = "form_CN_TX";
            this.Load += new System.EventHandler(this.form_CN_TX_Load);
            this.pn_cn_KH.ResumeLayout(false);
            this.pn_cn_KH.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pn_cn_KH;
        private System.Windows.Forms.TextBox tb_confirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_pwnew;
        private System.Windows.Forms.TextBox txtBox_matkhau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_tendangnhap;
    }
}