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
    public partial class frmRoleNV : Form
    {
        public frmRoleNV()
        {
            InitializeComponent();
            RoleBUS role = new RoleBUS();
            grvRole.DataSource = role.getData();
            grvRole.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            RoleBUS role = new RoleBUS();
            RoleNV rolenv = new RoleNV(txtRoleID.Text, txtTenRole.Text, txtMoTa.Text);
            
            if (role.CheckID(txtRoleID.Text) == true)
            {
                MessageBox.Show("Mã Role đã tồn tại!");
            }
            else
            {
                role.addData(rolenv);
                grvRole.DataSource = role.getData();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            RoleBUS role = new RoleBUS();
            RoleNV rolenv = new RoleNV(txtRoleID.Text, txtTenRole.Text, txtMoTa.Text);
            if(role.edit(rolenv) == 1)
            {
                MessageBox.Show("Sua thanh cong!");
                grvRole.DataSource = role.getData();
            }
        }

        private void grvRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoleID.Text = grvRole.CurrentRow.Cells[0].Value.ToString();
            txtTenRole.Text = grvRole.CurrentRow.Cells[1].Value.ToString();
            txtMoTa.Text = grvRole.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
