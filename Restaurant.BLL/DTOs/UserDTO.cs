namespace Restaurant.BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

       
        public string Login { get; set; }

       
        public string Password { get; set; }

        public int RoleId { get; set; }


        public string? PhoneNumber { get; set; }

        public RoleDTO Role { get; set; }
    }
}