using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    public class NhanVien
    {
        public string roleID { get; set; }
        public string idNV { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string tenNV { get; set; }
        public string cmnd { get; set; }

        public string ngaysinh { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }
        public string calamviec { get; set; }
    }
}
