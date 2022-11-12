using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IContactService
    {
        Task<Contact> CreateAsync(ContactDto contactDto, CancellationToken token = default);
    }
}
