using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.DTOs;
using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AccountService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Account> CreateAsync(CreateAccountDto accountDto, CancellationToken token = default)
        {
            Account account = _mapper.Map<Account>(accountDto);
            await _context.Accounts.AddAsync(account, token);
            if (account.Contacts.Any())
            {
                foreach (var contact in account.Contacts)
                {
                    await _context.Contacts.AddAsync(contact, token);
                }
            }
            await _context.SaveChangesAsync(token);
            return account;
        }
        public async Task<ICollection<Account>> GetAllAsync(CancellationToken token = default)
            => await _context.Accounts.ToListAsync(token);
        public async Task<Account?> GetByNameAsync(string name, CancellationToken token = default)
            => await _context.Accounts.Include(c => c.Contacts)
                        .SingleOrDefaultAsync(n => n.Name.ToLower() == name.ToLower(), token);

    }
}
