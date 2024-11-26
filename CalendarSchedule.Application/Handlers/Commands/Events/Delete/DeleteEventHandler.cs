using CalendarSchedule.Application.Handlers.Models;
using CalendarSchedule.Domain.Models;
using CalendarSchedule.Domain.Interfaces;
using MediatR;

namespace CalendarSchedule.Application.Handlers.Commands.Events.Delete
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, BaseResponse<bool>>
    {
        private readonly ICalendarScheduleRepository _calendarScheduleRepository;

        public DeleteEventHandler(ICalendarScheduleRepository calendarScheduleRepository)
        {
            _calendarScheduleRepository = calendarScheduleRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var attendees = new List<Attendee>();

                bool eventExistAndDeletedSuccessfully = await _calendarScheduleRepository.DeleteEvent(command.Id);

                if (eventExistAndDeletedSuccessfully)
                {
                    return new BaseResponse<bool> { Success = true, Message = "Delete event succeeded" };
                }
                else
                {
                    return new BaseResponse<bool> { Success = false, Message = "No event found to delete by that id" };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool> { Success = false, Message = "Failed to delete event" };
            }
        }
    }
}
