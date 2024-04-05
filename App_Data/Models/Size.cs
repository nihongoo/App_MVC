using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class Size
    {
        public Guid SizeId { get; set; }

        public string SizeName { get; set; }
        
        public virtual ICollection<SizeSanPham> SizeSanPhams { get; set; }

        public virtual ICollection<HoaDonCT> HoaDonCTs { get; set; }
    }
}
