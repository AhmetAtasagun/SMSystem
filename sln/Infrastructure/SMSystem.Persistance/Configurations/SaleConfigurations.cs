using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSystem.Domain.Entities;

namespace SMSystem.Persistance.Configurations
{
    public class SaleConfigurations : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(s => s.Quantity).IsRequired();
            
            builder.HasOne(s => s.Product)
                   .WithMany()
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasOne(s => s.Staff)
                   .WithMany()
                   .HasForeignKey(s => s.StaffId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
