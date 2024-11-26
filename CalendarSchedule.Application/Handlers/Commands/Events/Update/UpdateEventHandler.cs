using CalendarSchedule.Application.Handlers.Models;
using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Interfaces;
using MediatR;

namespace CalendarSchedule.Application.Handlers.Commands.Events.Update
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, BaseResponse<bool>>
    {
        private readonly ICalendarScheduleRepository _calendarScheduleRepository;

        public UpdateEventHandler(ICalendarScheduleRepository calendarScheduleRepository)
        {
            _calendarScheduleRepository = calendarScheduleRepository;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Event existingEvent = await _calendarScheduleRepository.GetEventById(command.Id);

                if (existingEvent != null)
                {
                    Event updatedEvent = new Event() { };

                    updatedEvent = await _calendarScheduleRepository.UpdateEvent(command.Id, new Event
                    {
                        Title = command.Title,
                        Description = command.Description,
                        Attendees = command.AddAttendees(command.Attendees, command.Id),
                        StartDate = command.StartDate,
                        EndDate = command.EndDate
                    });

                    List<Event> updatedEventItems = new List<Event>();
                    updatedEventItems.Add(updatedEvent);

                    return updatedEvent != null ? new BaseResponse<bool> { Event = updatedEventItems, Success = true, Message = "Update event succeeded" }
                                                : new BaseResponse<bool> { Success = false, Message = "Failed to update event" };
                }

                return new BaseResponse<bool> { Success = false, Message = "No event found to update with provided id" };

            }
            catch (Exception)
            {
                return new BaseResponse<bool> { Success = false, Message = "Failed to update event" };
            }
        }
    }
}