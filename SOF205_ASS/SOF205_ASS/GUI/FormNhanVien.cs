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

namespace GUI
{
    public partial class FormPhimTrucTuyen : Form
    {
        public FormPhimTrucTuyen(DTO_TaiKhoan dtoTaiKhoan)
        {
            InitializeComponent();
            menu_Logout.Visible = false;
            this.dtoTaiKhoan = dtoTaiKhoan;
            setNameNhanVien(dtoTaiKhoan);
        }

        private DTO_TaiKhoan dtoTaiKhoan;
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap formlogin = new FormDangNhap();
            formlogin.ShowDialog();
            if (formlogin.getSuccess)
            {
                dtoTaiKhoan = formlogin.dtoTaiKhoan;
                setNameNhanVien(dtoTaiKhoan);
                LoggedIn(true);
                formlogin.Close();
            }   
        }

        void ChangeForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeForm(new FormKhachHang());
        }

       

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau1 formDoiMK = new FormDoiMatKhau1(dtoTaiKhoan.idTaiKhoan);
            formDoiMK.ShowDialog();
            if (formDoiMK.getSuccess)
            {
                formDoiMK.Close();
                LoggedIn(false);
            }

        }

        private void setNameNhanVien(DTO_TaiKhoan dtoTaiKhoan)
        {
            lblTenNhanVien.Visible = true;
            lblTenNhanVien.Text = dtoTaiKhoan.hoTen;
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng Xuất Thành Công");
            FormDangNhap dn = new FormDangNhap();
            dn.ShowDialog();
        }
        private void LoggedIn(bool check)
        {
            
            menu_Logout.Visible = check;
            lblTenNhanVien.Visible = check;
            if (!check)
            {
                panel1.Controls.Clear();
            }
            if (check)
            {
                //menuNhanVien.Visible = isAdmin;
                //menuThongKe.Visible = isAdmin;
            }
        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQLNV dk = new FQLNV(); 
            dk.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDatVe formDatVe = new FormDatVe(dtoTaiKhoan);
            formDatVe.ShowDialog();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormPhimTrucTuyen_Load(object sender, EventArgs e)
        {

        }
    }
}
