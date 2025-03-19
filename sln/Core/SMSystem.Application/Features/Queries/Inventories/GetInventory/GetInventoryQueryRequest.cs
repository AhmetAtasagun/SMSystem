using MediatR;

namespace SMSystem.Application.Features.Queries.Inventories.GetInventory
{
    public class GetInventoryQueryRequest : IRequest<GetInventoryQueryResponse>
    {
        public int Id { get; set; }
    }
}