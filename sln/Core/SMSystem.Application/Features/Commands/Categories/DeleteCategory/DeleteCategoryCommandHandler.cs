using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.CategoryRepos;

namespace SMSystem.Application.Features.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ILocalizationService _localizationService;

        public DeleteCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, ILocalizationService localizationService)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _localizationService = localizationService;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category == null)
            {
                return new DeleteCategoryCommandResponse().Error(_localizationService.GetLocalizedString("CategoryNotFound"));
            }

            var result = _categoryWriteRepository.Delete(category, cancellationToken);
            await _categoryWriteRepository.SaveAsync(cancellationToken);

            return result ?
                new DeleteCategoryCommandResponse().Success(_localizationService.GetLocalizedString("CategoryDeleted")) :
                new DeleteCategoryCommandResponse().Error(_localizationService.GetLocalizedString("CategoryDeleteError"));
        }
    }
}