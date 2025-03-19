using Newtonsoft.Json;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Desktop.Services
{
    public interface IInventoryService
    {
        Task<List<InventoryDto>> GetAllInventoriesAsync();
        Task<InventoryDto?> GetInventoryByIdAsync(int id);
        Task<List<InventoryDto>> GetInventoriesByProductIdAsync(int productId);
        Task<HandleResult> CreateInventoryAsync(InventoryDto inventory);
        Task<HandleResult> UpdateInventoryAsync(InventoryDto inventory);
        Task<HandleResult> DeleteInventoryAsync(int id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public InventoryService(IApiService apiService, IAuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        public async Task<List<InventoryDto>> GetAllInventoriesAsync()
        {
            var response = await _apiService.GetAsync<dynamic>("inventories", _authService.GetToken());
            if (response == null) return new List<InventoryDto>();

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<List<InventoryDto>>>(responseStr);

            return result?.Data ?? new List<InventoryDto>();
        }

        public async Task<InventoryDto?> GetInventoryByIdAsync(int id)
        {
            var response = await _apiService.GetAsync<dynamic>($"inventories/{id}", _authService.GetToken());
            if (response == null) return null;

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<InventoryDto>>(responseStr);

            return result?.Data;
        }

        public async Task<List<InventoryDto>> GetInventoriesByProductIdAsync(int productId)
        {
            var response = await _apiService.GetAsync<dynamic>($"inventories/product/{productId}", _authService.GetToken());
            if (response == null) return new List<InventoryDto>();

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<List<InventoryDto>>>(responseStr);

            return result?.Data ?? new List<InventoryDto>();
        }

        public async Task<HandleResult> CreateInventoryAsync(InventoryDto inventory)
        {
            var response = await _apiService.PostAsync<dynamic>("inventories", inventory, _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }

        public async Task<HandleResult> UpdateInventoryAsync(InventoryDto inventory)
        {
            var response = await _apiService.PutAsync<dynamic>($"inventories/{inventory.Id}", inventory, _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }

        public async Task<HandleResult> DeleteInventoryAsync(int id)
        {
            var response = await _apiService.DeleteAsync<dynamic>($"inventories/{id}", _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }
    }
}