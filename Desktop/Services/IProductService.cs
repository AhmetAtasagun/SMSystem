using Newtonsoft.Json;
using SMSystem.Domain.Dtos;
using SMSystem.Domain.Models;

namespace SMSystem.Desktop.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<HandleResult> CreateProductAsync(ProductDto product);
        Task<HandleResult> UpdateProductAsync(ProductDto product);
        Task<HandleResult> DeleteProductAsync(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public ProductService(IApiService apiService, IAuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var response = await _apiService.GetAsync<dynamic>("products", _authService.GetToken());
            if (response == null) return new List<ProductDto>();

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<List<ProductDto>>>(responseStr);

            return result?.Data ?? new List<ProductDto>();
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var response = await _apiService.GetAsync<dynamic>($"products/{id}", _authService.GetToken());
            if (response == null) return null;

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<ProductDto>>(responseStr);

            return result?.Data;
        }

        public async Task<HandleResult> CreateProductAsync(ProductDto product)
        {
            var response = await _apiService.PostAsync<dynamic>("products", product, _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }

        public async Task<HandleResult> UpdateProductAsync(ProductDto product)
        {
            var response = await _apiService.PutAsync<dynamic>($"products/{product.Id}", product, _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }

        public async Task<HandleResult> DeleteProductAsync(int id)
        {
            var response = await _apiService.DeleteAsync<dynamic>($"products/{id}", _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }
    }
}