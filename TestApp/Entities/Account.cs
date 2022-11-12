using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class Account : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string IncidentId { get; set; } = string.Empty;
        public Incident Incident { get; set; } = null!;
        public ICollection<Contact> Contacts { get; set; } = null!;
    }
}
