using Event_Management_API.Data;
using Event_Management_API.Interfaces;
using Event_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_API.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly ApplicationDbContext _context;

        public AttendeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendee>> GetAllAttendeesAsync()
        {
            return await _context.Attendees.ToListAsync();
        }

        public async Task<Attendee> GetAttendeeByIdAsync(int id)
        {
            return await _context.Attendees.FindAsync(id);
        }

        public async Task<Attendee> CreateAttendeeAsync(Attendee newAttendee)
        {
            _context.Attendees.Add(newAttendee);
            await _context.SaveChangesAsync();
            return newAttendee;
        }

        public async Task<bool> UpdateAttendeeAsync(int id, Attendee updatedAttendee)
        {
            var attendeeEntity = await _context.Attendees.FindAsync(id);
            if (attendeeEntity == null)
                return false;

            attendeeEntity.Name = updatedAttendee.Name;
            attendeeEntity.Email = updatedAttendee.Email;
            // Update other fields

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAttendeeAsync(int id)
        {
            var attendeeEntity = await _context.Attendees.FindAsync(id);
            if (attendeeEntity == null)
                return false;

            _context.Attendees.Remove(attendeeEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
