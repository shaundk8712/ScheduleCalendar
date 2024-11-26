using CalendarSchedule.Domain.Models;
using FluentValidation;

namespace CalendarSchedule.API.FluentValidations
{
    public class AttendeeValidator : AbstractValidator<Attendee>
    {
        public AttendeeValidator()
        {
            RuleFor(x => x.Name).Length(3, 50).NotEmpty().WithMessage("Please specify an attendee name.");
            RuleFor(x => x.EmailAddress).EmailAddress().Length(5, 250).NotEmpty().WithMessage("Please type valid email address.");
            RuleFor(x => x.IsAttending).NotNull();
        }
    }
}
