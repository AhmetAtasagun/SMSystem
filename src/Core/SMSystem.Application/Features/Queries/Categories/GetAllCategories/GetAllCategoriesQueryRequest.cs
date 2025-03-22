using MediatR;

namespace SMSystem.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<GetAllCategoriesQueryResponse>
    {
        public int? ParentId { get; set; }
    }
}