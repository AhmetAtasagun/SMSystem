using AutoMapper;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Mapping.Localizations
{
    public class ProductLocalization : IMappingAction<Product, ProductDto>
    {
        private readonly ILocalizationService _localizationService;

        public ProductLocalization(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public void Process(Product source, ProductDto destination, ResolutionContext context)
        {
            // Get localized name for the product
            string localizedName = _localizationService.GetLocalizedString($"Product_{source.Id}_Name");
            if (!string.IsNullOrEmpty(localizedName))
            {
                destination.Name = localizedName;
            }

            // Get localized description if available
            string localizedDescription = _localizationService.GetLocalizedString($"Product_{source.Id}_Description");
            if (!string.IsNullOrEmpty(localizedDescription))
            {
                destination.Description = localizedDescription;
            }

            // Get localized category name if category exists
            if (source.Category != null)
            {
                string localizedCategoryName = _localizationService.GetLocalizedString($"Category_{source.Category.Id}_Name");
                if (!string.IsNullOrEmpty(localizedCategoryName))
                {
                    destination.CategoryName = localizedCategoryName;
                }
            }
        }
    }
}