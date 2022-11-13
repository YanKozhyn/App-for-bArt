using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IIncidentService
    {
        Task<ICollection<Incident>> GetAllAsync(CancellationToken token = default);
        Task<Incident> CreateOneAsync(CreateIncidentDto incidentDto, CancellationToken token = default);
        Task<Incident?> GetByIdAsync(string id, CancellationToken token = default);
        Task DeleteByIdAsync(string id, CancellationToken token = default);

    }
}
