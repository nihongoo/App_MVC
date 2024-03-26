using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
    public class GioHang
    {
        public Guid CartId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
