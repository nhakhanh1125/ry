using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TaiKhoan
    {
        public long idTaiKhoan { get; set; }
        public long idLoaiTaiKhoan { get; set; }
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public string hoTen { get; set; }
        public string soDienThoai { get; set; }
        public string diaChi { get; set; }
        public string email { get; set; }
        public int diemTichLuy { get; set; }

        // Default constructor
        public DTO_TaiKhoan() { }

        // Parameterized constructor
        public DTO_TaiKhoan(long idTaiKhoan, long idLoaiTaiKhoan, string taiKhoan, string matKhau, string hoTen, string soDienThoai, string diaChi, string email, int diemTichLuy)
        {
            this.idTaiKhoan = idTaiKhoan;
            this.idLoaiTaiKhoan = idLoaiTaiKhoan;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.hoTen = hoTen;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
            this.email = email;
            this.diemTichLuy = diemTichLuy;
        }
    }
}
