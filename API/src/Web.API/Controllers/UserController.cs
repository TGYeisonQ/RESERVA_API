using Application.Commands.Users.Create;
using Application.Commands.Users.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/User")]
public class UserController : ApiController
{
    private readonly ISender _mediator;

    public UserController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var createCustomerResult = await _mediator.Send(command);

        return createCustomerResult.Match(
            user => Ok(),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetAllUserQuery());

        return users.Match(
            user => Ok(user),
            errors => Problem(errors)
        );
    }
}
