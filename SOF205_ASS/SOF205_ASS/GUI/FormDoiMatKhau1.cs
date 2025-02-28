using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDoiMatKhau1 : Form
    {
        public FormDoiMatKhau1(long idTaiKhoan)
        {
            this.idTaiKhoan = idTaiKhoan;
            InitializeComponent();
        }

        private bool isSuccess = false;
        public bool getSuccess
        {
            get { return isSuccess; }
        }
        private long idTaiKhoan;

        DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matkhauMoi = txtMatKhauMoi.Text;
            string matkhauMoi2 = txtNhapLaiMatKhau.Text;
            if (!string.IsNullOrEmpty(matKhauCu))
            {
                if (matkhauMoi == matkhauMoi2)
                {
                    if (dalTaiKhoan.UpdateMatKhau(idTaiKhoan, matkhauMoi, matKhauCu))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSuccess = true;
                        Close();

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
