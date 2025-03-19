using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Products.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, GetProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public GetProductQueryHandler(IProductReadRepository productReadRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<GetProductQueryResponse> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.Table
                .Where(p => p.Id == request.Id)
                .ProjectTo<ProductWithInventoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return product == null ?
                new GetProductQueryResponse().Error(_localizationService.GetLocalizedString("ProductNotFound")) :
                new GetProductQueryResponse().Success(product);
        }
    }
}
