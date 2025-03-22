using SMSystem.Domain.Enums;

namespace SMSystem.Domain.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Process { get; set; }
        public string WarehouseName { get; set; }
        public int ProductId { get; set; }
    }
}