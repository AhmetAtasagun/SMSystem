using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMSystem.Application.Features.Commands.Categories.CreateCategory;
using SMSystem.Application.Features.Commands.Categories.UpdateCategory;
using SMSystem.Application.Features.Queries.Categories.GetAllCategories;
using SMSystem.Application.Features.Queries.Categories.GetCategory;
using SMSystem.WebAPI.ViewModel;

namespace SMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCategoriesQueryRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryViewModel model)
        {
            var request = new CreateCategoryCommandRequest
            {
                Name = model.Name,
                ParentId = model.ParentId,
                LocalizedNames = model.LocalizedNames
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoryQueryRequest { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryViewModel model)
        {
            var request = new UpdateCategoryCommandRequest
            {
                Id = id,
                Name = model.Name,
                ParentId = model.ParentId,
                LocalizedNames = model.LocalizedNames
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}