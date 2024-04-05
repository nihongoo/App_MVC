using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Models
{
	public class User
	{
        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Role { get; set; }

        public virtual ICollection<HoaDon> HoaDon { get; set; }

        public virtual ICollection<GioHang> GioHang { get; set;}

    }
}
