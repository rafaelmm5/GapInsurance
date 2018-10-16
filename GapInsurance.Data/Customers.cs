namespace GapInsurance.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Customers
    {
        public Customers()
        {
            Customer_Policies = new HashSet<Customer_Policies>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public int? ClientId { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual ICollection<Customer_Policies> Customer_Policies { get; set; }
    }
}
