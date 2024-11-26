using CalendarSchedule.Domain.Models;

namespace CalendarSchedule.Domain.Interfaces
{
    public interface ICalendarScheduleRepository
    {
        public Task<IEnumerable<Event>> GetAllEvents(string? eventName, string? attendeeName, DateTime? startDate, DateTime? endDate);

        public Task<Event> GetEventById(int id);

        public Task<Event> UpdateEvent(int id, Event @event);

        public Task<Event> CreateEvent(Event @event);

        public Task<bool> DeleteEvent(int id);

    }
}
