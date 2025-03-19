using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.CategoryRepos;

namespace SMSystem.Application.Features.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category == null)
            {
                return new UpdateCategoryCommandResponse().Error(_localizationService.GetLocalizedString("CategoryNotFound"));
            }

            category = _mapper.Map(request, category);

            var result = _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveAsync(cancellationToken);

            if (request.LocalizedNames != null && request.LocalizedNames.Count > 0)
            {
                await _localizationService.AddLocalizeStringAsync($"Category_{category.Id}_Name", request.LocalizedNames);
            }

            return result ?
                new UpdateCategoryCommandResponse().Success(_localizationService.GetLocalizedString("CategoryUpdated")) :
                new UpdateCategoryCommandResponse().Error(_localizationService.GetLocalizedString("CategoryUpdateError"));
        }
    }
}