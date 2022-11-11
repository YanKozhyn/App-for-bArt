using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IContactRepository
    {
        Task CreateAsync(Contact contact, CancellationToken token = default);
    }
}
