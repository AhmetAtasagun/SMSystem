using AutoMapper;
using MediatR;
using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Features.Commands.Sales.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommandRequest, CreateSaleCommandResponse>
    {
        private readonly ISaleWriteRepository _saleWriteRepository;
        private readonly IMapper _mapper;

        public CreateSaleCommandHandler(ISaleWriteRepository saleWriteRepository, IMapper mapper)
        {
            _saleWriteRepository = saleWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleCommandResponse> Handle(CreateSaleCommandRequest request, CancellationToken cancellationToken)
        {
            var sale = _mapper.Map<CreateSaleCommandRequest, Sale>(request);
            var status = await _saleWriteRepository.AddAsync(sale);

            // TODO : Satış kuralları işlenecek.

            return new CreateSaleCommandResponse().Success();
        }
    }
}
