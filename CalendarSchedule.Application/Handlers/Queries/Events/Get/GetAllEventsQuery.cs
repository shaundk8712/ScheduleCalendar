using CalendarSchedule.Application.Handlers.Models;
using CalendarSchedule.Domain.Models;
using MediatR;

namespace CalendarSchedule.Application.Handlers.Queries.Events.Get
{
    public class GetAllEventsQuery : IRequest<BaseResponse<IEnumerable<Event>>>
    {
        public string? EventName { get; set; }
        public string? AttendeeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
