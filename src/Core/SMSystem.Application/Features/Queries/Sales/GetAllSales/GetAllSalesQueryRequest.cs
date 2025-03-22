using MediatR;

namespace SMSystem.Application.Features.Queries.Sales.GetAllSales
{
    public class GetAllSalesQueryRequest : IRequest<GetAllSalesQueryResponse>
    {
        public int? ProductId { get; set; }
        public int? StaffId { get; set; }
        public string SaleSearch { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageCount { get; set; } = 10;
    }
}