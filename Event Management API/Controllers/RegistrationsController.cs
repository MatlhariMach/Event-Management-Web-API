using Event_Management_API.Interfaces;
using Event_Management_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_API.Controllers
{
    namespace Event_Management_API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class RegistrationsController : ControllerBase
        {
            private readonly IRegistrationService _registrationService;

            public RegistrationsController(IRegistrationService registrationService)
            {
                _registrationService = registrationService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Registration>>> GetAllRegistrations()
            {
                var registrations = await _registrationService.GetAllRegistrationsAsync();
                return Ok(registrations);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Registration>> GetRegistrationById(int id)
            {
                var registration = await _registrationService.GetRegistrationByIdAsync(id);
                if (registration == null)
                {
                    return NotFound();
                }
                return Ok(registration);
            }

            [HttpPost]
            public async Task<ActionResult<Registration>> CreateRegistration(Registration newRegistration)
            {
                var createdRegistration = await _registrationService.CreateRegistrationAsync(newRegistration);
                return CreatedAtAction(nameof(GetRegistrationById), new { id = createdRegistration.Id }, createdRegistration);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateRegistration(int id, Registration updatedRegistration)
            {
                var result = await _registrationService.UpdateRegistrationAsync(id, updatedRegistration);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteRegistration(int id)
            {
                var result = await _registrationService.DeleteRegistrationAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
        }
    }

}
