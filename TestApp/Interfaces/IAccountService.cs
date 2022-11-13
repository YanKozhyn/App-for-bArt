using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IAccountService
    {
        Task<ICollection<Account>> GetAllAsync(CancellationToken token = default);
        Task<Account> CreateAsync(CreateAccountDto accountDto, CancellationToken token = default);
        Task<Account?> GetByNameAsync(string name, CancellationToken token = default);


    }
}
