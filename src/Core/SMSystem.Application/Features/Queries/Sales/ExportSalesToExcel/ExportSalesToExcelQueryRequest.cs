using MediatR;

namespace SMSystem.Application.Features.Queries.Sales.ExportSalesToExcel
{
    public class ExportSalesToExcelQueryRequest : IRequest<ExportSalesToExcelQueryResponse>
    {
        public int? ProductId { get; set; }
        public int? StaffId { get; set; }
        public string? SaleSearch { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FileName { get; set; } = "Sales_Export.xlsx";
    }
}