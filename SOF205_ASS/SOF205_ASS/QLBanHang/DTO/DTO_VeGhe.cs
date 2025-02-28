using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_VeGhe
    {
       
            public long IdVeGhe { get; set; }
            public long IdGhe { get; set; }
            public long IdHoaDon { get; set; }
            public long IdSuat { get; set; }

            // Constructor
            public DTO_VeGhe(long idVeGhe, long idGhe, long idHoaDon, long idSuat)
            {
                IdVeGhe = idVeGhe;
                IdGhe = idGhe;
                IdHoaDon = idHoaDon;
                IdSuat = idSuat;
            }
        }

    }

