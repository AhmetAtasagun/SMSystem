using SMSystem.Desktop.Models;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
        Task<ResultData<int>> CreateCategoryAsync(CategoryDto category);
        Task<Result> UpdateCategoryAsync(CategoryDto category);
        Task<Result> DeleteCategoryAsync(int id);
    }
}