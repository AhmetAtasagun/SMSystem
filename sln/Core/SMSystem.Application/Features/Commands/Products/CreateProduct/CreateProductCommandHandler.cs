using AutoMapper;
using MediatR;
using SMSystem.Application.Extensions.Localization;
using SMSystem.Application.Repositories.ProductRepos;
using SMSystem.Domain.Entities;

namespace SMSystem.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper, ILocalizationService localizationService)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var result = await _productWriteRepository.AddAsync(product, cancellationToken);
            await _productWriteRepository.SaveAsync(cancellationToken);

            if (request.LocalizedNames != null && request.LocalizedNames.Count > 0)
            {
                await _localizationService.AddLocalizeStringAsync($"Product_{product.Id}_Name", request.LocalizedNames);
            }

            if (request.LocalizedDescriptions != null && request.LocalizedDescriptions.Count > 0)
            {
                await _localizationService.AddLocalizeStringAsync($"Product_{product.Id}_Description", request.LocalizedDescriptions);
            }

            return result ?
                new CreateProductCommandResponse().Success(product.Id, _localizationService.GetLocalizedString("ProductCreated")) :
                new CreateProductCommandResponse().Error(_localizationService.GetLocalizedString("ProductCreateError"));
        }
    }
}