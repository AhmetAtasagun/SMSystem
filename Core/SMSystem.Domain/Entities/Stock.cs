using SMSystem.Domain.Entities.Common;

namespace SMSystem.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public int Quantity { get; set; }
        public int IncreaseQuantity { get; set; }
        public int DecreaseQuantity { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
