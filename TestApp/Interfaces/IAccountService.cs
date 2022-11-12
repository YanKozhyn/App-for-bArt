using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAsync(AccountDto accountDto, CancellationToken token = default);
    }
}
