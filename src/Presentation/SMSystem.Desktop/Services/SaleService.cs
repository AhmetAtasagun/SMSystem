using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services
{
    public class SaleService : ISaleService
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public SaleService(IApiService apiService, IAuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        public async Task<List<SaleDto>> GetAllAsync(int? productId = null, string searchText = null, int pageNo = 1, int pageCount = 100)
        {
            try
            {
                string queryString = $"?pageNo={pageNo}&pageCount={pageCount}";

                if (productId.HasValue)
                    queryString += $"&productId={productId}";

                if (!string.IsNullOrEmpty(searchText))
                    queryString += $"&saleSearch={searchText}";

                var response = await _apiService.GetAsync<ResultData<List<SaleDto>>>($"sales{queryString}");
                if (response == null)
                    return new List<SaleDto>();

                return response.Data;
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Satış verileri alınırken hata oluştu: {ex.Message}");
                return new List<SaleDto>();
            }
        }

        public async Task<SaleDto> GetByIdAsync(int id)
        {
            try
            {
                var response = await _apiService.GetAsync<ResultData<SaleDto>>($"sales/{id}");
                if (response == null)
                    return null;

                return response.Data;
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Satış verisi alınırken hata oluştu: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateAsync(int productId, decimal price, int quantity)
        {
            try
            {
                var saleModel = new
                {
                    ProductId = productId,
                    Price = price,
                    Quantity = quantity
                    // StaffId is now handled by the API automatically
                };

                var response = await _apiService.PostAsync<Result>("sales", saleModel);
                if (response == null)
                    return false;

                if (response.IsSuccess)
                {
                    MessageBoxShow.Success("Satış başarıyla eklendi.");
                    return true;
                }
                else
                {
                    MessageBoxShow.Error(response.Message ?? "Satış eklenirken bir hata oluştu.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Satış eklenirken hata oluştu: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, int productId, decimal price, int quantity)
        {
            try
            {
                var saleModel = new
                {
                    ProductId = productId,
                    Price = price,
                    Quantity = quantity
                    // StaffId is now handled by the API automatically
                };

                var response = await _apiService.PutAsync<Result>($"sales/{id}", saleModel);
                if (response == null)
                    return false;

                if (response.IsSuccess == true)
                {
                    MessageBoxShow.Success("Satış başarıyla güncellendi.");
                    return true;
                }
                else
                {
                    MessageBoxShow.Error(response.Message ?? "Satış güncellenirken bir hata oluştu.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxShow.Error($"Satış güncellenirken hata oluştu: {ex.Message}");
                return false;
            }
        }
    }
}