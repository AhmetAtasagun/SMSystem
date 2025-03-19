using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.InventoryRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Inventories.GetInventory
{
    public class GetInventoryQueryHandler : IRequestHandler<GetInventoryQueryRequest, GetInventoryQueryResponse>
    {
        private readonly IInventoryReadRepository _inventoryReadRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public GetInventoryQueryHandler(IInventoryReadRepository inventoryReadRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _inventoryReadRepository = inventoryReadRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<GetInventoryQueryResponse> Handle(GetInventoryQueryRequest request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.Table
                .Where(s => s.Id == request.Id)
                .ProjectTo<InventoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

            return inventory == null ?
                new GetInventoryQueryResponse().Error(_localizationService.GetLocalizedString("InventoryNotFound")) :
                new GetInventoryQueryResponse().Success(inventory);
        }
    }
}