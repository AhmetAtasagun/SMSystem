using MediatR;

namespace SMSystem.Application.Features.Commands.Sales.DeleteSale
{
    public class DeleteSaleCommandRequest : IRequest<DeleteSaleCommandResponse>
    {
        public int Id { get; set; }
    }
}