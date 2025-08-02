using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly MindAndMarketContext _context;

        public ProductService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Aisle)
                .Include(p => p.Department)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    SKU = p.SKU,
                    IsOrganic = p.IsOrganic,
                    IsGlutenFree = p.IsGlutenFree,
                    AisleName = p.Aisle.Name,
                    DepartmentName = p.Department.Name
                })
                .ToListAsync();
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Aisle)
                .Include(p => p.Department)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                SKU = product.SKU,
                IsOrganic = product.IsOrganic,
                IsGlutenFree = product.IsGlutenFree,
                AisleName = product.Aisle.Name,
                DepartmentName = product.Department.Name
            };
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                StockQuantity = createProductDto.StockQuantity,
                SKU = createProductDto.SKU,
                IsOrganic = createProductDto.IsOrganic,
                IsGlutenFree = createProductDto.IsGlutenFree,
                AisleId = createProductDto.AisleId,
                DepartmentId = createProductDto.DepartmentId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return await GetProductByIdAsync(product.Id) ?? new ProductDto();
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = updateProductDto.Name;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.StockQuantity = updateProductDto.StockQuantity;
            product.SKU = updateProductDto.SKU;
            product.IsOrganic = updateProductDto.IsOrganic;
            product.IsGlutenFree = updateProductDto.IsGlutenFree;
            product.AisleId = updateProductDto.AisleId;
            product.DepartmentId = updateProductDto.DepartmentId;

            await _context.SaveChangesAsync();

            return await GetProductByIdAsync(id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 