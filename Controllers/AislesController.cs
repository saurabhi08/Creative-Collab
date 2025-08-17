using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AislesController : ControllerBase
    {
        private readonly IAisleService _aisleService;
        private readonly IProductService _productService;

        public AislesController(IAisleService aisleService, IProductService productService)
        {
            _aisleService = aisleService;
            _productService = productService;
        }

        /// <summary>
        /// Retrieves all aisles.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AisleDto>>> GetAisles()
        {
            var aisles = await _aisleService.GetAllAislesAsync();
            return Ok(aisles);
        }

        /// <summary>
        /// Retrieves a single aisle by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AisleDto>> GetAisle(int id)
        {
            var aisle = await _aisleService.GetAisleByIdAsync(id);
            if (aisle == null)
            {
                return NotFound();
            }
            return Ok(aisle);
        }

        /// <summary>
        /// Creates a new aisle.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AisleDto>> CreateAisle(CreateAisleDto createAisleDto)
        {
            var aisle = await _aisleService.CreateAisleAsync(createAisleDto);
            return CreatedAtAction(nameof(GetAisle), new { id = aisle.Id }, aisle);
        }

        /// <summary>
        /// Updates an existing aisle by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAisle(int id, UpdateAisleDto updateAisleDto)
        {
            var aisle = await _aisleService.UpdateAisleAsync(id, updateAisleDto);
            if (aisle == null)
            {
                return NotFound();
            }
            return Ok(aisle);
        }

        /// <summary>
        /// Deletes an aisle by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAisle(int id)
        {
            var result = await _aisleService.DeleteAisleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Retrieves products located in a specific aisle.
        /// </summary>
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsForAisle(int id)
        {
            var products = await _productService.GetProductsByAisleAsync(id);
            return Ok(products);
        }
    }
} 