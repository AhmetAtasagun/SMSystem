using SMSystem.Desktop.Models;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<List<InventoryDto>> GetAllInventoriesAsync();
        Task<InventoryDto?> GetInventoryByIdAsync(int id);
        Task<List<InventoryDto>> GetInventoriesByProductIdAsync(int productId);
        Task<Result> CreateInventoryAsync(InventoryDto inventory);
        Task<Result> UpdateInventoryAsync(InventoryDto inventory);
        Task<Result> DeleteInventoryAsync(int id);
    }
}