using SMSystem.Desktop.Models;
using SMSystem.Desktop.Services.Interfaces;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApiService _apiService;
        private readonly IAuthService _authService;

        public CategoryService(IApiService apiService, IAuthService authService)
        {
            _apiService = apiService;
            _authService = authService;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var response = await _apiService.GetAsync<ResultData<List<CategoryDto>>>("categories", _authService.GetToken());
            if (response == null)
                return [];

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? [];
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var response = await _apiService.GetAsync<ResultData<CategoryDto>>($"categories/{id}", _authService.GetToken());
            if (response == null)
                return new CategoryDto();

            if (!response.IsSuccess)
                MessageBoxShow.Error(response.Message);

            return response?.Data ?? new CategoryDto();
        }

        public async Task<ResultData<int>> CreateCategoryAsync(CategoryDto category)
        {
            var response = await _apiService.PostAsync<ResultData<int>>("categories", category, _authService.GetToken());
            if (response == null)
                return new ResultData<int>().Error("API connection error");

            return response;
        }

        public async Task<Result> UpdateCategoryAsync(CategoryDto category)
        {
            var response = await _apiService.PutAsync<Result>($"categories/{category.Id}", category, _authService.GetToken());
            if (response == null)
                return new Result().Error("API connection error");

            return response;
        }

        public async Task<Result> DeleteCategoryAsync(int id)
        {
            var response = await _apiService.DeleteAsync<Result>($"categories/{id}", _authService.GetToken());
            if (response == null)
                return new Result().Error("API connection error");

            return response;
        }
    }
}