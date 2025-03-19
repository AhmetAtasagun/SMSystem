using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Categories.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, GetCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public GetCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<GetCategoryQueryResponse> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetAll()
                .Include(c => c.Parent)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return category == null ?
                new GetCategoryQueryResponse().Error(_localizationService.GetLocalizedString("CategoryNotFound")) :
                new GetCategoryQueryResponse().Success(category);
        }
    }
}