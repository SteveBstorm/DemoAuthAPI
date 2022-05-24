using DAL.Abstraction;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class FakeUserService : IUserRepo
    {
        private List<AppUser> _users;
        public FakeUserService()
        {
            _users = new List<AppUser>();
            _users.Add(new AppUser { Email = "aude@api.com", Id = 1, NickName = "Gandalf", Role = "Admin", Password = "test1234" });
            _users.Add(new AppUser { Email = "steve@api.com", Id = 2, NickName = "Yoda", Role = "Moderator", Password = "test1234" });
            _users.Add(new AppUser { Email = "khun@api.com", Id = 3, NickName = "Captain Kirk", Role = "User", Password = "test1234" });
        }
        public IEnumerable<AppUser> GetAll()
        {
            return _users;
        }

        public AppUser Login(string email, string password)
        {
            try
            {
                return _users.First(x => x.Email == email && x.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception("Utilisateur inexistant");
            }
        }
    }
}
