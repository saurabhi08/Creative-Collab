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

        // GET: api/readingspots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadingSpotDto>>> GetReadingSpots()
        {
            var readingSpots = await _readingSpotService.GetAllReadingSpotsAsync();
            return Ok(readingSpots);
        }

        // GET: api/readingspots/5
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

        // POST: api/readingspots
        [HttpPost]
        public async Task<ActionResult<ReadingSpotDto>> CreateReadingSpot(CreateReadingSpotDto createReadingSpotDto)
        {
            var readingSpot = await _readingSpotService.CreateReadingSpotAsync(createReadingSpotDto);
            return CreatedAtAction(nameof(GetReadingSpot), new { id = readingSpot.Id }, readingSpot);
        }

        // PUT: api/readingspots/5
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

        // DELETE: api/readingspots/5
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