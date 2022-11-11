using TestApp.Interfaces;

namespace TestApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IAccountRepository Accounts => new AccountRepository(_context);

        public IIncedentRepository Incidents => new IncidentRepository(_context);

        public IContactRepository Contacts => new ContactRepository(_context);

        public async Task SaveAsync(CancellationToken token = default)
        {
            await _context.SaveChangesAsync(token);
        }
    }
}
