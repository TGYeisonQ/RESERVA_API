using Application.Commands.Services.Common;
using Domain.Entities.Services;
using ErrorOr;
using MediatR;

namespace Application.Commands.Services.GetAll;

public sealed class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, ErrorOr<IReadOnlyList<ServiceResponse>>>
{
    private readonly IServiceRepository _serviceRepository;

    public GetAllServiceQueryHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<ServiceResponse>>> Handle(GetAllServiceQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Service> services = await _serviceRepository.GetAll();


        return services.Select(service => new ServiceResponse (
            service.Id,
            service.Name
        )).ToList();
    }
}
