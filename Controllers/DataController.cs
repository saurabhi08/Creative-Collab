using Microsoft.AspNetCore.Mvc;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataSeedService _dataSeedService;

        public DataController(IDataSeedService dataSeedService)
        {
            _dataSeedService = dataSeedService;
        }

        // POST: api/data/seed
        [HttpPost("seed")]
        public async Task<IActionResult> SeedData()
        {
            try
            {
                await _dataSeedService.SeedDataAsync();
                return Ok(new { message = "Database seeded successfully with sample data!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error seeding data: {ex.Message}" });
            }
        }
    }
} 