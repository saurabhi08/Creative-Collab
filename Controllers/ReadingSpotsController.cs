using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingSpotsController : ControllerBase
    {
        private readonly IReadingSpotService _readingSpotService;

        public ReadingSpotsController(IReadingSpotService readingSpotService)
        {
            _readingSpotService = readingSpotService;
        }

        /// <summary>
        /// Retrieves all reading spots.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadingSpotDto>>> GetReadingSpots()
        {
            var readingSpots = await _readingSpotService.GetAllReadingSpotsAsync();
            return Ok(readingSpots);
        }

        /// <summary>
        /// Retrieves a single reading spot by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadingSpotDto>> GetReadingSpot(int id)
        {
            var readingSpot = await _readingSpotService.GetReadingSpotByIdAsync(id);
            if (readingSpot == null)
            {
                return NotFound();
            }
            return Ok(readingSpot);
        }

        /// <summary>
        /// Creates a new reading spot.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ReadingSpotDto>> CreateReadingSpot(CreateReadingSpotDto createReadingSpotDto)
        {
            var readingSpot = await _readingSpotService.CreateReadingSpotAsync(createReadingSpotDto);
            return CreatedAtAction(nameof(GetReadingSpot), new { id = readingSpot.Id }, readingSpot);
        }

        /// <summary>
        /// Updates an existing reading spot by ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReadingSpot(int id, UpdateReadingSpotDto updateReadingSpotDto)
        {
            var readingSpot = await _readingSpotService.UpdateReadingSpotAsync(id, updateReadingSpotDto);
            if (readingSpot == null)
            {
                return NotFound();
            }
            return Ok(readingSpot);
        }

        /// <summary>
        /// Deletes a reading spot by ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReadingSpot(int id)
        {
            var result = await _readingSpotService.DeleteReadingSpotAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
} 