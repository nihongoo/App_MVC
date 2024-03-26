using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class HoaDon
    {
        public Guid InvoiceId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public Guid UserId { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<HoaDonCT> HoaDonCT { get; set; }
    }
}
