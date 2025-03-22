using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMSystem.Application.Features.Commands.Sales.CreateSale;
using SMSystem.Application.Features.Commands.Sales.DeleteSale;
using SMSystem.Application.Features.Commands.Sales.UpdateSale;
using SMSystem.Application.Features.Queries.Sales.ExportSalesToExcel;
using SMSystem.Application.Features.Queries.Sales.GetAllSales;
using SMSystem.Application.Features.Queries.Sales.GetSale;
using SMSystem.Application.Services.Auth;

namespace SMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public SalesController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? productId, [FromQuery] int? staffId, 
            [FromQuery] string? saleSearch, [FromQuery] int pageNo = 1, [FromQuery] int pageCount = 10)
        {
            var query = new GetAllSalesQueryRequest
            {
                ProductId = productId,
                StaffId = staffId,
                SaleSearch = saleSearch,
                PageNo = pageNo,
                PageCount = pageCount
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetSaleQueryRequest { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleCommandRequest request)
        {
            // Set the StaffId to the current user's ID
            request.StaffId = _currentUserService.GetCurrentUserId();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSaleCommandRequest request)
        {
            request.Id = id;
            // Set the StaffId to the current user's ID
            request.StaffId = _currentUserService.GetCurrentUserId();
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeleteSaleCommandRequest { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Endpoint for exporting sales data to Excel
        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportToExcel(
            [FromQuery] int? productId, 
            [FromQuery] int? staffId, 
            [FromQuery] string? saleSearch, 
            [FromQuery] DateTime? startDate, 
            [FromQuery] DateTime? endDate,
            [FromQuery] string fileName = "Sales_Export.xlsx")
        {
            var request = new ExportSalesToExcelQueryRequest
            {
                ProductId = productId,
                StaffId = staffId,
                SaleSearch = saleSearch,
                StartDate = startDate,
                EndDate = endDate,
                FileName = fileName
            };

            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return File(result.FileContents, result.ContentType, result.FileName);
        }
    }
}