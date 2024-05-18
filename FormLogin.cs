using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class FormLogin : Form
    {
        public bool IsAdmin { get; private set; }
        public event LoginSuccessEventHandler LoginSuccess;
        public delegate void LoginSuccessEventHandler(string role, string username);
        public FormLogin()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = '*';
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            string username = txtBoxTaiKhoan.Text;
            string password = txtBoxPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                DialogResult result = MessageBox.Show("Vui lòng nhập tên tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            try
            {
                string sql = $"SELECT Role FROM Users WHERE Id = @username AND SDT = @password";
                using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLPhongKham;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        string role = command.ExecuteScalar()?.ToString();
                        if (role == "BS")
                        {
                            IsAdmin = true;
                        }
                        else if (role == "DS")
                        {
                            IsAdmin = false;
                        }
                        else
                        {
                            MessageBox.Show("Tên người dùng hoặc mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK);
                            return;
                        }

                        LoginSuccess?.Invoke(role, username);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đăng nhập: " + ex.Message);
            }

        }
    }
}
