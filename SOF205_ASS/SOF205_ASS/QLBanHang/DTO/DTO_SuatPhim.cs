using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SuatPhim
    {
        public long ID_Phim { get; set; }

        public DTO_SuatPhim(long idPhim)
        {
            ID_Phim = idPhim;
        }

        public override string ToString()
        {
            return ID_Phim.ToString(); // Override ToString to return ID_Phim
        }
    }
}
