using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class Contact : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid? AccountId { get; set; }
        public Account? Account { get; set; }

    }
}
