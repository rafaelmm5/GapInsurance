using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class CustomersDto
    {
        public CustomersDto()
        {
            Customer_Policies = new List<Customer_PoliciesDto>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ClientId { get; set; }

        public ClientsDto Clients { get; set; }

        public IList<Customer_PoliciesDto> Customer_Policies { get; set; }
    }
}
