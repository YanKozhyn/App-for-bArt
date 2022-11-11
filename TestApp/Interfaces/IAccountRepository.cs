using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateAsync(Account account, CancellationToken token = default);

    }
}
