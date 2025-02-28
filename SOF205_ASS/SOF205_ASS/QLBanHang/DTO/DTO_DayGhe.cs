using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DayGhe
    {
        public long IdDayGhe { get; set; } // ID_DAYGHE
        public string TenDay { get; set; } // TENDAY (nullable)
        public long IdPhong { get; set; } // ID_PHONG (nullable)

        public DTO_DayGhe()
        {
        }

        public DTO_DayGhe(long idDayGhe, string tenDay, long idPhong)
        {
            IdDayGhe = idDayGhe;
            TenDay = tenDay;
            IdPhong = idPhong;
        }
    }
}

