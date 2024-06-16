using Application.Commands.Bookings.Common;
using Application.Commands.Bookings.Create;
using Application.Commands.Bookings.Delete;
using Application.Commands.Bookings.GetFiltered;
using Application.Commands.Bookings.Update;
using Application.Commands.Services.GetAll;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/Booking")]
public class BookingController : ApiController
{
    private readonly ISender _mediator;

    public BookingController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingCommand command)
    {
        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match(
            company => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Guid Id, [FromBody] UpdateBookingCommand command)
    {
        if (Id != command.Id)
        {
            List<Error> errors = new()
            {
                Error.Validation("Company.UpdateInvalid", "The request Id does not match with the url Id.")
            };

            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            booking => NoContent(),
            errors => Problem(errors)
        );
    }


    [HttpGet]
    public async Task<IActionResult> GetFiltered([FromQuery] BookingRequestFiltered filtered)
    {
        var bookins = await _mediator.Send(new GetFilteredBookingQuery(filtered));

        return bookins.Match(
            bookin => Ok(bookin),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(Guid Id)
    {
        var deleteResult = await _mediator.Send(new DeleteBookingCommand(Id));

        return deleteResult.Match(
            booking => NoContent(),
            errors => Problem(errors)
        );
    }
}
