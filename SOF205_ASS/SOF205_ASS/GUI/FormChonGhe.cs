using DAL;
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
    public partial class FormChonGhe : Form
    {
        public FormChonGhe(DTO_Suat dtoSuat, DTO_TaiKhoan dtoTaiKhoan)
        {
            this.dtoSuat = dtoSuat;
            InitializeComponent();
            initializeSeats();

            DTO_Phong dtoPhong = dalPhong.getPhong(dtoSuat.IdPhong);
            lblPhongChieu.Text = dtoPhong.TenPhong;

            this.dtoTaiKhoan = dtoTaiKhoan;
        }
        DAL_VeGhe dAL_VeGhe = new DAL_VeGhe();
        DTO_Suat dtoSuat;
        DAL_DayGhe dalDayGhe = new DAL_DayGhe();
        DAL_Ghe dalGhe = new DAL_Ghe();
        DAL_Phong dalPhong = new DAL_Phong();
        DTO_TaiKhoan dtoTaiKhoan = new DTO_TaiKhoan();

        private List<string> selectedSeats = new List<string>();
        private List<long> selectedSeatsIdList = new List<long>();
        private const int GiaGheThuong = 45000;
        private const int GiaGheVIP = 55000;
        private int tongTien = 0;

        private void initializeSeats()
        {
            List<DTO_DayGhe> dayGheList = dalDayGhe.getDayGet(dtoSuat.IdPhong);
            int buttonSizeWidth = 70;
            int buttonSizeHeight = 40;
            for (int i = 0; i < dayGheList.Count; i++)
            {
                List<DTO_Ghe> gheList = dalGhe.getGhe(dayGheList[i].IdDayGhe);
                for (int j = 0; j < gheList.Count; j++)
                {
                    Button seatButton = new Button();
                    seatButton.Text = dayGheList[i].TenDay + gheList[j].GheSo;
                    seatButton.Name = "btnSeat_" + dayGheList[i].IdDayGhe + "_" + gheList[j].IdGhe;
                    seatButton.Width = buttonSizeWidth;
                    seatButton.Height = buttonSizeHeight;
                    seatButton.Left = (buttonSizeWidth + 5) * (j + 1);
                    seatButton.Top = (buttonSizeHeight + 5) * (i + 1);
                    
                    seatButton.Font = new Font(seatButton.Font, FontStyle.Bold);
                    bool isDaDat = dAL_VeGhe.checkGheDaDat(gheList[j].IdGhe, dtoSuat.IdSuat);

                    if (isDaDat )
                    {
                        seatButton.ForeColor = Color.White;
                        seatButton.BackColor = Color.Gray;
                    }
                    else
                    {
                        if (gheList[j].IdLoaiGhe == 1)
                        {
                            seatButton.ForeColor = Color.Black;
                            seatButton.BackColor = Color.Yellow;
                            seatButton.Tag = "Thuong";
                        }
                        else
                        {
                            seatButton.ForeColor = Color.White;
                            seatButton.BackColor = Color.Red;
                            seatButton.Tag = "VIP";
                        }

                        seatButton.Click += new EventHandler(seatButton_Click);
                    }

                    panelSeats.Controls.Add(seatButton);
                }


            }
        }

        private void seatButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string seatText = clickedButton.Text;
            string[] buttonName = clickedButton.Name.Split('_');
            long idGhe = long.Parse(buttonName[2]);

            if (selectedSeats.Contains(seatText))
            {
                selectedSeatsIdList.Remove(idGhe);
                selectedSeats.Remove(seatText);
                if (clickedButton.Tag.ToString() == "Thuong")
                {
                    tongTien -= GiaGheThuong;
                    clickedButton.ForeColor = Color.Black;
                    clickedButton.BackColor = Color.Yellow;
                }
                else
                {
                    tongTien -= GiaGheVIP;
                    clickedButton.ForeColor = Color.White;
                    clickedButton.BackColor = Color.Red;
                }
            }
            else
            {
                selectedSeatsIdList.Add(idGhe);
                selectedSeats.Add(seatText);
                if (clickedButton.Tag.ToString() == "Thuong")
                {
                    tongTien += GiaGheThuong;
                }
                else
                {
                    tongTien += GiaGheVIP;
                }
                clickedButton.BackColor = Color.Blue;
                clickedButton.ForeColor = Color.White;
            }

            // Cập nhật Label
            lblGhe.Text =  string.Join(", ", selectedSeats);
            lblGia.Text =  tongTien.ToString("N0") + " VND";
        }

        private void setTenPhim(DTO_Phim dtoPhim, DTO_Suat dtoSuat)
        {
         
        }

        public void UpdateLabels(string phim, string suat, string ngay)
            {
            lblTenPhim.Text = phim;
            lblChonNgay.Text = ngay;
            lblChonSuat.Text = suat;
        }
       
        private void FormChonGhe_Load(object sender, EventArgs e)
        {
         
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panelSeats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDatVe dv = new FormDatVe(dtoTaiKhoan);
            dv.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormXacNhanVe formXacNhanVe = new FormXacNhanVe(dtoSuat, selectedSeats, selectedSeatsIdList, tongTien, dtoTaiKhoan);
            formXacNhanVe.ShowDialog();
        }
    }
}
