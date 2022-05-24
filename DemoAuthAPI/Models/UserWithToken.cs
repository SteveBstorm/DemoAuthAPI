namespace DemoAuthAPI.Models
{
    public class UserWithToken
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public UserWithToken(UserClient u)
        {
            Id = u.Id;
            Email = u.Email;
            NickName = u.NickName;
            Role = u.Role;
        }

    }
}
