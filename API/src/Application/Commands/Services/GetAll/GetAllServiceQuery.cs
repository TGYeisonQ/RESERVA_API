using Application.Commands.Services.Common;
using ErrorOr;
using MediatR;

namespace Application.Commands.Services.GetAll;

public record class GetAllServiceQuery (): IRequest<ErrorOr<IReadOnlyList<ServiceResponse>>>;
