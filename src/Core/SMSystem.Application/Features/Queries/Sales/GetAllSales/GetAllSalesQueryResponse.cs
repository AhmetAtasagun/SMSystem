using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Application.Features.Queries.Sales.GetAllSales
{
    public class GetAllSalesQueryResponse : HandleDataPagedResult<GetAllSalesQueryResponse, List<SaleDto>>
    {
    }
}