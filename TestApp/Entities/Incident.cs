using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Entities
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
