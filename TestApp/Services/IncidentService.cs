using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Incident> CreateOneAsync(CreateIncidentDto incidentDto, CancellationToken token = default)
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

        public async Task<ICollection<Incident>> GetAllAsync(CancellationToken token = default)
            => await _context.Incidents.ToListAsync(token);

        public async Task<Incident> GetByIdAsync(string id, CancellationToken token = default)
            => await _context.Incidents
                                .Include(a => a.Accounts)
                                .ThenInclude(c => c.Contacts)
                                .SingleOrDefaultAsync(n => n.Name == id, token);

        public async Task DeleteByIdAsync(string id, CancellationToken token = default)
            => _context.Incidents.Remove(await GetByIdAsync(id));

    }
}
