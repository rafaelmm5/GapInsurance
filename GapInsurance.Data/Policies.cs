namespace GapInsurance.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Policies
    {
        public Policies()
        {
            Customer_Policies = new HashSet<Customer_Policies>();
            Coverages = new HashSet<Coverages>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Customer_Policies> Customer_Policies { get; set; }

        public virtual ICollection<Coverages> Coverages { get; set; }
    }
}
