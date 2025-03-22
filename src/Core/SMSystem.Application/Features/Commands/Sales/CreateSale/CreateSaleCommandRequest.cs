using MediatR;

namespace SMSystem.Application.Features.Commands.Sales.CreateSale
{
    public class CreateSaleCommandRequest : IRequest<CreateSaleCommandResponse>
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int StaffId { get; set; }
    }
}
