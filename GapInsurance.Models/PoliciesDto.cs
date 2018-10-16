using System.Collections.Generic;

namespace GapInsurance.Models
{
    public class PoliciesDto
    {
        public PoliciesDto()
        {
            Coverages = new List<CoveragesDto>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<CoveragesDto> Coverages { get; set; }
    }
}
