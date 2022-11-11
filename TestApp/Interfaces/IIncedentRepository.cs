using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IIncedentRepository
    {
        Task CreateOneAsync(Incident incident, CancellationToken token = default);
    }
}
