using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.ProductRepos;

namespace SMSystem.Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return new UpdateProductCommandResponse().Error(_localizationService.GetLocalizedString("ProductNotFound"));
            }

            product = _mapper.Map(request, product);

            var result = _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync(cancellationToken);

            if (request.LocalizedNames != null && request.LocalizedNames.Count > 0)
            {
                await _localizationService.AddLocalizeStringAsync($"Product_{product.Id}_Name", request.LocalizedNames);
            }

            if (request.LocalizedDescriptions != null && request.LocalizedDescriptions.Count > 0)
            {
                var descKeyValuePairs = request.LocalizedDescriptions
                    .Select(ld => new KeyValuePair<string, string>(ld.CultureCode, ld.Value))
                    .ToArray();

                await _localizationService.AddLocalizeStringAsync($"Product_{product.Id}_Description", descKeyValuePairs);
            }

            return result ?
                new UpdateProductCommandResponse().Success(_localizationService.GetLocalizedString("ProductUpdated")) :
                new UpdateProductCommandResponse().Error(_localizationService.GetLocalizedString("ProductUpdateError"));
        }
    }
}