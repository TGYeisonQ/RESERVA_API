using Application.Commands.Services.Create;
using Application.Commands.Services.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/service")]
public class ServiceController : ApiController
{
    private readonly ISender _mediator;

    public ServiceController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceCommand command)
    {
        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match(
            service => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var services = await _mediator.Send(new GetAllServiceQuery());

        return services.Match(
            service => Ok(service),
            errors => Problem(errors)
        );
    }
}
