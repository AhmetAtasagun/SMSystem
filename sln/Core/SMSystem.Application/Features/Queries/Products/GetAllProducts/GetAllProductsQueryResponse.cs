using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryResponse: HandleDataPagedResult<GetAllProductsQueryResponse, List<ProductDto>>
    {
    }
}