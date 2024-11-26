using CalendarSchedule.API.Handlers.Models;
using CalendarSchedule.Domain.Models;
using MediatR;

namespace CalendarSchedule.API.Handlers.Queries.Events.Get
{
    public class GetEventByIdQuery : IRequest<BaseResponse<Event>>
    {
        public int Id { get; set; }
    }
}
