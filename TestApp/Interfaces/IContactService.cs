using TestApp.DTOs;
using TestApp.Entities;

namespace TestApp.Interfaces
{
    public interface IContactService
    {
        Task<ICollection<Contact>> GetAllAsync(CancellationToken token = default);
        Task<Contact> CreateAsync(CreateContactDto contactDto, CancellationToken token = default);
        Task<UpdateContactDto> UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto, CancellationToken token = default);
        Task<Contact> GetContactByIdAsync(Guid id, CancellationToken token = default);

    }
}
