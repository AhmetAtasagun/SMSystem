using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMSystem.Application.Features.Commands.Products.CreateProduct;
using SMSystem.Application.Features.Commands.Products.UpdateProduct;
using SMSystem.Application.Features.Queries.Products.GetAllProducts;
using SMSystem.Application.Services.Storage;
using SMSystem.WebAPI.ViewModel;

namespace SMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileService _fileService;

        public ProductsController(IMediator mediator, IFileService fileService)
        {
            _mediator = mediator;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductFormModel model)
        {
            var request = new CreateProductCommandRequest
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                LocalizedNames = model.LocalizedNames,
                LocalizedDescriptions = model.LocalizedDescriptions
            };

            // Handle file upload if provided
            if (model.ImageFile != null)
            {
                request.Image = await _fileService.UploadAsync(model.ImageFile, "products");
            }

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateProductFormModel model)
        {
            var request = new UpdateProductCommandRequest
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = model.CategoryId,
                LocalizedNames = model.LocalizedNames,
                LocalizedDescriptions = model.LocalizedDescriptions
            };

            if (model.ImageFile != null)
            {
                request.Image = await _fileService.UploadAsync(model.ImageFile, "products");
            }
            else
            {
                request.Image = model.Image;
            }

            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}