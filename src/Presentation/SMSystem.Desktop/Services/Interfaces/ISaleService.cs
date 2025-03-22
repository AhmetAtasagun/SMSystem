using SMSystem.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMSystem.Desktop.Services.Interfaces
{
    public interface ISaleService
    {
        Task<List<SaleDto>> GetAllAsync(int? productId = null, string searchText = null, int pageNo = 1, int pageCount = 100);
        Task<SaleDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(int productId, decimal price, int quantity);
        Task<bool> UpdateAsync(int id, int productId, decimal price, int quantity);
    }
}