using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services
{
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
            var response = await _apiService.GetAsync<ResultData<List<InventoryDto>>>("inventories", _authService.GetToken());
            if (response == null)
                return [];

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? [];
        }

        public async Task<List<InventoryDto>> GetAllInventoriesByWarehouseAsync()
        {
            var response = await _apiService.GetAsync<ResultData<List<InventoryDto>>>("inventories/by-warehouse", _authService.GetToken());
            if (response == null)
                return [];

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? [];
        }

        public async Task<InventoryDto?> GetInventoryByIdAsync(int id)
        {
            var response = await _apiService.GetAsync<ResultData<InventoryDto>>($"inventories/{id}", _authService.GetToken());
            if (response == null)
                return new InventoryDto();

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? new InventoryDto();
        }

        public async Task<List<InventoryDto>> GetInventoriesByProductIdAsync(int productId)
        {
            var response = await _apiService.GetAsync<ResultData<List<InventoryDto>>>($"inventories/product/{productId}", _authService.GetToken());
            if (response == null)
                return [];

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? [];
        }

        public async Task<Result> CreateInventoryAsync(InventoryDto inventory)
        {
            var response = await _apiService.PostAsync<Result>("inventories", inventory, _authService.GetToken());
            if (response == null)
                return new ResultData<int>().Error("API connection error");

            return response;
        }

        public async Task<Result> UpdateInventoryAsync(InventoryDto inventory)
        {
            var response = await _apiService.PutAsync<Result>($"inventories/{inventory.Id}", inventory, _authService.GetToken());
            if (response == null)
                return new Result().Error("API connection error");

            return response;
        }

        public async Task<Result> DeleteInventoryAsync(int id)
        {
            var response = await _apiService.DeleteAsync<Result>($"inventories/{id}", _authService.GetToken());
            if (response == null)
                return new Result().Error("API connection error");

            return response;
        }
    }
}