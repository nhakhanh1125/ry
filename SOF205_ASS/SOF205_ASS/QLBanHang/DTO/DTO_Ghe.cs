using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ghe
    {
        public long IdGhe { get; set; } // ID_GHE
        public int GheSo { get; set; } // GHESO (nullable)
        public long IdDayGhe { get; set; } // ID_DAYGHE (nullable)
        public long IdLoaiGhe { get; set; } // ID_LOAIGHE (nullable)

        public DTO_Ghe()
        {
        }

        public DTO_Ghe(long idGhe, int gheSo, long idDayGhe, long idLoaiGhe)
        {
            IdGhe = idGhe;
            GheSo = gheSo;
            IdDayGhe = idDayGhe;
            IdLoaiGhe = idLoaiGhe;
        }
    }
}
