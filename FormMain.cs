using Project.BUS;
using System;
using System.Windows.Forms;

namespace Project
{
    public partial class FormMain : Form
    {
        private bool isLoggedIn = false;
        public FormMain()
        {
            InitializeComponent();
            uBUS = new UserBUS();
        }
        private UserBUS uBUS;
        private void FormLogin_LoginSuccess(string role, string username)
        {
            if (role == "BS")
            {
                menuUser.Enabled = true;
                menuDanhMuc.Enabled = true;
                menuPhieu.Enabled = true;
                menuHSBN.Enabled = true;
                MessageBox.Show("Phòng khám xin chào bác sĩ.", "Thông báo", MessageBoxButtons.OK);
            }
            else if (role == "DS")
            {  
                menuDanhMuc.Enabled= true;
                menuPhieu.Enabled= true;
                menuToaThuoc.Enabled= true;
                menuThuoc.Enabled = true;
                menuHSBN.Enabled = false;
                menuUser.Enabled = false;
                MessageBox.Show("Phòng khám xin chào dược sĩ.", "Thông báo", MessageBoxButtons.OK);
            }
            isLoggedIn = true;
            đăngNhậpToolStripMenuItem.Text = "Đăng xuất";


        }
        private void menuThuoc_Click(object sender, EventArgs e)
        {
            FormThuoc formThuoc = new FormThuoc();
            formThuoc.ShowDialog();
        }

        private void menuHSBN_Click(object sender, EventArgs e)
        {
            FormHSBN formHSBN = new FormHSBN();
            formHSBN.ShowDialog();
        }

        private void menuPhieuKhamBenh_Click(object sender, EventArgs e)
        {
            FormPhieuKhamBenh formPKB = new FormPhieuKhamBenh();
            formPKB.ShowDialog();
        }

        private void menuToaThuoc_Click(object sender, EventArgs e)
        {
            FormToaThuoc form = new FormToaThuoc();
            form.ShowDialog(); 
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            menuDanhMuc.Enabled = false;
            menuPhieu.Enabled = false;
            menuUser.Enabled = false; 
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                FormLogin formLogin = new FormLogin();
                formLogin.LoginSuccess += FormLogin_LoginSuccess;
                formLogin.ShowDialog();
            }
            else
            {
                isLoggedIn = false;
                đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
                menuPhieu.Enabled = false;
                menuDanhMuc.Enabled = false;
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            FormUser form = new FormUser();
            form.ShowDialog();
        }
    }
}
