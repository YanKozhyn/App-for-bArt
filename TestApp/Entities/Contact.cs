using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class Contact : BaseEntity
    {

        [Required] public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
        [Required] public string? Email { get; set; }
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }

    }
}
