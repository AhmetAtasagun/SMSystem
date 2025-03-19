using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.InventoryRepos;

namespace SMSystem.Application.Features.Commands.Inventories.DeleteInventory
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommandRequest, DeleteInventoryCommandResponse>
    {
        private readonly IInventoryReadRepository _inventoryReadRepository;
        private readonly IInventoryWriteRepository _inventoryWriteRepository;
        private readonly ILocalizationService _localizationService;

        public DeleteInventoryCommandHandler(IInventoryReadRepository inventoryReadRepository, IInventoryWriteRepository inventoryWriteRepository, ILocalizationService localizationService)
        {
            _inventoryReadRepository = inventoryReadRepository;
            _inventoryWriteRepository = inventoryWriteRepository;
            _localizationService = localizationService;
        }

        public async Task<DeleteInventoryCommandResponse> Handle(DeleteInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (inventory == null)
                return new DeleteInventoryCommandResponse().Error(_localizationService.GetLocalizedString("InventoryNotFound"));

            var status = _inventoryWriteRepository.Delete(inventory, cancellationToken);
            await _inventoryWriteRepository.SaveAsync(cancellationToken);

            return status ?
                new DeleteInventoryCommandResponse().Success(_localizationService.GetLocalizedString("InventoryDeleted")) :
                new DeleteInventoryCommandResponse().Error(_localizationService.GetLocalizedString("InventoryDeleteError"));
        }
    }
}