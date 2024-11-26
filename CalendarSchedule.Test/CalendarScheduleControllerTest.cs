using CalendarSchedule.Domain.Models;
using CalendarSchedule.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace CalendarSchedule.Test
{
    public class EventUnitTestController
    {
        private CalendarScheduleDbContext _context;
        private CalendarScheduleRepository _repository;

        public static DbContextOptions<CalendarScheduleDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=ABCD;Database=CalendarSchedule;UID=sa;PWD=xxxxxxxxxx;";
        static EventUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<CalendarScheduleDbContext>()
                .UseInMemoryDatabase(connectionString)
                .Options;
        }

        public EventUnitTestController()
        {
            _context = new CalendarScheduleDbContext(dbContextOptions);
            _repository = new CalendarScheduleRepository(_context);
        }

        [Fact]
        public async Task Create_ShouldReturnEvent_WhenCreatedSuccessfully()
        {
            // Arrange
            Event expectedEvent = CreateSingleEvent();

            // Act
            var actualEvent = await _repository.CreateEvent(expectedEvent);

            // Assert
            Assert.Equal(expectedEvent.Id, actualEvent?.Id);
            Assert.Equal(expectedEvent.Title, actualEvent?.Title);
        }

        [Fact]
        public async Task Delete_ShouldDeleteEvent_WhenIdIsGiven()
        {
            // Arrange
            Event expectedEvent = CreateSingleEvent();

            await _repository.CreateEvent(expectedEvent);

            // Act
            var actualEvent = await _repository.DeleteEvent(expectedEvent.Id);

            // Assert
            Assert.Equal(0, _context.Events.Where(x => x.Id == expectedEvent.Id).Count());
        }

        [Fact]
        public async Task Update_ShouldUpdateEvent_WhenIdIsGiven()
        {
            // Arrange
            string updatedEventTitle = "My Test Event";
            Event expectedEvent = CreateSingleEvent();

            await _repository.CreateEvent(expectedEvent);

            // Act
            var actualEvent = await _repository.GetEventById(expectedEvent.Id);
            actualEvent.Title = updatedEventTitle;
            var actualEntry = await _repository.UpdateEvent(actualEvent.Id, actualEvent);

            // Assert
            Assert.Equal(expectedEvent.Id, actualEvent?.Id);
            Assert.Equal(updatedEventTitle, actualEvent?.Title);
        }


        [Fact]
        public async Task GetAll_ShouldReturnEvents_WhenFilterIsGiven()
        {
            // Arrange
            Event[] expectedEvents = CreateMultipleEvents();

            await _repository.CreateEvent(expectedEvents[0]);
            await _repository.CreateEvent(expectedEvents[1]);

            // Act
            var actualEvents = await _repository.GetAllEvents("End of Year Function", null, null, null);

            // Assert
            Assert.Equal(1, actualEvents?.Count());
            Assert.Equal(expectedEvents[0].Title, actualEvents.ElementAt(0).Title);
        }

        [Fact]
        public async Task GetById_ShouldReturnEvent_WhenIdIsGiven()
        {
            // Arrange
            Event expectedEvent = CreateSingleEvent();

            await _repository.CreateEvent(expectedEvent);

            // Act
            var actualEvent = await _repository.GetEventById(expectedEvent.Id);

            // Assert
            Assert.Equal(expectedEvent.Id, actualEvent?.Id);
            Assert.Equal(expectedEvent.Title, actualEvent?.Title);
            Assert.Equal(expectedEvent.Description, actualEvent?.Description);
            Assert.Equal(expectedEvent.StartDate, actualEvent?.StartDate);
        }

        private static Event CreateSingleEvent()
        {
            Random rnd = new Random();

            return new Event()
            {
                Id = rnd.Next(0, 1001),
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
            };
        }

        private static Event[] CreateMultipleEvents()
        {
            Random rnd = new Random();

            return new Event[]
            {
                new Event(){
                Id =  rnd.Next(1002, 2000),
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
                     Id = rnd.Next(1002, 2000),
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
            };
        }
    }
}
