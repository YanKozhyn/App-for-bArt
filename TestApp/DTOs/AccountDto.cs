using TestApp.Entities;
using TestApp.Validation;
namespace TestApp.DTOs
{

    public class AccountDto : BaseEntityDto
    {
        [UniqueName]
        public string Name { get; set; }
        public string? IncidentId { get; set; }
        public ICollection<ContactDto> Contacts { get; set; }
    }


    public class CreateAccountDto
    {
        [UniqueName]
        public string Name { get; set; }
        public ICollection<ContactDto> Contacts { get; set; }
    }
}
