using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.SaleRepos;

namespace SMSystem.Application.Features.Commands.Sales.DeleteSale
{
    public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommandRequest, DeleteSaleCommandResponse>
    {
        private readonly ISaleReadRepository _saleReadRepository;
        private readonly ISaleWriteRepository _saleWriteRepository;
        private readonly ILocalizationService _localizationService;

        public DeleteSaleCommandHandler(ISaleReadRepository saleReadRepository, ISaleWriteRepository saleWriteRepository, ILocalizationService localizationService)
        {
            _saleReadRepository = saleReadRepository;
            _saleWriteRepository = saleWriteRepository;
            _localizationService = localizationService;
        }

        public async Task<DeleteSaleCommandResponse> Handle(DeleteSaleCommandRequest request, CancellationToken cancellationToken)
        {
            var sale = await _saleReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (sale == null)
                return new DeleteSaleCommandResponse().Error(_localizationService.GetLocalizedString("SaleNotFound"));

            var status = _saleWriteRepository.Delete(sale, cancellationToken);
            await _saleWriteRepository.SaveAsync(cancellationToken);

            return status ?
                new DeleteSaleCommandResponse().Success(_localizationService.GetLocalizedString("SaleDeleted")) :
                new DeleteSaleCommandResponse().Error(_localizationService.GetLocalizedString("SaleDeleteError"));
        }
    }
}