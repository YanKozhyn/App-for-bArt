using TestApp.Validation;
namespace TestApp.DTOs
{
    public class AccountDto
    {
        [UniqueName]
        public string Name { get; set; }
        public ICollection<ContactDto> Contacts { get; set; }
    }
}
