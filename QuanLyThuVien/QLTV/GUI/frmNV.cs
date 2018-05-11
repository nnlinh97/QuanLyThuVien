using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.BUS;
using QLTV.DAO;
using QLTV.DTO;
namespace QLTV
{
    public partial class frmNV : Form
    {
        public void disnable()
        {
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            txtTenNV.Enabled = false;
            txtCMND.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtCaLamViec.Enabled = false;
            cbbVaiTro.Enabled = false;
        }
        public void clear()
        {
            txtUser.Clear();
            txtPass.Clear();
            txtTenNV.Clear();
            txtCMND.Clear();
            txtNgaySinh.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtCaLamViec.Clear();
            txtMaNV.Clear();
        }
        public void enable()
        {
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            txtTenNV.Enabled = true;
            txtCMND.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtCaLamViec.Enabled = true;
            cbbVaiTro.Enabled = true;
        }
        public frmNV()
        {
            InitializeComponent();
            nvBUS role = new nvBUS();
            grvNV.DataSource = role.getData();
            grvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            disnable();
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool check = false;
        private void btnThem_Click(object sender, EventArgs e)
        {
            enable();
            clear();
            RoleBUS role = new RoleBUS();
            cbbVaiTro.DataSource = role.Getlist();
            cbbVaiTro.DisplayMember = "roleName";
            check = true;
        }

        private void grvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = grvNV.CurrentRow.Cells[2].Value.ToString();
            txtUser.Text = grvNV.CurrentRow.Cells[3].Value.ToString();
            txtPass.Text = grvNV.CurrentRow.Cells[4].Value.ToString();
            txtTenNV.Text = grvNV.CurrentRow.Cells[5].Value.ToString();
            txtCMND.Text = grvNV.CurrentRow.Cells[6].Value.ToString();
            txtNgaySinh.Text = grvNV.CurrentRow.Cells[7].Value.ToString();
            txtDiaChi.Text = grvNV.CurrentRow.Cells[8].Value.ToString();
            txtEmail.Text = grvNV.CurrentRow.Cells[9].Value.ToString();
            txtCaLamViec.Text = grvNV.CurrentRow.Cells[10].Value.ToString();
            cbbVaiTro.Text = grvNV.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            RoleBUS role = new RoleBUS();
            string roleID = role.getRoleID(cbbVaiTro.Text);
            // MessageBox.Show(roleID);

            nvBUS nvBus = new nvBUS();
            NhanVien nv = new NhanVien();
            nv.roleID = roleID;
            nv.idNV = txtMaNV.Text;
            nv.username = txtUser.Text;
            nv.password = txtPass.Text;
            nv.tenNV = txtTenNV.Text;
            nv.cmnd = txtCMND.Text;
            nv.ngaysinh = txtNgaySinh.Text;
            nv.diachi = txtDiaChi.Text;
            nv.email = txtEmail.Text;
            nv.calamviec = txtCaLamViec.Text;
            if (check == true)
            {
                nvBus.addData(nv);
                disnable();
                clear();
                check = false;
            }
            else
            {
                nvBus.edit(nv);
                disnable();
                clear();
                check = false;
            }
                grvNV.DataSource = nvBus.getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enable();
            RoleBUS role = new RoleBUS();
            cbbVaiTro.DataSource = role.Getlist();
            cbbVaiTro.DisplayMember = "roleName";
        }
    }
}
