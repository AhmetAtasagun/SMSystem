using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Queries.Sales.ExportSalesToExcel
{
    public class ExportSalesToExcelQueryResponse : HandleResult<ExportSalesToExcelQueryResponse>
    {
        public byte[] FileContents { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; } = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    }
}