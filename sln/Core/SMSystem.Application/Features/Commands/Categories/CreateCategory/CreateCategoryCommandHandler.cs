using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Features.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);

            var result = await _categoryWriteRepository.AddAsync(category, cancellationToken);
            await _categoryWriteRepository.SaveAsync(cancellationToken);

            // Save localized names
            if (request.LocalizedNames != null && request.LocalizedNames.Count > 0)
            {
                await _localizationService.AddLocalizeStringAsync($"Category_{category.Id}_Name", request.LocalizedNames);
            }

            return result ?
                new CreateCategoryCommandResponse().Success(category.Id, _localizationService.GetLocalizedString("CategoryCreated")) :
                new CreateCategoryCommandResponse().Error(_localizationService.GetLocalizedString("CategoryCreateError"));
        }
    }
}