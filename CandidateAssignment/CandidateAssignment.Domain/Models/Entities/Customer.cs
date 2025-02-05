﻿using System.ComponentModel.DataAnnotations;

namespace CandidateAssignment.Domain.Models.Entities
{
    public class Customer : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Address? Address { get; set; }

        [Required, MaxLength(13)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Website { get; set; }

        public virtual ICollection<Contact> Contacts { get; private set; } = new List<Contact>();

        public Customer(string name, Address address, string phoneNumber, string website)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Website = website;
        }

        public Customer()
        {

        }
    }
}
