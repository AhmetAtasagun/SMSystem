using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.InventoryRepos;

namespace SMSystem.Application.Features.Commands.Inventories.UpdateInventory
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommandRequest, UpdateInventoryCommandResponse>
    {
        private readonly IInventoryReadRepository _inventoryReadRepository;
        private readonly IInventoryWriteRepository _inventoryWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UpdateInventoryCommandHandler(IInventoryReadRepository inventoryReadRepository, IInventoryWriteRepository inventoryWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _inventoryReadRepository = inventoryReadRepository;
            _inventoryWriteRepository = inventoryWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<UpdateInventoryCommandResponse> Handle(UpdateInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (inventory == null)
                return new UpdateInventoryCommandResponse().Error(_localizationService.GetLocalizedString("InventoryNotFound"));

            inventory = _mapper.Map(request, inventory);

            // TODO : ProcessStatus belirtilecek
            var status = _inventoryWriteRepository.Update(inventory);
            await _inventoryWriteRepository.SaveAsync(cancellationToken);

            return status ?
                new UpdateInventoryCommandResponse().Success(_localizationService.GetLocalizedString("InventoryUpdated")) :
                new UpdateInventoryCommandResponse().Error(_localizationService.GetLocalizedString("InventoryUpdateError"));
        }
    }
}