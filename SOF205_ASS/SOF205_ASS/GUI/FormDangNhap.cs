using DAL_QLBanHang;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();
        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
        private bool isSuccess = false;
        public bool getSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }

        public DTO_TaiKhoan dtoTaiKhoan;

        private void button1_Click(object sender, EventArgs e)
        {            
            if (txtAccount != null && txtPass != null) 
            {
                dtoTaiKhoan = dalTaiKhoan.DangNhap(txtAccount.Text, txtPass.Text);
                if (dtoTaiKhoan != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    isSuccess = true;
                    Close();

                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSuccess = false;
                    txtAccount.Text = "";
                    txtPass.Text = "";
                    txtAccount.Focus();
                }
            }
        }
      
        private void llblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(txtAccount != null)
            {

            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
