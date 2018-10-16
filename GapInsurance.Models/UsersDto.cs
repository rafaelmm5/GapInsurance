using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class UsersDto
    {
        public UsersDto()
        {
            Permissions = new List<PermissionsDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? ClientId { get; set; }

        public string UserType { get; set; }

        public ClientsDto Clients { get; set; }

        public IList<PermissionsDto> Permissions { get; set; }
    }
}
