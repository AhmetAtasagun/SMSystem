using MediatR;

namespace SMSystem.Application.Features.Queries.Products.GetProduct
{
    public class GetProductQueryRequest : IRequest<GetProductQueryResponse>
    {
        public int Id { get; set; }
    }
}
