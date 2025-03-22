using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClosedXML.Excel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSystem.Application.Repositories.SaleRepos;
using SMSystem.Domain.Dtos;
using System.IO;

namespace SMSystem.Application.Features.Queries.Sales.ExportSalesToExcel
{
    public class ExportSalesToExcelQueryHandler : IRequestHandler<ExportSalesToExcelQueryRequest, ExportSalesToExcelQueryResponse>
    {
        private readonly ISaleReadRepository _saleReadRepository;
        private readonly IMapper _mapper;

        public ExportSalesToExcelQueryHandler(ISaleReadRepository saleReadRepository, IMapper mapper)
        {
            _saleReadRepository = saleReadRepository;
            _mapper = mapper;
        }

        public async Task<ExportSalesToExcelQueryResponse> Handle(ExportSalesToExcelQueryRequest request, CancellationToken cancellationToken)
        {
            var saleQuery = _saleReadRepository.GetAll();

            // Apply filters
            if (request.ProductId.HasValue)
            {
                saleQuery = saleQuery.Where(s => s.ProductId == request.ProductId.Value);
            }

            if (request.StaffId.HasValue)
            {
                saleQuery = saleQuery.Where(s => s.StaffId == request.StaffId.Value);
            }

            if (!string.IsNullOrEmpty(request.SaleSearch))
            {
                saleQuery = saleQuery.Where(s => s.Product.Name.Contains(request.SaleSearch));
            }

            if (request.StartDate.HasValue)
            {
                saleQuery = saleQuery.Where(s => s.CreatedDate >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                // Add one day to include the end date fully
                var endDatePlusOne = request.EndDate.Value.AddDays(1);
                saleQuery = saleQuery.Where(s => s.CreatedDate < endDatePlusOne);
            }

            // Get all sales data without pagination
            var sales = await saleQuery
                .ProjectTo<SaleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            // Generate Excel file
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sales");

            // Add headers
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Product Name";
            worksheet.Cell(1, 3).Value = "Product Price";
            worksheet.Cell(1, 4).Value = "Quantity";
            worksheet.Cell(1, 5).Value = "Total Price";
            worksheet.Cell(1, 6).Value = "Staff Name";

            // Style the header row
            var headerRow = worksheet.Row(1);
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

            // Add data
            for (int i = 0; i < sales.Count; i++)
            {
                var sale = sales[i];
                int row = i + 2; // Start from row 2 (after header)

                worksheet.Cell(row, 1).Value = sale.Id;
                worksheet.Cell(row, 2).Value = sale.ProductName;
                worksheet.Cell(row, 3).Value = sale.ProductPrice;
                worksheet.Cell(row, 4).Value = sale.Quantity;
                worksheet.Cell(row, 5).Value = sale.Price;
                worksheet.Cell(row, 6).Value = sale.StaffName;
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            // Convert to byte array
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            var response = new ExportSalesToExcelQueryResponse
            {
                FileContents = stream.ToArray(),
                FileName = request.FileName
            };

            return response.Success();
        }
    }
}