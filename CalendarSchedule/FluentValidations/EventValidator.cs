using CalendarSchedule.Domain.Models;
using FluentValidation;

namespace CalendarSchedule.API.FluentValidations
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(x => x.Title).Length(5, 250).NotEmpty().WithMessage("Please specify an event title.");
            RuleFor(x => x.Description).Length(5, 250).NotEmpty().WithMessage("Please type an event description.");
            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Please specify a start time/date");
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate)
                          .WithMessage("End date must be after start date")
                          .NotNull().NotEmpty().WithMessage("Please specify an end time/date.");
            RuleFor(X => X.Attendees).NotNull().NotEmpty().WithMessage("Please specify an attendee for the event");
        }
    }
}
