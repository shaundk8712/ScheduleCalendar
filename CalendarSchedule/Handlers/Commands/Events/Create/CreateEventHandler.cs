using CalendarSchedule.API.Handlers.Models;
using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Interfaces;
using MediatR;

namespace CalendarSchedule.API.Handlers.Commands.Events.Create
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, BaseResponse<bool>>
    {
        private readonly ICalendarScheduleRepository _calendarScheduleRepository;

        public CreateEventHandler(ICalendarScheduleRepository calendarScheduleRepository)
        {
            _calendarScheduleRepository = calendarScheduleRepository;
        }

        public async Task<BaseResponse<bool>> Handle(CreateEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Event Event = new Event() { };
                Event = await _calendarScheduleRepository.CreateEvent(new Event
                {
                    Id = command.Id,
                    Title = command.Title,
                    Description = command.Description,
                    Attendees = command.AddAttendees(command.Attendees, command.Id),
                    StartDate = command.StartDate,
                    EndDate = command.EndDate
                });

                return Event != null ? new BaseResponse<bool> { Success = true, Message = "Create event succeeded" }
                : new BaseResponse<bool> { Success = false, Message = "Failed to create event" };
            }
            catch (Exception)
            {
                return new BaseResponse<bool> { Success = false, Message = "Failed to create event" };
            }
        }
    }
}
