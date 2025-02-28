using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDN : Form
    {
        public FormDN()
        {
            InitializeComponent();
        }

        private DTO_TaiKhoan dtoTaiKhoan;

        private bool isSuccess = false;
        public bool getSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }
        private void btnDN_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.ShowDialog();
            if (formDangNhap.getSuccess)
                this.Hide();
                dtoTaiKhoan = formDangNhap.dtoTaiKhoan;
                if (dtoTaiKhoan.idLoaiTaiKhoan == 2) {
                    FormPhimTrucTuyen formPhimTrucTuyen = new FormPhimTrucTuyen(dtoTaiKhoan);
                    formPhimTrucTuyen.ShowDialog();
                
                } else {
                FQuanLy formQuanLy = new FQuanLy();
                formQuanLy.ShowDialog();
                
                }
                
        }

    }
}
