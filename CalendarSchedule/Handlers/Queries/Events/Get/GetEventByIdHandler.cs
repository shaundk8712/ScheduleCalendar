using CalendarSchedule.API.Handlers.Models;
using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Interfaces;
using MediatR;

namespace CalendarSchedule.API.Handlers.Queries.Events.Get
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdQuery, BaseResponse<Event>>
    {
        private readonly ICalendarScheduleRepository _calendarScheduleRepository;

        public GetEventByIdHandler(ICalendarScheduleRepository calendarScheduleRepository)
        {
            _calendarScheduleRepository = calendarScheduleRepository;
        }

        public async Task<BaseResponse<Event>> Handle(GetEventByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                Event Event = await _calendarScheduleRepository.GetEventById(query.Id);

                if (Event != null)
                {
                    List<Event> events = new List<Event>();
                    events.Add(Event);

                    return new BaseResponse<Event> { Event = events, Success = true, Message = "Successfully retrieved event by id" }; ;
                }
                else
                {
                    return new BaseResponse<Event> { Success = false, Message = "Could not find an event with that specific id" };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<Event> { Success = false, Message = "Failed to get event by id" };
            }
        }
    }
}