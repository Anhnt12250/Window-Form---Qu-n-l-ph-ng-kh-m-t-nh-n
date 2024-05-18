using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    internal class UserDAO
    {
        public UserDAO() { }
        private string cons = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLPhongKham;Integrated Security=True";
        public DataTable getAllUser()
        {
            DataTable dt = new DataTable();
            string query = "Select * from Users";
            try
            {
                dt = DataProvider.ExecuteSelectAllQuerry(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }
        public void AddUser(User user)
        {
            string q = "INSERT INTO Users ([Id], [HoTen], [SDT], [GioiTinh],[NgaySinh], [Role]) " +
                        "VALUES (@Id, @HoTen, @SDT, @GioiTinh, @NgaySinh, @Role)";
            using (SqlConnection connection = new SqlConnection(cons))
            {
                SqlCommand command = new SqlCommand(q, connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@HoTen", user.HoTen);
                command.Parameters.AddWithValue("@SDT", user.SDT);
                command.Parameters.AddWithValue("@GioiTinh", user.GioiTinh);
                command.Parameters.AddWithValue("@NgaySinh", user.NgaySinh);
                command.Parameters.AddWithValue("@Role", user.Role);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteUser(string id)
        {
            try
            {
                string q = "DELETE FROM Users WHERE [Id] = @Id";

                using (SqlConnection connection = new SqlConnection(cons))
                {
                    SqlCommand command = new SqlCommand(q, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateUser(User user)
        {
            string q = "UPDATE Users SET [HoTen] = @HoTen, [SDT] = @SDT, [GioiTinh] = @GioiTinh, [NgaySinh] = @NgaySinh, [Role] = @Role WHERE [Id] = @Id";

            using (SqlConnection connection = new SqlConnection(cons))
            {
                SqlCommand command = new SqlCommand(q, connection);
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@HoTen", user.HoTen);
                command.Parameters.AddWithValue("@SDT", user.SDT);
                command.Parameters.AddWithValue("@GioiTinh", user.GioiTinh);
                command.Parameters.AddWithValue("@NgaySinh", user.NgaySinh);
                command.Parameters.AddWithValue("@Role", user.Role);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
