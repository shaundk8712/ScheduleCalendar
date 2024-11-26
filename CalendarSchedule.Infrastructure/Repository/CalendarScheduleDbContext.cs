using CalendarSchedule.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CalendarSchedule.Infrastructure.Repository
{
    public class CalendarScheduleDbContext(DbContextOptions<CalendarScheduleDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
    }
}
