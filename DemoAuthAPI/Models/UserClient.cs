using DAL.Models;

namespace DemoAuthAPI.Models
{
    public class UserClient
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; }

        public UserClient(AppUser u)
        {
            Id = u.Id;
            Email = u.Email;
            NickName = u.NickName;
            Role = u.Role;
        }
    }
}
