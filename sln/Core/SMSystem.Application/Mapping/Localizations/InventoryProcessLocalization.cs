using AutoMapper;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Mapping.Localizations
{
    public class InventoryProcessLocalization : IMappingAction<Inventory, InventoryDto>
    {
        private readonly ILocalizationService _localizationService;

        public InventoryProcessLocalization(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public void Process(Inventory source, InventoryDto destination, ResolutionContext context)
        {
            destination.Process = _localizationService.GetLocalizedString(Enum.GetName(source.Process));
        }
    }
}
