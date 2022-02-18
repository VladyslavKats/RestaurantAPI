using System.Collections.ObjectModel;

namespace Restaurant.BLL.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public Collection<UserDTO> Users { get; set; }
    }
}