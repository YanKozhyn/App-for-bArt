using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IIncidentService
    {
        Task<Incident> CreateOneAsync(IncidentDto incidentDto);
    }
}
