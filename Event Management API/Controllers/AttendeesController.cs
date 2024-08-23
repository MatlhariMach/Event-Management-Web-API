using Event_Management_API.Interfaces;
using Event_Management_API.Models;
using Event_Management_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Event_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;

        public AttendeesController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendee>>> GetAllAttendee()
        {
            var attendee = await _attendeeService.GetAllAttendeesAsync();
            return Ok(attendee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Attendee>> GetAttendeeById(int id)
        {
            var attendeeItem = await _attendeeService.GetAttendeeByIdAsync(id);
            if (attendeeItem == null)
            {
                return NotFound();
            }
            return Ok(attendeeItem);
        }

        [HttpPost]
        public async Task<ActionResult<Attendee>> CreateAttendee(Attendee newAttendee)
        {
            var createdAttendee = await _attendeeService.CreateAttendeeAsync(newAttendee);
            return CreatedAtAction(nameof(GetAttendeeById), new { id = createdAttendee.Id }, createdAttendee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendee(int id, Attendee updatedAttendee)
        {
            var result = await _attendeeService.UpdateAttendeeAsync(id, updatedAttendee);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee(int id)
        {
            var result = await _attendeeService.DeleteAttendeeAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
