using DAL.Models;
using System.Collections.Generic;

namespace DAL.Abstraction
{
    public interface IUserRepo
    {
        AppUser Login(string email, string password);
        IEnumerable<AppUser> GetAll();
    }
}