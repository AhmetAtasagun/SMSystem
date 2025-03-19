using AutoMapper;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Mapping.Localizations
{
    public class CategoryLocalization : IMappingAction<Category, CategoryDto>
    {
        private readonly ILocalizationService _localizationService;

        public CategoryLocalization(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public void Process(Category source, CategoryDto destination, ResolutionContext context)
        {
            // Get localized name for the category
            string localizedName = _localizationService.GetLocalizedString($"Category_{source.Id}_Name");
            destination.Name = localizedName;

            // Get localized parent name if parent exists
            if (source.Parent != null)
            {
                string localizedParentName = _localizationService.GetLocalizedString($"Category_{source.Parent.Id}_Name");
                destination.ParentName = localizedParentName;
            }
        }
    }
}