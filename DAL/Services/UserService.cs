using DAL.Abstraction;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services
{
    public class UserService : IUserRepo
    {
        private string _cs;
        public UserService(IConfiguration config)
        {
            _cs = config.GetConnectionString("default");
        }

        public AppUser Login(string email, string password)
        {
            using (SqlConnection c = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "AppUserLogin";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("passwd", password);

                    c.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AppUser
                            {
                                Id = (int)reader["Id"],
                                Email = (string)reader["Email"],
                                NickName = (string)reader["NickName"],
                                Role = (string)reader["Role"],
                            };
                        }
                        else { throw new ArgumentNullException("User inexistant"); }
                    }
                }
            }
        }

        public IEnumerable<AppUser> GetAll()
        {
            using (SqlConnection c = new SqlConnection(_cs))
            {
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM V_AppUser";

                    c.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new AppUser
                            {
                                Id = (int)reader["Id"],
                                Email = (string)reader["Email"],
                                NickName = (string)reader["NickName"],
                                Role = (string)reader["Role"],
                            };
                        }
                    }
                }
            }
        }
    }
}
