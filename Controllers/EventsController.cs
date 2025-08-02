using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        // GET: api/events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var eventEntity = await _eventService.GetEventByIdAsync(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            return Ok(eventEntity);
        }

        // POST: api/events
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto createEventDto)
        {
            var eventEntity = await _eventService.CreateEventAsync(createEventDto);
            return CreatedAtAction(nameof(GetEvent), new { id = eventEntity.Id }, eventEntity);
        }

        // PUT: api/events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            var eventEntity = await _eventService.UpdateEventAsync(id, updateEventDto);
            if (eventEntity == null)
            {
                return NotFound();
            }
            return Ok(eventEntity);
        }

        // DELETE: api/events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEventAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
} 