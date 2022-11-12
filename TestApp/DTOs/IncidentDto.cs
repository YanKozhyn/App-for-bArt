namespace TestApp.DTOs
{
    public class IncidentDto
    {
        public string Description { get; set; } = string.Empty;
        public ICollection<AccountDto> Accounts { get; set; } = null!;
    }
}
