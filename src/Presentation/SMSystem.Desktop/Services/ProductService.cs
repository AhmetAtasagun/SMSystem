using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;
using System.Text.Json;

namespace SMSystem.Desktop.Services
{
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
            var response = await _apiService.GetAsync<ResultData<List<ProductDto>>>("products", _authService.GetToken());
            if (response == null)
                return [];

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? [];
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var response = await _apiService.GetAsync<ResultData<ProductDto>>($"products/{id}", _authService.GetToken());
            if (response == null)
                return new ProductDto();

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? new ProductDto();
        }

        public async Task<ResultData<int>> CreateProductAsync(ProductDto product, string imagePath = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "Name", product.Name },
                { "Description", product.Description },
                { "Price", product.Price.ToString() },
                { "CategoryId", product.CategoryId.ToString() }
            };

            if (!string.IsNullOrEmpty(imagePath))
            {
                var response = await _apiService.PostFormDataAsync<ResultData<int>>("products", formData, imagePath, "ImageFile", _authService.GetToken());
                if (response == null)
                    return new ResultData<int>().Error("API connection error");

                return response;
            }
            else
            {
                var response = await _apiService.PostAsync<ResultData<int>>("products", product, _authService.GetToken());
                if (response == null)
                    return new ResultData<int>().Error("API connection error");

                return response;
            }
        }

        public async Task<Result> UpdateProductAsync(ProductDto product, string imagePath = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "Name", product.Name },
                { "Description", product.Description },
                { "Price", product.Price.ToString() },
                { "CategoryId", product.CategoryId.ToString() },
                { "Image", product.Image ?? string.Empty }
            };

            if (!string.IsNullOrEmpty(imagePath))
            {
                var response = await _apiService.PutFormDataAsync<Result>($"products/{product.Id}", formData, imagePath, "ImageFile", _authService.GetToken());
                if (response == null)
                    return new Result().Error("API connection error");

                return response;
            }
            else
            {
                var response = await _apiService.PutAsync<Result>($"products/{product.Id}", product, _authService.GetToken());
                if (response == null)
                    return new Result().Error("API connection error");

                return response;
            }
        }

        public async Task<Result> DeleteProductAsync(int id)
        {
            var response = await _apiService.DeleteAsync<Result>($"products/{id}", _authService.GetToken());
            if (response == null)
                return new Result().Error("API connection error");

            return response;
        }
    }
}