using ApiDemokrata.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiDemokrata.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(entity => 
            {
                entity.Property(e =>e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e=>e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Salary).IsRequired().HasPrecision(18, 2);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("GETDATE()");
            });
        }

    }
}
