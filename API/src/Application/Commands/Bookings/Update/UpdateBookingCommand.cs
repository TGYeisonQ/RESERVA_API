using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Bookings.Update;

public record UpdateBookingCommand (
        Guid Id,
        DateTime DateBooking,
        Guid ServiceId,
        string UserId,
        string Title,
        string Observations
    ) : IRequest<ErrorOr<Unit>>;
