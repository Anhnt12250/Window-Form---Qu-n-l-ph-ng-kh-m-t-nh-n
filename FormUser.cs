using Project.BUS;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
            uBus = new UserBUS();
        }
        private UserBUS uBus;
        private void ResetValue()
        {
            txtID.Text = "";
            txtHoten.Text = "";
            txtSdt.Text = "";
            cmbGioitinh.Text = "";
            cmBRole.Text = "";
            dateNgaysinh.Text = "";
        }
        public void LoadDataWithDataReader()
        {
            List<User> List = uBus.getAllUser();
            dgvListUser.DataSource = List;
            dgvListUser.Columns[0].HeaderText = "Id";
            dgvListUser.Columns[1].HeaderText = "Họ tên";
            dgvListUser.Columns[2].HeaderText = "SDT";
            dgvListUser.Columns[3].HeaderText = "Giới tính";
            dgvListUser.Columns[4].HeaderText = "Ngày sinh";
            dgvListUser.Columns[5].HeaderText = "Role";
            dgvListUser.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvListUser.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void FormUser_Load(object sender, EventArgs e)
        {
            LoadDataWithDataReader();
        }

        private void dgvListBN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmBRole.Text = dgvListUser.CurrentRow.Cells["Role"].Value.ToString();
            txtHoten.Text = dgvListUser.CurrentRow.Cells["HoTen"].Value.ToString();
            txtID.Text = dgvListUser.CurrentRow.Cells["Id"].Value.ToString();
            txtSdt.Text = dgvListUser.CurrentRow.Cells["SDT"].Value.ToString();
            dateNgaysinh.Text = dgvListUser.CurrentRow.Cells["NgaySinh"].Value.ToString();
            cmbGioitinh.Text = dgvListUser.CurrentRow.Cells["GioiTinh"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User u = new User
            {
                Id = txtID.Text,
                HoTen = txtHoten.Text,
                GioiTinh = cmbGioitinh.Text,
                NgaySinh = DateTime.Parse(dateNgaysinh.Text),
                Role = cmBRole.Text,
                SDT = txtSdt.Text,
            };
            uBus.AddUser(u);
            LoadDataWithDataReader();
            ResetValue();
        }

        private void btntEdit_Click(object sender, EventArgs e)
        {
            User u = new User
            {
                Id = txtID.Text,
                HoTen = txtHoten.Text,
                GioiTinh = cmbGioitinh.Text,
                NgaySinh = DateTime.Parse(dateNgaysinh.Text),
                Role = cmBRole.Text,
                SDT = txtSdt.Text,
            };
            uBus.UpdateUser(u);
            LoadDataWithDataReader();
            ResetValue();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            uBus.DeleteUser(txtID.Text);
            LoadDataWithDataReader();
            ResetValue();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
