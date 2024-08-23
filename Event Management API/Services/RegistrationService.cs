using Event_Management_API.Data;
using Event_Management_API.Interfaces;
using Event_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Event_Management_API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
            return await _context.Registrations
                .Include(r => r.Event)
                .Include(r => r.Attendee)
                .ToListAsync();
        }

        public async Task<Registration?> GetRegistrationByIdAsync(int id)
        {
            return await _context.Registrations
                .Include(r => r.Event)
                .Include(r => r.Attendee)
                .FirstOrDefaultAsync(r => r.Id == id);
        }


        public async Task<Registration> CreateRegistrationAsync(Registration newRegistration)
        {
            _context.Registrations.Add(newRegistration);
            await _context.SaveChangesAsync();
            return newRegistration;
        }

        public async Task<bool> UpdateRegistrationAsync(int id, Registration updatedRegistration)
        {
            var registrationEntity = await _context.Registrations.FindAsync(id);
            if (registrationEntity == null)
                return false;

            registrationEntity.RegistrationDate = updatedRegistration.RegistrationDate;
            registrationEntity.EventId = updatedRegistration.EventId;
            registrationEntity.AttendeeId = updatedRegistration.AttendeeId;

            // Update any other fields as needed

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRegistrationAsync(int id)
        {
            var registrationEntity = await _context.Registrations.FindAsync(id);
            if (registrationEntity == null)
                return false;

            _context.Registrations.Remove(registrationEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
