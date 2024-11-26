using CalendarSchedule.API.Handlers.Models;
using MediatR;

namespace CalendarSchedule.API.Handlers.Commands.Events.Delete
{
    public class DeleteEventCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
    }
}
