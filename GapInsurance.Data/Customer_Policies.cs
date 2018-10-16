namespace GapInsurance.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Customer_Policies
    {
        public int Id { get; set; }

        public int? PolicyId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Policies Policies { get; set; }

        public int RiskType { get; set; }

        public bool Active { get; set; }

        public int CoverPercentage { get; set; }
    }
}
