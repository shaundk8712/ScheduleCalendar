using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Repository;

namespace CalendarSchedule.Test
{
    public class DummyDataDbInitializer
    {
        public DummyDataDbInitializer()
        { }

        public async void Seed(CalendarScheduleDbContext context)
        {
            context.Events.AddRange(
                new Event()
                {
                    Id = 1,
                    Title = "End of Year Function",
                    Description = "This is a test event",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    Attendees = new List<Attendee>()
                    {
                        new Attendee()
                        {
                            Name = "Johannes Van Wyk",
                            Id = Guid.NewGuid(),
                            EmailAddress = "johannesvanwyk@xyz.com",
                            EventId = 1,
                            IsAttending = true
                        },
                        new Attendee()
                        {
                            Name = "Pieter Swannepoel",
                            Id = Guid.NewGuid(),
                            EmailAddress = "pieterswannepoel@xyz.com",
                            EventId = 1,
                            IsAttending = false
                        },
                    }
                },
                 new Event()
                 {
                     Id = 2,
                     Title = "Spring break Gala",
                     Description = "This is a test event",
                     StartDate = DateTime.Now,
                     EndDate = DateTime.Now.AddDays(1),
                     Attendees = new List<Attendee>()
                    {
                        new Attendee()
                        {
                            Name = "Sara O Connor",
                            Id = Guid.NewGuid(),
                            EmailAddress = "saraoconnor@abc.net",
                            EventId = 2,
                            IsAttending = true
                        },
                        new Attendee()
                        {
                            Name = "Marichelle Du Plessis",
                            Id = Guid.NewGuid(),
                            EmailAddress = "marichelleduplessis@abc.net",
                            EventId = 2,
                            IsAttending = false
                        },
                    }
                 }
                );

            await context.SaveChangesAsync();
        }
    }
}
