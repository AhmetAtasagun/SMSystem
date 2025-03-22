using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSystem.Domain.Entities;
using System.Reflection;

namespace SMSystem.Persistance.Contexts
{
    public class SMSDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options)
        { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Localization> Localizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration Register
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var typeConfig in assembly.DefinedTypes.Where(x => x.IsSubclassOf(typeof(IEntityTypeConfiguration<>))))
            {
                dynamic configuration = Activator.CreateInstance(typeConfig);
                modelBuilder.ApplyConfiguration(configuration);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
