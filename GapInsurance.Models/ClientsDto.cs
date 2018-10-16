using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class ClientsDto
    {
        public ClientsDto()
        {
            Customers = new List<CustomersDto>();
            Users = new List<UsersDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CustomersDto> Customers { get; set; }

        public IList<UsersDto> Users { get; set; }
    }
}
