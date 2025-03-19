using SMSystem.Domain.Entities.Common;
using SMSystem.Domain.Enums;

namespace SMSystem.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int Quantity { get; set; }
        public InvertoryProcess Process { get; set; }
        public string WarehouseName { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}