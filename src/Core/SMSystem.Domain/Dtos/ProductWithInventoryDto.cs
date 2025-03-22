namespace SMSystem.Domain.Dtos
{
    public class ProductWithInventoryDto : ProductDto
    {
        public List<InventoryDto> Inventories { get; set; } = new();
    }
}