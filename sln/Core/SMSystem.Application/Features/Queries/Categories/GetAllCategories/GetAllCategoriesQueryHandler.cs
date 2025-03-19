using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories.CategoryRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categoryQuery = _categoryReadRepository.GetAll().Include(c => c.Parent).AsQueryable();

            if (request.ParentId.HasValue)
            {
                categoryQuery = categoryQuery.Where(c => c.ParentId == request.ParentId);
            }

            var categories = await categoryQuery
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetAllCategoriesQueryResponse().Success(categories);
        }
    }
}