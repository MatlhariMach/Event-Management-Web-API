using Event_Management_API.Models;

namespace Event_Management_API.Interfaces
{
    public interface IAttendeeService
    {
        Task<IEnumerable<Attendee>> GetAllAttendeesAsync();
        Task<Attendee> GetAttendeeByIdAsync(int id);
        Task<Attendee> CreateAttendeeAsync(Attendee newAttendee);
        Task<bool> UpdateAttendeeAsync(int id, Attendee updatedAttendee);
        Task<bool> DeleteAttendeeAsync(int id);
    }

}
