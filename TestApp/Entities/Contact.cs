using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class Contact : BaseEntity
    {

        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [Required] public string Email { get; set; } = string.Empty;
        public Guid AccountId { get; set; }
        public Account Account { get; set; } = null!;

    }
}
