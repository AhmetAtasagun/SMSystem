using MediatR;

namespace SMSystem.Application.Features.Commands.Sales.UpdateSale
{
    public class UpdateSaleCommandRequest : IRequest<UpdateSaleCommandResponse>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int StaffId { get; set; }
    }
}