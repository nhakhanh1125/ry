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
    public partial class FQuanLy : Form
    {
        public FQuanLy()
        {
            InitializeComponent();
           

        }
        
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FQLNV formqlnv = new FQLNV();
            formqlnv.ShowDialog();
        }

        private void btnPhim_Click(object sender, EventArgs e)
        {
            FormPhim formphim = new FormPhim();
            formphim.ShowDialog();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            FormDoanhThu formDoanhThu = new FormDoanhThu();
            formDoanhThu.ShowDialog();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            FormPhong formphong = new FormPhong();
            formphong.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FSuat formSuat = new FSuat();
            formSuat.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDN formDN = new FormDN();
            formDN.ShowDialog();
        }
        
        private void FQuanLy_Load(object sender, EventArgs e)
        {

        }
    }
}
