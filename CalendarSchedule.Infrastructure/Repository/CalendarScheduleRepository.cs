using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalendarSchedule.Infrastructure.Repository
{
    public class CalendarScheduleRepository : ICalendarScheduleRepository
    {
        private CalendarScheduleDbContext _context;

        public CalendarScheduleRepository(CalendarScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents(string? eventName, string? attendeeName, DateTime? startDate, DateTime? endDate)
        {
            List<Event> events = await _context.Events.Include(x => x.Attendees).ToListAsync();

            if (!string.IsNullOrEmpty(eventName))
            {
                events = events.Where(x => eventName.ToLower().Contains(x.Title.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(attendeeName))
            {
                events = events.Where(x => x.Attendees.Any(x => attendeeName.ToLower().Contains(x.Name.ToLower()))).ToList();
            }
            if (startDate.HasValue)
            {
                events = events.Where(x => x.StartDate == startDate).ToList();
            }
            if (endDate.HasValue)
            {
                events = events.Where(x => x.EndDate == endDate).ToList();
            }

            return events;
        }

        public async Task<Event> GetEventById(int id)
        {
            var @event = await _context.Events.Include(x => x.Attendees).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (@event == null)
            {
                return null;
            }

            return @event;
        }

        public async Task<Event> UpdateEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return null;
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }

        public async Task<Event> CreateEvent(Event @event)
        {
            _context.Events.Add(@event);
            _context.Attendees.AddRange(@event.Attendees);
            await _context.SaveChangesAsync();

            return @event;
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return false;
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
