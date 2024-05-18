using Project.DAO;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BUS
{
    internal class UserBUS
    {
        private UserDAO userDAO;
        public UserBUS()
        {
            userDAO = new UserDAO();
        }
        public List<User> getAllUser()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = userDAO.getAllUser();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            List<User> list = new List<User>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    User u = new User();

                    u.Id = dr["Id"].ToString();
                    u.HoTen = dr["HoTen"].ToString();
                    u.GioiTinh = dr["GioiTinh"].ToString();
                    u.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
                    u.SDT = dr["SDT"].ToString();
                    u.Role = dr["Role"].ToString();
                    list.Add(u);
                }
            }
            return list;
        }
        public void AddUser(User u)
        {
            try
            {
                string id = u.Id;
                string HoTen = u.HoTen;
                string gender = u.GioiTinh;
                DateTime? NgaySinh = u.NgaySinh;
                string role = u.Role;
                string SDT = u.SDT;
                userDAO.AddUser(u);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateUser(User u)
        {
            try
            {
                string id = u.Id;
                string HoTen = u.HoTen;
                string gender = u.GioiTinh;
                DateTime? NgaySinh = u.NgaySinh;
                string role = u.Role;
                string SDT = u.SDT;
                userDAO.UpdateUser(u);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteUser(string id)
        {
            userDAO.DeleteUser(id);
        }
    }
}
