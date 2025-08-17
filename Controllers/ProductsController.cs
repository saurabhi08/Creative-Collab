using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;
using MindAndMarket.Filters;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves all products with aisle and department information.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Retrieves a single product by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Creates a new product. Admin only.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = await _productService.CreateProductAsync(createProductDto);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        /// <summary>
        /// Updates an existing product by ID. Admin only.
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = await _productService.UpdateProductAsync(id, updateProductDto);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Deletes a product by ID. Admin only.
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Lists products belonging to a specific department.
        /// </summary>
        [HttpGet("by-department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByDepartment(int departmentId)
        {
            var products = await _productService.GetProductsByDepartmentAsync(departmentId);
            return Ok(products);
        }

        /// <summary>
        /// Lists products located in a specific aisle.
        /// </summary>
        [HttpGet("by-aisle/{aisleId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByAisle(int aisleId)
        {
            var products = await _productService.GetProductsByAisleAsync(aisleId);
            return Ok(products);
        }
    }
} 