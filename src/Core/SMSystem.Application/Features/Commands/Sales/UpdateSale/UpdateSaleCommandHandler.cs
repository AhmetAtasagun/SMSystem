using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.SaleRepos;

namespace SMSystem.Application.Features.Commands.Sales.UpdateSale
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommandRequest, UpdateSaleCommandResponse>
    {
        private readonly ISaleReadRepository _saleReadRepository;
        private readonly ISaleWriteRepository _saleWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UpdateSaleCommandHandler(ISaleReadRepository saleReadRepository, ISaleWriteRepository saleWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _saleReadRepository = saleReadRepository;
            _saleWriteRepository = saleWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<UpdateSaleCommandResponse> Handle(UpdateSaleCommandRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (sale == null)
                return new UpdateSaleCommandResponse().Error(_localizationService.GetLocalizedString("SaleNotFound"));

            sale = _mapper.Map(request, sale);

            var status = _saleWriteRepository.Update(sale);
            await _saleWriteRepository.SaveAsync(cancellationToken);

            return status ?
                new UpdateSaleCommandResponse().Success(_localizationService.GetLocalizedString("SaleUpdated")) :
                new UpdateSaleCommandResponse().Error(_localizationService.GetLocalizedString("SaleUpdateError"));
        }
    }
}