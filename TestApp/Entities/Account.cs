﻿using System.ComponentModel.DataAnnotations;

namespace TestApp.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string? IncidentId { get; set; }
        public Incident? Incident { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
