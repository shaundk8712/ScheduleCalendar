using CalendarSchedule.API.Handlers.Models;
using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Interfaces;
using MediatR;

namespace CalendarSchedule.API.Handlers.Queries.Events.Get
{
    public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, BaseResponse<IEnumerable<Event>>>
    {
        private readonly ICalendarScheduleRepository _calendarScheduleRepository;

        public GetAllEventsHandler(ICalendarScheduleRepository calendarScheduleRepository)
        {
            _calendarScheduleRepository = calendarScheduleRepository;
        }

        public async Task<BaseResponse<IEnumerable<Event>>> Handle(GetAllEventsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Event> Events = await _calendarScheduleRepository.GetAllEvents(query.EventName, query.AttendeeName, query.StartDate, query.EndDate);

                if (Events != null && Events.Count() > 0)
                {
                    return new BaseResponse<IEnumerable<Event>> { Event = Events, Success = true, Message = "Successfully retrieved all events" }; ;
                }
                else
                {
                    return new BaseResponse<IEnumerable<Event>> { Success = false, Message = "No events available to list at this time" };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<IEnumerable<Event>> { Success = false, Message = "Failed to get all events" };
            }
        }
    }
}