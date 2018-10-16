using System;

namespace GapInsurance.Models
{
    public class Customer_PoliciesDto
    {
        public int Id { get; set; }

        public int PolicyId { get; set; }

        public int CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public CustomersDto Customers { get; set; }

        public PoliciesDto Policies { get; set; }

        public int CoverPercentage { get; set; }

        public RiskType RiskType { get; set; }

        public bool Active { get; set; }
       
    }
}
