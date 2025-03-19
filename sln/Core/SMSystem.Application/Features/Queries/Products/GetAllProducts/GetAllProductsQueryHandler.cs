using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions;
using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productQuery = _productReadRepository.GetAll();
            if (request.CategorIds.Any())
            {
                productQuery = productQuery.Where(p => request.CategorIds.Contains(p.CategoryId));
            }

            if (!string.IsNullOrEmpty(request.ProductSearch))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(request.ProductSearch));
            }

            var totalProductCount = await productQuery.CountAsync(cancellationToken);
            var products = await productQuery
                .Paginate(request.PageNo, request.PageCount)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetAllProductsQueryResponse().Success(products, totalProductCount);
        }
    }
}
