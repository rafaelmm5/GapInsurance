using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class CoveragesDto
    {
        public CoveragesDto()
        {
            Policies = new List<PoliciesDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<PoliciesDto> Policies { get; set; }
    }
}
