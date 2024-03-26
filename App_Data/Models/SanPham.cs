using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class SanPham
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid ProductTypeId { get; set; } 

        public Guid BrandId { get; set; } 

        public string Material { get; set; }

        public DateTime ImportDate { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        public virtual LoaiSP LoaiSP{ get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
