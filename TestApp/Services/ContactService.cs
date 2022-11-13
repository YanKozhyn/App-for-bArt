using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.DTOs;
using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ContactService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Contact> CreateAsync(CreateContactDto contactDto, CancellationToken token = default)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            await _context.Contacts.AddAsync(contact, token);
            await _context.SaveChangesAsync(token);
            return contact;
        }

        public async Task<ICollection<Contact>> GetAllAsync(CancellationToken token = default)
            => await _context.Contacts.ToListAsync(token);

        public async Task<Contact> GetContactByIdAsync(Guid id, CancellationToken token = default)
            => await _context.Contacts.SingleOrDefaultAsync(i => i.Id == id, token);

        public async Task<UpdateContactDto> UpdateAccountIdAsync(Guid id, UpdateContactDto contactDto, CancellationToken token = default)
        {
            Contact contact = await GetContactByIdAsync(id, token);
            if (contact is not null)
            {
                    contact.AccountId = contactDto.AccountId;

                    await Task.FromResult(_context.Contacts.Update(contact));
                    await _context.SaveChangesAsync(token);               
            }
            return contactDto;
        }
    }
}
