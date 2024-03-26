using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class SizeSanPham
    {
        public Guid SizeId { get; set; }

        public Guid ProductId { get; set; }

        public virtual Size Size { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
