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

        public AislesController(IAisleService aisleService)
        {
            _aisleService = aisleService;
        }

        // GET: api/aisles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AisleDto>>> GetAisles()
        {
            var aisles = await _aisleService.GetAllAislesAsync();
            return Ok(aisles);
        }

        // GET: api/aisles/5
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

        // POST: api/aisles
        [HttpPost]
        public async Task<ActionResult<AisleDto>> CreateAisle(CreateAisleDto createAisleDto)
        {
            var aisle = await _aisleService.CreateAisleAsync(createAisleDto);
            return CreatedAtAction(nameof(GetAisle), new { id = aisle.Id }, aisle);
        }

        // PUT: api/aisles/5
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

        // DELETE: api/aisles/5
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
    }
} 