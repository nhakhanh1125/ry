namespace GUI
{
    partial class FormXacNhanVe
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
            this.lblXacNhanThongTin = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblViTriGhe = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblXacNhanThongTin
            // 
            this.lblXacNhanThongTin.AutoSize = true;
            this.lblXacNhanThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.90244F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXacNhanThongTin.Location = new System.Drawing.Point(232, 39);
            this.lblXacNhanThongTin.Name = "lblXacNhanThongTin";
            this.lblXacNhanThongTin.Size = new System.Drawing.Size(318, 39);
            this.lblXacNhanThongTin.TabIndex = 0;
            this.lblXacNhanThongTin.Text = "Xác nhận thông tin";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Orange;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.95122F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhan.Location = new System.Drawing.Point(489, 404);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(132, 34);
            this.btnXacNhan.TabIndex = 1;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.95122F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(627, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hủy giao dịch";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblViTriGhe
            // 
            this.lblViTriGhe.AutoSize = true;
            this.lblViTriGhe.Location = new System.Drawing.Point(357, 124);
            this.lblViTriGhe.Name = "lblViTriGhe";
            this.lblViTriGhe.Size = new System.Drawing.Size(44, 16);
            this.lblViTriGhe.TabIndex = 3;
            this.lblViTriGhe.Text = "label1";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(357, 164);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(44, 16);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "label1";
            // 
            // FormXacNhanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblViTriGhe);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lblXacNhanThongTin);
            this.Name = "FormXacNhanVe";
            this.Text = "FormXacNhanVe";
            this.Load += new System.EventHandler(this.FormXacNhanVe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXacNhanThongTin;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblViTriGhe;
        private System.Windows.Forms.Label lblTongTien;
    }
}