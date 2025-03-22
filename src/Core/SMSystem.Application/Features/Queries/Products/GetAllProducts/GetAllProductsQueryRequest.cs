using MediatR;

namespace SMSystem.Application.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public List<int> CategorIds { get; set; } = new();
        public string ProductSearch { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageCount { get; set; } = 10;
    }
}
