using AutoMapper;
using TestApp.DTOs;
using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Account> CreateAsync(AccountDto accountDto, CancellationToken token = default)
        {
            Account account = _mapper.Map<Account>(accountDto);
            await _unitOfWork.Accounts.CreateAsync(account, token);
            await _unitOfWork.SaveAsync(token);

            return account;
        }
    }
}
