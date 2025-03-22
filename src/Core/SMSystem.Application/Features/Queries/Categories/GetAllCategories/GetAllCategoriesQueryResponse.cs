using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryResponse : HandleDataResult<GetAllCategoriesQueryResponse, List<CategoryDto>>
    {
    }
}