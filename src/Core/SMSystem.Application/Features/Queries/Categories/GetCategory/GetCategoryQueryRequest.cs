using MediatR;

namespace SMSystem.Application.Features.Queries.Categories.GetCategory
{
    public class GetCategoryQueryRequest : IRequest<GetCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}