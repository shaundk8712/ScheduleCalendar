using CalendarSchedule.API.Handlers.Models;
using CalendarSchedule.Domain.Models;
using MediatR;

namespace CalendarSchedule.API.Handlers.Queries.Events.Get
{
    public class GetAllEventsQuery : IRequest<BaseResponse<IEnumerable<Event>>>
    {
        public string? EventName { get; set; }
        public string? AttendeeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
