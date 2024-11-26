using CalendarSchedule.Application.Handlers.Models;
using MediatR;

namespace CalendarSchedule.Application.Handlers.Commands.Events.Delete
{
    public class DeleteEventCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
}
