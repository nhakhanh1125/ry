using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Phong
    {
        public long IdPhong { get; set; }
        public string TenPhong { get; set; }
        public long SoLuongGhe { get; set; }

        // Constructor without parameters
        public DTO_Phong() { }

        // Constructor with parameters
        public DTO_Phong(long idPhong, string tenPhong, long soLuongGhe)
        {
            IdPhong = idPhong;
            TenPhong = tenPhong;
            SoLuongGhe = soLuongGhe;
        }
    }
}
