using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Suat
    {
       
            public long IdSuat { get; set; }
            public long IdPhim { get; set; }
            public long IdPhong { get; set; }
            public DateTime NgayChieu { get; set; }
            public TimeSpan GioChieu { get; set; }

            public DTO_Suat() {     
            }
            // Constructor
            public DTO_Suat(long idSuat, long idPhim, long idPhong, DateTime ngayChieu, TimeSpan gioChieu)
            {
                IdSuat = idSuat;
                IdPhim = idPhim;
                IdPhong = idPhong;
                NgayChieu = ngayChieu;
                GioChieu = gioChieu;
            }
        }

    }

