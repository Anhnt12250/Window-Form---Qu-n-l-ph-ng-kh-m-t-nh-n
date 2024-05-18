using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    internal class User
    {
        public User() { }
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Role { get; set; }
    }
}
