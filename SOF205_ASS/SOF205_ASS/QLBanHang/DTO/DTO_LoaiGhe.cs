using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiGhe
    {
        public long IdLoaiGhe { get; set; } // ID_LOAIGHE
        public string TenLoaiGhe { get; set; } // TENLOAIGHE (nullable)
        public long Gia { get; set; } // GIA (nullable)

        public DTO_LoaiGhe()
        {
        }

        public DTO_LoaiGhe(long idLoaiGhe, string tenLoaiGhe, long gia)
        {
            IdLoaiGhe = idLoaiGhe;
            TenLoaiGhe = tenLoaiGhe;
            Gia = gia;
        }
    }
}

