using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Phim
    {
        public long IdPhim { get; set; }
        public string TenPhim { get; set; }
        public string ThoiLuong { get; set; }
        public string MoTaNgan { get; set; }

        public string DaoDien { get; set; }
        public string DienVien { get; set; }
        public string HinhAnh1 { get; set; }
        public string HinhAnh2 { get; set; }
        public string HinhAnh3 { get; set; }
        public string HinhAnh4 { get; set; }
        public string Video { get; set; }
        public string TheLoai { get; set; }
        public DateTime NgayCongChieu { get; set; }
        public int GioiHanTuoi { get; set; }
        public string DinhDangPhim { get; set; }
        public bool TrangThai { get; set; }
        public DTO_Phim() { }

        public DTO_Phim(long idPhim, string tenPhim, string thoiLuong, string moTaNgan, string daoDien, string dienVien, string hinhAnh1,
            string hinhAnh2, string hinhAnh3, string hinhAnh4, string video, string theLoai, DateTime ngayCongChieu, int gioiHanTuoi, string dinhDangPhim, bool trangThai)
        {
            IdPhim = idPhim;
            TenPhim = tenPhim;
            ThoiLuong = thoiLuong;
            MoTaNgan = moTaNgan;
            DaoDien = daoDien;
            DienVien = dienVien;
            HinhAnh1 = hinhAnh1;
            HinhAnh2 = hinhAnh2;
            HinhAnh3 = hinhAnh3;
            HinhAnh4 = hinhAnh4;
            Video = video;
            TheLoai = theLoai;
            NgayCongChieu = ngayCongChieu;
            GioiHanTuoi = gioiHanTuoi;
            DinhDangPhim = dinhDangPhim;
            TrangThai = trangThai;
        }



        // Constructor
        public DTO_Phim(long idPhim, string tenPhim, string thoiLuong, string daoDien, string dienVien,
                        string theLoai, DateTime ngayCongChieu, int gioiHanTuoi)
        {
            IdPhim = idPhim;
            TenPhim = tenPhim;
            ThoiLuong = thoiLuong;
            DaoDien = daoDien;
            DienVien = dienVien;
            TheLoai = theLoai;
            NgayCongChieu = ngayCongChieu;
            GioiHanTuoi = gioiHanTuoi;

        }
    }
}
