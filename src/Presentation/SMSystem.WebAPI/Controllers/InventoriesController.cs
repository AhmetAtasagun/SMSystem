using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMSystem.Application.Features.Commands.Inventories.CreateInventory;
using SMSystem.Application.Features.Commands.Inventories.DeleteInventory;
using SMSystem.Application.Features.Commands.Inventories.UpdateInventory;
using SMSystem.Application.Features.Queries.Inventories.GetAllInventories;
using SMSystem.Application.Features.Queries.Inventories.GetInventory;

namespace SMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllInventoriesQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new GetInventoryQueryRequest { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInventoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateInventoryCommandRequest request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteInventoryCommandRequest { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("by-product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var request = new GetAllInventoriesQueryRequest { ProductId = productId };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("by-warehouse")]
        public async Task<IActionResult> GetByWarehouse([FromQuery] string warehouseName)
        {
            var request = new GetAllInventoriesQueryRequest { WarehouseSearch = warehouseName };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}