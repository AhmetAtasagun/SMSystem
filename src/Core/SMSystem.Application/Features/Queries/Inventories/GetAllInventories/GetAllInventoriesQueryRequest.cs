using MediatR;

namespace SMSystem.Application.Features.Queries.Inventories.GetAllInventories
{
    public class GetAllInventoriesQueryRequest : IRequest<GetAllInventoriesQueryResponse>
    {
        public int? ProductId { get; set; }
        public string? WarehouseSearch { get; set; }
    }
}