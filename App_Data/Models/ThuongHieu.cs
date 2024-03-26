using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class ThuongHieu
    {
        public Guid BrandId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<SanPham> sanPhams { get; set; }
    }
}
