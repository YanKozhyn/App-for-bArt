using AutoMapper;
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

        public async Task<Contact> CreateAsync(ContactDto contactDto, CancellationToken token = default)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            await _context.Contacts.AddAsync(contact, token);
            await _context.SaveChangesAsync(token);
            return contact;
        }
    }
}
