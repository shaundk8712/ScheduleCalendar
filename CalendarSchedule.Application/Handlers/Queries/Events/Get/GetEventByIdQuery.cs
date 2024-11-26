using CalendarSchedule.Application.Handlers.Models;
using CalendarSchedule.Domain.Models;
using MediatR;

namespace CalendarSchedule.Application.Handlers.Queries.Events.Get
{
    public class GetEventByIdQuery : IRequest<BaseResponse<Event>>
    {
        public int Id { get; set; }
    }
}
