using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSystem.Domain.Entities;

namespace SMSystem.Persistance.Configurations
{
    public class InventoryConfigurations : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.WarehouseName).IsRequired().HasMaxLength(100);

            builder.HasOne(s => s.Product)
                   .WithMany(p => p.Inventories)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}