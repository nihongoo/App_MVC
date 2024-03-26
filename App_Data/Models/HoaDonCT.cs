using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class HoaDonCT
    {
        public Guid InvoiceDetailId { get; set; }

        public Guid InvoiceId { get; set; }

        public Guid ProductId { get; set; }

        public Guid SizeId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual Size Size { get; set; }
    }
}
