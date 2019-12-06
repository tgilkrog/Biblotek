using Model.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDataAccess
    {
        static string connectionString = "Server=TG; Initial Catalog=bookK; Integrated Security=true";

        public List<User> GetAllUsers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From [dbo].[bookKUser]", connection);
                connection.Open();
                var reader = cmd.ExecuteReader();

                List<User> users = new List<User>();

                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                    });
                }
                return users;
            };
        }

        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into [dbo].[bookKUser](userName) values(@userName)";
                    cmd.Parameters.AddWithValue("userName", user.UserName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
