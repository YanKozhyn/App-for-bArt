using AutoMapper;
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

        public async Task<Account> CreateAsync(AccountDto accountDto)
        {
            Account account = _mapper.Map<Account>(accountDto);
            await _context.Accounts.AddAsync(account);
                        
            if (account.Contacts.Any())
            {
                foreach (var contact in account.Contacts)
                {
                    await _context.Contacts.AddAsync(contact);
                }
            }
            await _context.SaveChangesAsync();

            return account;
        }
    }
}
