using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Extensions;
using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Domain.Dtos;

namespace SMSystem.Application.Features.Queries.Sales.GetAllSales
{
    public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQueryRequest, GetAllSalesQueryResponse>
    {
        private readonly ISaleReadRepository _saleReadRepository;
        private readonly IMapper _mapper;

        public GetAllSalesQueryHandler(ISaleReadRepository saleReadRepository, IMapper mapper)
        {
            _saleReadRepository = saleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllSalesQueryResponse> Handle(GetAllSalesQueryRequest request, CancellationToken cancellationToken)
        {
            var saleQuery = _saleReadRepository.GetAll();

            if (request.ProductId.HasValue)
            {
                saleQuery = saleQuery.Where(s => s.ProductId == request.ProductId.Value);
            }

            if (request.StaffId.HasValue)
            {
                saleQuery = saleQuery.Where(s => s.StaffId == request.StaffId.Value);
            }

            if (!string.IsNullOrEmpty(request.SaleSearch))
            {
                saleQuery = saleQuery.Where(s => s.Product.Name.Contains(request.SaleSearch));
            }

            var totalSaleCount = await saleQuery.CountAsync(cancellationToken);

            var sales = await saleQuery
                .Paginate(request.PageNo, request.PageCount)
                .ProjectTo<SaleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetAllSalesQueryResponse().Success(sales, totalSaleCount);
        }
    }
}