using Event_Management_API.Models;

namespace Event_Management_API.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<Registration> GetRegistrationByIdAsync(int id);
        Task<Registration> CreateRegistrationAsync(Registration newRegistration);
        Task<bool> UpdateRegistrationAsync(int id, Registration updatedRegistration);
        Task<bool> DeleteRegistrationAsync(int id);
    }

}
