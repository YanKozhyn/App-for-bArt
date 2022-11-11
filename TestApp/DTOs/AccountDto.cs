namespace TestApp.DTOs
{
    public class AccountDto
    {
        public string Name { get; set; }
        public ICollection<ContactDto> Contacts { get; set; }
    }
}
