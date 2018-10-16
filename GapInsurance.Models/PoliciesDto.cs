using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class PoliciesDto
    {
        public PoliciesDto()
        {
            Customer_Policies = new List<Customer_PoliciesDto>();
            Coverages = new List<CoveragesDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Customer_PoliciesDto> Customer_Policies { get; set; }

        public IList<CoveragesDto> Coverages { get; set; }
    }
}
