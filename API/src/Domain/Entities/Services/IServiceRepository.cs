

namespace Domain.Entities.Services;

public interface IServiceRepository
{
    Task<Service?> GetByIdAsync(Guid id);
    Task<List<Service>> GetAll();
    Task<bool> ExistsAsync(Guid id);
    Task Add(Service service);
    void Update(Service service);
    void Delete(Service service);
}
