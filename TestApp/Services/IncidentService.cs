using AutoMapper;
using TestApp.Data;
using TestApp.DTOs;
using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public IncidentService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Incident> CreateOneAsync(IncidentDto incidentDto, CancellationToken token = default)
        {
            Incident incident = _mapper.Map<Incident>(incidentDto);
            await _context.Incidents.AddAsync(incident, token);        
            if (incident.Accounts.Any())
            {
                foreach (var item_acc in incident.Accounts)
                {
                    await _context.Accounts.AddAsync(item_acc, token);

                    if (item_acc.Contacts.Any())
                    {
                        foreach (var item_cont in item_acc.Contacts)
                        {
                            await _context.Contacts.AddAsync(item_cont, token);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync(token);

            return incident;
        }
    }
}
