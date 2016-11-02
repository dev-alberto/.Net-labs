using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class DbEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Adress)
                .IsRequired().HasMaxLength(300);

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.PhoneNumber)
                .IsRequired()
                .Equals(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Email)
                .IsRequired()
                .Equals(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = EntityModel; Trusted_Connection = True;");
        }
    }
}