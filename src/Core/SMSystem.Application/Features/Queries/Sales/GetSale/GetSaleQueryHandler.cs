using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Sales.GetSale
{
    public class GetSaleQueryHandler : IRequestHandler<GetSaleQueryRequest, GetSaleQueryResponse>
    {
        private readonly ISaleReadRepository _saleReadRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public GetSaleQueryHandler(ISaleReadRepository saleReadRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _saleReadRepository = saleReadRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<GetSaleQueryResponse> Handle(GetSaleQueryRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleReadRepository.Table
                .Where(s => s.Id == request.Id)
            .ProjectTo<SaleDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

            return sale == null ?
                new GetSaleQueryResponse().Error(_localizationService.GetLocalizedString("SaleNotFound")) :
                new GetSaleQueryResponse().Success(sale);
        }
    }
}