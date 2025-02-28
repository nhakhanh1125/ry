using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI
{
    public partial class FormXacNhanVe : Form
    {
        public FormXacNhanVe(DTO_Suat dtoSuat, List<string> selectedSeats, List<long> selectedSeatsIdList, int tongTien, DTO_TaiKhoan dtoTaiKhoan)
        {
            InitializeComponent();
            this.dtoSuat = dtoSuat;
            this.selectedSeats = selectedSeats;
            this.selectedSeatsIdList = selectedSeatsIdList;
            this.tongTien = tongTien;
            this.dtoTaiKhoan = dtoTaiKhoan;
        }
        DAL_Phong dalPhong = new DAL_Phong();
        DAL_HoaDon dalHoaDon = new DAL_HoaDon();
        DAL_VeGhe dalVeGhe = new DAL_VeGhe();
        DAL_Phim dalPhim = new DAL_Phim();
        DTO_Suat dtoSuat = new DTO_Suat();
        List<string> selectedSeats = new List<string>();
        List<long> selectedSeatsIdList = new List<long>();
        int tongTien = 0;
        DTO_TaiKhoan dtoTaiKhoan = new DTO_TaiKhoan();
        String lblSeatName = "";
        private void FormXacNhanVe_Load(object sender, EventArgs e)
        {
            lblSeatName = "";
            String tienTo = "";
            foreach (String seatText in selectedSeats)
            {
                if (lblSeatName != "")
                {
                    tienTo = "-";
                }

                lblSeatName = lblSeatName + tienTo + seatText;
            }
            lblViTriGhe.Text = lblSeatName;
            lblTongTien.Text = tongTien.ToString("N0") + " VND"; 
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            dalHoaDon.insertHoaDon(tongTien, dtoSuat.IdSuat);
            long idHoaDon = dalHoaDon.GetLatestHoaDonId();
            bool resutl = false;
            int veCount = 0;
            foreach (long idGhe in selectedSeatsIdList)
            {
                resutl = dalVeGhe.insertVeGhe(idGhe, idHoaDon, dtoSuat.IdSuat);
                veCount++;
            }

            if (!resutl)
            {
                MessageBox.Show("Đặt Vé Thất Bại");
            }
            else
            {
                MessageBox.Show("Đặt Vé Thành Công");

                String rootPath = "D:\\Bill_DatVeXemFilm\\";
                string pdfName = GetFormattedDateTime() + idHoaDon + "_" + dtoSuat.IdSuat + ".pdf";
                String pdfPath = rootPath + pdfName;

                Document doc = new Document();

                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));

                doc.Open();

                /*tring fontPath = "D:\\CNTT\\PRO131\\QLBanVeXemPhim\\tahoma.ttf";
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                Paragraph title = new Paragraph("Hóa đơn mua vé xem phim", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                doc.Add(new Paragraph("\n"));*/
                DTO_Phong dtoPhong = dalPhong.getPhong(dtoSuat.IdPhong);
                DTO_Phim dtoPhim = dalPhim.getPhimById(dtoSuat.IdPhim);

                //iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);
                doc.Add(new Paragraph("Ten Nhan Vien: " + dtoTaiKhoan.hoTen));
                doc.Add(new Paragraph("Phim: " + dtoPhim.TenPhim));
                doc.Add(new Paragraph("So Luong Ve: " + veCount));
                doc.Add(new Paragraph("Phong: " + dtoPhong.TenPhong));
                doc.Add(new Paragraph("Ngay Chieu: " + dtoSuat.NgayChieu));
                doc.Add(new Paragraph("Gio Chieu: " + dtoSuat.GioChieu));
                doc.Add(new Paragraph("Vi Tri Ghe: " + lblSeatName));
                doc.Add(new Paragraph("Tong Tien: " + lblTongTien.Text));

                doc.Close();
                this.Close();
            }
        }
        static string GetFormattedDateTime()
        {
            // Lấy ngày giờ hiện tại
            DateTime now = DateTime.Now;

            // Định dạng ngày giờ thành chuỗi theo yêu cầu
            string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");

            return formattedDateTime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDatVe formDatVe = new FormDatVe(dtoTaiKhoan);
            formDatVe.ShowDialog();
        }
    }
}
