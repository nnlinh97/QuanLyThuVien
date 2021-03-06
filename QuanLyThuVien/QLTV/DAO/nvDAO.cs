﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DTO;

namespace QLTV.DAO
{
    public class nvDAO
    {
        Data data = new Data();
        public DataTable getData()
        {
            return data.getData("select nv.RoleID, role.roleName,nv.ID,nv.Username,nv.Password, nv.FullName,nv.CMND, nv.DataOfBirth, nv.Address, nv.Email, nv.CaLamViec from RoleNV role, NhanVien nv where role.ID = nv.RoleID");
        }

        public int addnewNV(NhanVien nv)
        {
            DateTime date = Convert.ToDateTime(nv.ngaysinh);
            string sql = "insert into NhanVien values('" + nv.idNV + "',N'" + nv.username + "','" + nv.password + "',N'" + nv.tenNV + "','" + nv.cmnd + "','" + date.ToString("MM-dd-yyyy") + "',N'" + nv.diachi + "','" + nv.email + "',N'" + nv.calamviec + "','" + nv.roleID + "')";
            return data.add(sql);
        }

        public int edit(NhanVien nv)
        {
            DateTime date = Convert.ToDateTime(nv.ngaysinh);
            string sql = "update NhanVien set Username='" + nv.username + "',Password='" + nv.password + "',FullName='" + nv.tenNV + "',CMND='" + nv.cmnd + "',DataOfBirth='" + date.ToString("MM-dd-yyyy") + "',Address=N'" + nv.diachi + "',Email='" + nv.email + "',CaLamViec=N'" + nv.calamviec + "'  where ID ='" + nv.idNV+ "'";
            if (data.Edit(sql) > 0)
                return 1;
            return 0;
        }

        public showNV displayFrmNV(string id)
        {
            showNV sNV = null;
            string sql = "select nv.RoleID, role.roleName,nv.ID,nv.Username,nv.Password, nv.FullName,nv.CMND, nv.DataOfBirth, nv.Address, nv.Email, nv.CaLamViec from RoleNV role, NhanVien nv where role.ID = nv.RoleID and nv.ID = '" + id + "'";
            DataTable table = data.getData(sql);
            foreach (DataRow item in table.Rows)
            {
                sNV = new showNV(item);
                return sNV;
            }
            return sNV;
        }

        public Account login(string username, string password)
        {
            Account acc = null;
            string sql = "select nv.RoleID,nv.Username,nv.Password from RoleNV role, NhanVien nv where role.ID = nv.RoleID and nv.Username = '" + username + "' and nv.Password = '" + password + "'";
            DataTable table = data.getData(sql);
            foreach (DataRow item in table.Rows)
            {
                acc = new Account(item);
                return acc;
            }
            return acc;
        }
    }
}
