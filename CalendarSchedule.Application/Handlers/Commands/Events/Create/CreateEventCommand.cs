using CalendarSchedule.Application.Handlers.Models;
using CalendarSchedule.Domain.Models;
using MediatR;

namespace CalendarSchedule.Application.Handlers.Commands.Events.Create
{
    public class CreateEventCommand : IRequest<BaseResponse<bool>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Attendee> Attendees { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Attendee> AddAttendees(List<Attendee> attendees, int eventId)
        {
            if (attendees == null) return null;

            Attendees = new List<Attendee>() { };

            foreach (var attendee in attendees)
            {
                attendee.Id = Guid.NewGuid();
                attendee.EventId = eventId;
                Attendees.Add(attendee);
            }

            return Attendees;
        }
    }
}
