using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class PermissionsDto
    {
        public PermissionsDto()
        {
            Users = new List<UsersDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Action { get; set; }

        public IList<UsersDto> Users { get; set; }
    }
}
