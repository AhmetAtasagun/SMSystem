using Microsoft.EntityFrameworkCore;
using SMSystem.Domain.Entities;
using SMSystem.Persistance.Configurations;
using System.Reflection;

namespace SMSystem.Persistance.Contexts
{
    public class SMSDbContext : DbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });
            // Configuration Register
            //var assembly = Assembly.GetExecutingAssembly();
            //foreach (var typeConfig in assembly.DefinedTypes.Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(IEntityTypeConfiguration<>))))
            //{
            //    dynamic configuration = Activator.CreateInstance(typeConfig);
            //    modelBuilder.ApplyConfiguration(configuration);
            //}
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfigurations());
            modelBuilder.ApplyConfiguration(new SaleConfigurations());
            modelBuilder.ApplyConfiguration(new StockConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
