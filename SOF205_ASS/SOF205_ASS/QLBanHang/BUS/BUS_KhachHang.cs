using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBanHang;
using DTO_QLBanHang;
using System.Data;
namespace BUS_QLBanHang
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
        // xuất danh sách 
        public DataTable DanhSachKH()
        {
            return dal_KhachHang.danhSachKH();
        }
        // thêm khách hàng
        public bool insertKhachHang(DTO_KhachHang khachHang)
        {
            return dal_KhachHang.insertKH(khachHang);
        }
        // xóa khách hàng
        public bool deleteKhachHang(string sdt)
        {
            return dal_KhachHang.deleteKH(sdt);
        }
        // sửa khách hàng
        public bool updateKhachHang(DTO_KhachHang khachHang)
        {
            return dal_KhachHang.updateKH(khachHang);
        }
        // tìm kiếm khách hàng
        public DataTable searchKhachHang(string tenkhach)
        {
            return dal_KhachHang.searchKH(tenkhach);
        }
        public string getPassword()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(randomString(4, true));
            builder.Append(r.Next(1000, 9999));
            builder.Append(randomString(2, false));
            return builder.ToString();

        }
        private string randomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToUpper();

            }
            else return builder.ToString().ToLower();
        }
    }

}
