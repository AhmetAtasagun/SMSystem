using Newtonsoft.Json;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<HandleResult> CreateCategoryAsync(CategoryDto category);
        Task<HandleResult> UpdateCategoryAsync(CategoryDto category);
        Task<HandleResult> DeleteCategoryAsync(int id);
    }

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
            var response = await _apiService.GetAsync<dynamic>("categories", _authService.GetToken());
            if (response == null) return new List<CategoryDto>();

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<List<CategoryDto>>>(responseStr);

            return result?.Data ?? new List<CategoryDto>();
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var response = await _apiService.GetAsync<dynamic>($"categories/{id}", _authService.GetToken());
            if (response == null) return null;

            var responseStr = JsonConvert.SerializeObject(response);
            var result = JsonConvert.DeserializeObject<HandleDataResult<CategoryDto>>(responseStr);

            return result?.Data;
        }

        public async Task<HandleResult> CreateCategoryAsync(CategoryDto category)
        {
            var response = await _apiService.PostAsync<dynamic>("categories", category, _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }

        public async Task<HandleResult> UpdateCategoryAsync(CategoryDto category)
        {
            var response = await _apiService.PutAsync<dynamic>($"categories/{category.Id}", category, _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }

        public async Task<HandleResult> DeleteCategoryAsync(int id)
        {
            var response = await _apiService.DeleteAsync<dynamic>($"categories/{id}", _authService.GetToken());
            if (response == null) return new HandleResult { IsSuccess = false, Message = "API connection error" };

            var responseStr = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<HandleResult>(responseStr) ?? new HandleResult { IsSuccess = false, Message = "Failed to parse response" };
        }
    }
}