namespace TestApp.DTOs
{
    public class IncidentDto
    {
        public string Description { get; set; }
        public ICollection<AccountDto> Accounts { get; set; } 
    }
}
