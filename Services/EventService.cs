using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class EventService : IEventService
    {
        private readonly MindAndMarketContext _context;

        public EventService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            return await _context.Events
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Location = e.Location,
                    MaxCapacity = e.MaxCapacity,
                    CurrentAttendees = e.CurrentAttendees,
                    EventType = e.EventType,
                    IsActive = e.IsActive,
                    CreatedDate = e.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null) return null;

            return new EventDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Location = eventEntity.Location,
                MaxCapacity = eventEntity.MaxCapacity,
                CurrentAttendees = eventEntity.CurrentAttendees,
                EventType = eventEntity.EventType,
                IsActive = eventEntity.IsActive,
                CreatedDate = eventEntity.CreatedDate
            };
        }

        public async Task<EventDto> CreateEventAsync(CreateEventDto createEventDto)
        {
            var eventEntity = new Event
            {
                Title = createEventDto.Title,
                Description = createEventDto.Description,
                StartTime = createEventDto.StartTime,
                EndTime = createEventDto.EndTime,
                Location = createEventDto.Location,
                MaxCapacity = createEventDto.MaxCapacity,
                CurrentAttendees = createEventDto.CurrentAttendees,
                EventType = createEventDto.EventType,
                IsActive = createEventDto.IsActive
            };

            _context.Events.Add(eventEntity);
            await _context.SaveChangesAsync();

            return new EventDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Location = eventEntity.Location,
                MaxCapacity = eventEntity.MaxCapacity,
                CurrentAttendees = eventEntity.CurrentAttendees,
                EventType = eventEntity.EventType,
                IsActive = eventEntity.IsActive,
                CreatedDate = eventEntity.CreatedDate
            };
        }

        public async Task<EventDto?> UpdateEventAsync(int id, UpdateEventDto updateEventDto)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null) return null;

            eventEntity.Title = updateEventDto.Title;
            eventEntity.Description = updateEventDto.Description;
            eventEntity.StartTime = updateEventDto.StartTime;
            eventEntity.EndTime = updateEventDto.EndTime;
            eventEntity.Location = updateEventDto.Location;
            eventEntity.MaxCapacity = updateEventDto.MaxCapacity;
            eventEntity.CurrentAttendees = updateEventDto.CurrentAttendees;
            eventEntity.EventType = updateEventDto.EventType;
            eventEntity.IsActive = updateEventDto.IsActive;

            await _context.SaveChangesAsync();

            return new EventDto
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Location = eventEntity.Location,
                MaxCapacity = eventEntity.MaxCapacity,
                CurrentAttendees = eventEntity.CurrentAttendees,
                EventType = eventEntity.EventType,
                IsActive = eventEntity.IsActive,
                CreatedDate = eventEntity.CreatedDate
            };
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null) return false;

            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 