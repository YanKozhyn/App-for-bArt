using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Account account, CancellationToken token = default)
        {
            await _context.Accounts.AddAsync(account, token);
            if (account.Contacts.Any())
            {
                foreach (var contact in account.Contacts)
                {
                    await _context.Contacts.AddAsync(contact, token);
                }
            }
        }
    }
}
