using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.InventoryRepos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Features.Commands.Inventories.CreateInventory
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommandRequest, CreateInventoryCommandResponse>
    {
        private readonly IInventoryWriteRepository _inventoryWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CreateInventoryCommandHandler(IInventoryWriteRepository inventoryWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _inventoryWriteRepository = inventoryWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<CreateInventoryCommandResponse> Handle(CreateInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);
            var status = await _inventoryWriteRepository.AddAsync(inventory, cancellationToken);
            await _inventoryWriteRepository.SaveAsync(cancellationToken);

            // TODO : ProcessStatus belirtilecek

            return status ?
                new CreateInventoryCommandResponse().Success(_localizationService.GetLocalizedString("InventoryCreated")) :
                new CreateInventoryCommandResponse().Error(_localizationService.GetLocalizedString("InventoryCreateError"));
        }
    }
}