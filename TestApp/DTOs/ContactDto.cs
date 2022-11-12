using TestApp.Validation;

namespace TestApp.DTOs
{
    public class ContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [UniqueEmail]
        public string Email { get; set; } 
    }
}
