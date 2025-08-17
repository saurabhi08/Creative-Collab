using MindAndMarket.DTOs;

namespace MindAndMarket.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetProductsByDepartmentAsync(int departmentId);
        Task<IEnumerable<ProductDto>> GetProductsByAisleAsync(int aisleId);
    }
} 