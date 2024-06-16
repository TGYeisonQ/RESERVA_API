using Domain.Entities.Bookings;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Domain.DomainErrors.Errors;

namespace Application.Commands.Bookings.Update;

public sealed class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, ErrorOr<Unit>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookingCommandHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateBookingCommand command, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(command.Id);

        if (booking == null)
            return Error.NotFound("Company.NotFound", "The company with the provide Id was not found.");

        booking.DateBooking = command.DateBooking;
        booking.Title = command.Title;
        booking.Observations = command.Observations;
        booking.ServiceId = command.ServiceId;
        booking.UserId = command.UserId;

        _bookingRepository.Update(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
