using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSystem.Domain.Entities;

namespace SMSystem.Persistance.Configurations
{
    public class StockConfigurations : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            throw new NotImplementedException();
            // TODO
        }
    }
}
