namespace GUI
{
    partial class FormDatVe
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
            this.cmbTenPhim = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbChonNgay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbChonSuat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblVeConLai = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbTenPhim
            // 
            this.cmbTenPhim.FormattingEnabled = true;
            this.cmbTenPhim.ItemHeight = 16;
            this.cmbTenPhim.Location = new System.Drawing.Point(131, 56);
            this.cmbTenPhim.Name = "cmbTenPhim";
            this.cmbTenPhim.Size = new System.Drawing.Size(352, 24);
            this.cmbTenPhim.TabIndex = 0;
            this.cmbTenPhim.SelectedValueChanged += new System.EventHandler(this.cmbTenPhim_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Phim";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbChonNgay
            // 
            this.cmbChonNgay.FormattingEnabled = true;
            this.cmbChonNgay.Location = new System.Drawing.Point(131, 122);
            this.cmbChonNgay.Name = "cmbChonNgay";
            this.cmbChonNgay.Size = new System.Drawing.Size(352, 24);
            this.cmbChonNgay.TabIndex = 2;
            this.cmbChonNgay.SelectedValueChanged += new System.EventHandler(this.cmbChonNgay_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn Ngày";
            // 
            // cmbChonSuat
            // 
            this.cmbChonSuat.FormattingEnabled = true;
            this.cmbChonSuat.Location = new System.Drawing.Point(131, 189);
            this.cmbChonSuat.Name = "cmbChonSuat";
            this.cmbChonSuat.Size = new System.Drawing.Size(352, 24);
            this.cmbChonSuat.TabIndex = 4;
            this.cmbChonSuat.SelectedValueChanged += new System.EventHandler(this.cmbChonSuat_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chọn Suất";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(638, 63);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(371, 144);
            this.btnXacNhan.TabIndex = 6;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblVeConLai
            // 
            this.lblVeConLai.AutoSize = true;
            this.lblVeConLai.Location = new System.Drawing.Point(186, 258);
            this.lblVeConLai.Name = "lblVeConLai";
            this.lblVeConLai.Size = new System.Drawing.Size(0, 16);
            this.lblVeConLai.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số lượng vé đã đặt: ";
            // 
            // FormDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 602);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblVeConLai);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbChonSuat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbChonNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTenPhim);
            this.Name = "FormDatVe";
            this.Text = "FormLichChieu";
            this.Load += new System.EventHandler(this.FormDatVe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTenPhim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChonNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbChonSuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblVeConLai;
        private System.Windows.Forms.Label label4;
    }
}