using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Queries.Inventories.GetAllInventories
{
    public class GetAllInventoriesQueryResponse : HandleDataPagedResult<GetAllInventoriesQueryResponse, List<InventoryDto>>
    {
    }
}