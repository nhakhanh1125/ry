using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormDatVe : Form
    {
        bool isFillingCmb = true;
        DAL_Phim dalPhim = new DAL_Phim();
        List<DTO_Phim> dtoPhimList;

        DAL_Suat dalSuat = new DAL_Suat();
        DAL_VeGhe dalVeGhe = new DAL_VeGhe();
        DAL_Phong dalPhong = new DAL_Phong();
        List<DTO_Suat> dtoSuatList;
        DTO_TaiKhoan dtoTaiKhoan = new DTO_TaiKhoan();

        public FormDatVe(DTO_TaiKhoan dtoTaiKhoan)
        {
            InitializeComponent();
            this.dtoTaiKhoan = dtoTaiKhoan;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void FormDatVe_Load(object sender, EventArgs e)
        {
            dtoPhimList = dalPhim.getPhim();
            cmbTenPhim.DataSource = dtoPhimList;
            cmbTenPhim.DisplayMember = "TenPhim";
            cmbTenPhim.ValueMember = "IdPhim";

            isFillingCmb = false;
            lblVeConLai.Visible = false;
        }

        private void cmbTenPhim_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!isFillingCmb)
            {
                DTO_Phim phimSelected = (DTO_Phim)cmbTenPhim.SelectedItem;
                long idPhim = phimSelected.IdPhim;

                dtoSuatList = dalSuat.getSuat(idPhim);

                cmbChonNgay.DataSource = dtoSuatList;
                cmbChonNgay.DisplayMember = "NgayChieu";
                cmbChonNgay.ValueMember = "IdSuat";
            }

        }

        private void cmbChonNgay_SelectedValueChanged(object sender, EventArgs e)
        {
            DTO_Suat suatSelected = (DTO_Suat)cmbChonNgay.SelectedItem;

            var filleredSuat = dtoSuatList.Where(suat => suat.NgayChieu == suatSelected.NgayChieu).ToList();

            cmbChonSuat.DataSource = filleredSuat;
            cmbChonSuat.DisplayMember = "GioChieu";
            cmbChonSuat.ValueMember = "IdSuat";

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            string phim = cmbTenPhim.Text;
            string suat = cmbChonSuat.Text;
            string ngay = cmbChonNgay.Text;
            if (!string.IsNullOrEmpty(ngay))
            {
                if (!string.IsNullOrEmpty(suat))
                {
                    if (!string.IsNullOrEmpty(phim))
                    {
                        DTO_Suat suatSelected = (DTO_Suat)cmbChonSuat.SelectedItem;
                        FormChonGhe formChonGhe = new FormChonGhe(suatSelected, dtoTaiKhoan);
                        this.Hide();
                        formChonGhe.UpdateLabels(phim, suat, ngay);
                        formChonGhe.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;


            }
        }

        private void cmbChonSuat_SelectedValueChanged(object sender, EventArgs e)
        {
            DTO_Suat suatSelected = (DTO_Suat)cmbChonSuat.SelectedItem;
            int gheDaDat = dalVeGhe.getGheDaDatBySuat(suatSelected.IdSuat);
            DTO_Phong dtoPhong = dalPhong.getPhong(suatSelected.IdPhong);
            lblVeConLai.Text = gheDaDat + "/" + dtoPhong.SoLuongGhe;
            lblVeConLai.Visible = true;
        }
    }
}
