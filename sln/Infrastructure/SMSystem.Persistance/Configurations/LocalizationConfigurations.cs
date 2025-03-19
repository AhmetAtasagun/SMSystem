using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSystem.Domain.Entities;

namespace SMSystem.Persistance.Configurations
{
    public class LocalizationConfigurations : IEntityTypeConfiguration<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.ResourceKey).IsRequired().HasMaxLength(255);
            builder.Property(l => l.CultureCode).IsRequired().HasMaxLength(10);
            builder.Property(l => l.ResourceValue).IsRequired();
            
            builder.HasIndex(l => new { l.ResourceKey, l.CultureCode }).IsUnique();
        }
    }
}