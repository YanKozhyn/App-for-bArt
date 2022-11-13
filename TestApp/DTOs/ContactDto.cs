using TestApp.Validation;

namespace TestApp.DTOs
{
    public class ContactDto : BaseEntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [UniqueEmail]
        public string Email { get; set; } 
    }

    public class CreateContactDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [UniqueEmail]
        public string Email { get; set; }
    }

    public class UpdateContactDto 
    {
        public Guid AccountId { get; set; }
    }
}
