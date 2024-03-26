using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class LoaiSP
    {
        public Guid TypeId { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<SanPham> sanPhams { get; set; }
    }
}
