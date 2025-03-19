using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories.InventoryRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Inventories.GetAllInventories
{
    public class GetAllInventoriesQueryHandler : IRequestHandler<GetAllInventoriesQueryRequest, GetAllInventoriesQueryResponse>
    {
        private readonly IInventoryReadRepository _inventoryReadRepository;
        private readonly IMapper _mapper;

        public GetAllInventoriesQueryHandler(IInventoryReadRepository inventoryReadRepository, IMapper mapper)
        {
            _inventoryReadRepository = inventoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllInventoriesQueryResponse> Handle(GetAllInventoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var inventoryQuery = _inventoryReadRepository.GetAll();

            if (request.ProductId.HasValue)
            {
                inventoryQuery = inventoryQuery.Where(s => s.ProductId == request.ProductId.Value);
            }

            if (!string.IsNullOrEmpty(request.WarehouseSearch))
            {
                inventoryQuery = inventoryQuery.Where(s => s.WarehouseName.Contains(request.WarehouseSearch));
            }

            var totalInventoryCount = await inventoryQuery.CountAsync(cancellationToken);
            var inventories = await inventoryQuery
                .ProjectTo<InventoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetAllInventoriesQueryResponse().Success(inventories, totalInventoryCount);
        }
    }
}