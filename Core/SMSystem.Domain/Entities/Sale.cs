using SMSystem.Domain.Entities.Common;

namespace SMSystem.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int StaffId { get; set; }
        public User Staff { get; set; }
    }
}
