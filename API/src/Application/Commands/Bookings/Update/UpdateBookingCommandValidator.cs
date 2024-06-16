using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Bookings.Update;

public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
{
    public UpdateBookingCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().NotNull().WithMessage("Title is required").MaximumLength(30).WithMessage("Invalid text string length").WithName("Name");
        RuleFor(c => c.Observations).MaximumLength(100).WithMessage("Invalid text string length");
        RuleFor(c => c.ServiceId).NotEmpty().NotNull().WithMessage("Service is required");
        RuleFor(c => c.UserId).NotEmpty().NotNull().WithMessage("User is required");
        RuleFor(c => c.DateBooking).NotEmpty().NotNull().WithMessage("DateBooking is required");
    }
}
