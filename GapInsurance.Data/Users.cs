namespace GapInsurance.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Users
    {
        public Users()
        {
            Permissions = new HashSet<Permissions>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int? ClientId { get; set; }

        [StringLength(30)]
        public string UserType { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}
