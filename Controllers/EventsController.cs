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

        /// <summary>
        /// Retrieves all events.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        /// <summary>
        /// Retrieves a single event by ID.
        /// </summary>
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

        /// <summary>
        /// Creates a new event.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EventDto>> CreateEvent(CreateEventDto createEventDto)
        {
            var eventEntity = await _eventService.CreateEventAsync(createEventDto);
            return CreatedAtAction(nameof(GetEvent), new { id = eventEntity.Id }, eventEntity);
        }

        /// <summary>
        /// Updates an existing event by ID.
        /// </summary>
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

        /// <summary>
        /// Deletes an event by ID.
        /// </summary>
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