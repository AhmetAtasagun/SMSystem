using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSystem.Domain.Entities;

namespace SMSystem.Persistance.Configurations
{
    public class SaleConfigurations : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            throw new NotImplementedException();
            // TODO
        }
    }
}
