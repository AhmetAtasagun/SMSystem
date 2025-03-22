using SMSystem.Desktop.Models;
using SMSystem.Domain.Dtos;

namespace SMSystem.Desktop.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ResultData<int>> CreateProductAsync(ProductDto product, string imagePath = null);
        Task<Result> UpdateProductAsync(ProductDto product, string imagePath = null);
        Task<Result> DeleteProductAsync(int id);
    }
}