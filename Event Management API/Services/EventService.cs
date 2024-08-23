using Event_Management_API.Data;
using Event_Management_API.Interfaces;
using Event_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_API.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return newEvent;
        }

        public async Task<bool> UpdateEventAsync(int id, Event updatedEvent)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null)
                return false;

            eventEntity.Name = updatedEvent.Name;
            eventEntity.Date = updatedEvent.Date;
            eventEntity.Location = updatedEvent.Location;
            // Update other fields

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventEntity = await _context.Events.FindAsync(id);
            if (eventEntity == null)
                return false;

            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
