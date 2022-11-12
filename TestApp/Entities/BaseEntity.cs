using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class BaseEntity
    {
        [Key] public Guid Id { get; set; }
    }
}
