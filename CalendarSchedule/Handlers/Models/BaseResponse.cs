using CalendarSchedule.Domain.Models;

namespace CalendarSchedule.API.Handlers.Models
{
    public class BaseResponse<boolean>
    {
        public IEnumerable<Event> Event { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
