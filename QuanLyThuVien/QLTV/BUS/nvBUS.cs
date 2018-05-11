using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DAO;
using QLTV.DTO;

namespace QLTV.BUS
{
    public class nvBUS
    {
        nvDAO nv = new nvDAO();

        public DataTable getData()
        {
            try
            {
                return nv.getData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int addData(NhanVien nhanvien)
        {
            return nv.addnewNV(nhanvien);
        }
        public int edit(NhanVien nhanvien)
        {
            if (nv.edit(nhanvien) == 1)
                return 1;
            return 0;
        }


    }
}
