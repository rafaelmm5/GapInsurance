namespace GapInsurance.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class GapInsuranceDBModel : DbContext
    {
        public GapInsuranceDBModel()
            : base("name=GapInsuranceDBModel")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Coverages> Coverages { get; set; }
        public virtual DbSet<Customer_Policies> Customer_Policies { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Policies> Policies { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Clients)
                .HasForeignKey(e => e.ClientId);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Clients)
                .HasForeignKey(e => e.ClientId);

            modelBuilder.Entity<Coverages>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Coverages>()
                .HasMany(e => e.Policies)
                .WithMany(e => e.Coverages)
                .Map(m => m.ToTable("Policy_Coverages").MapLeftKey("CoverageId").MapRightKey("PolicyId"));

            modelBuilder.Entity<Customer_Policies>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Customer_Policies)
                .WithOptional(e => e.Customers)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Permissions>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Permissions>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<Permissions>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Permissions)
                .Map(m => m.ToTable("User_Permissions").MapLeftKey("PermissionId").MapRightKey("UserId"));

            modelBuilder.Entity<Policies>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Policies>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Policies>()
                .HasMany(e => e.Customer_Policies)
                .WithOptional(e => e.Policies)
                .HasForeignKey(e => e.PolicyId);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserType)
                .IsUnicode(false);
        }
    }
}
