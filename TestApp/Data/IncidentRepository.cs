using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Data
{
    public class IncidentRepository : IIncedentRepository
    {
        private readonly DataContext _context;

        public IncidentRepository(DataContext context)
        {
           _context = context;
        }

        public async Task CreateOneAsync(Incident incident, CancellationToken token = default)
        {
            await _context.Incidents.AddAsync(incident, token);
            if (incident.Accounts.Any())
            {
                foreach (var item_acc in incident.Accounts)
                {
                    await _context.Accounts.AddAsync(item_acc, token);

                    if (item.Contacts.Any())
                    {
                        foreach (var item_cont in item_acc.Contacts)
                        {
                            await _context.Contacts.AddAsync(item_cont, token);
                        }
                    }
                }
            }

        }   
    }
}
