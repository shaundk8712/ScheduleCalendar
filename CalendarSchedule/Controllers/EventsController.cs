using CalendarSchedule.Application.Handlers.Commands.Events.Create;
using CalendarSchedule.Application.Handlers.Commands.Events.Delete;
using CalendarSchedule.Application.Handlers.Commands.Events.Update;
using CalendarSchedule.Application.Handlers.Queries.Events.Get;
using CalendarSchedule.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalendarSchedule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateEvent")]
        public async Task<ActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent([FromQuery] DeleteEventCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response.Message);
            }

            return BadRequest(response.Message);
        }

        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommand command, [FromQuery] int id)
        {
            var eventExistCheck = await _mediator.Send(new GetEventByIdQuery() { Id = id });

            if (!eventExistCheck.Success)
                return BadRequest(eventExistCheck.Message);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            command.Id = id;

            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("GetEventById")]
        public async Task<ActionResult<Event>> GetEventById([FromQuery] int id)
        {
            var response = await _mediator.Send(new GetEventByIdQuery() { Id = id });

            if (response.Success)
            {
                return Ok(response.Event.FirstOrDefault());
            }

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllEvents")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents([FromQuery] string? eventName, [FromQuery] string? attendeeName, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var response = await _mediator.Send(new GetAllEventsQuery() { EventName = eventName, AttendeeName = attendeeName, StartDate = startDate, EndDate = endDate });

            if (response.Success)
            {
                return Ok(response.Event);
            }

            return BadRequest(response.Message);
        }
    }
}
