using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Contact contact, CancellationToken token = default)
        {
            await _context.Contacts.AddAsync(contact, token);
        }
    }
}
