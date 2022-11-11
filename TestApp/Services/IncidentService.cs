using AutoMapper;
using TestApp.DTOs;
using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IncidentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Incident> CreateOneAsync(IncidentDto incidentDto, CancellationToken token = default)
        {
            Incident incident = _mapper.Map<Incident>(incidentDto);

            await _unitOfWork.Incidents.CreateOneAsync(incident, token);
            await _unitOfWork.SaveAsync(token);

            return incident;
        }
    }
}
