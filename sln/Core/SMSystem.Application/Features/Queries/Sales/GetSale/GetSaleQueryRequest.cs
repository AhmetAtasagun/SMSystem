using MediatR;

namespace SMSystem.Application.Features.Queries.Sales.GetSale
{
    public class GetSaleQueryRequest : IRequest<GetSaleQueryResponse>
    {
        public int Id { get; set; }
    }
}