using AutoMapper;
using TestApp.DTOs;
using TestApp.Entities;
using TestApp.Interfaces;

namespace TestApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Contact> CreateAsync(ContactDto contactDto, CancellationToken token = default)
        {
            Contact contact = _mapper.Map<Contact>(contactDto);
            await _unitOfWork.Contacts.CreateAsync(contact, token);
            await _unitOfWork.SaveAsync(token);
            return contact;
        }
    }
}
