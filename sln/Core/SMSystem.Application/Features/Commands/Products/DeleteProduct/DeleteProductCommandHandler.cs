using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.ProductRepos;

namespace SMSystem.Application.Features.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ILocalizationService _localizationService;

        public DeleteProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILocalizationService localizationService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _localizationService = localizationService;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
                return new DeleteProductCommandResponse().Error(_localizationService.GetLocalizedString("ProductNotFound"));

            var result = _productWriteRepository.Delete(product, cancellationToken);
            await _productWriteRepository.SaveAsync(cancellationToken);

            return result ?
                new DeleteProductCommandResponse().Success(_localizationService.GetLocalizedString("ProductDeleted")) :
                new DeleteProductCommandResponse().Error(_localizationService.GetLocalizedString("ProductDeleteError"));
        }
    }
}