
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_IDPhong
    {
        public long IdPhong { get; set; }



        public DTO_IDPhong(long idPhong)
        {
            IdPhong = idPhong;

        }
        public override string ToString()
        {
            return IdPhong.ToString();
        }
    }
}
