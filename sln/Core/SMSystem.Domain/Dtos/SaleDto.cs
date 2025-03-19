namespace SMSystem.Domain.Dtos
{
    public class SaleDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string StaffName { get; set; }
    }
}