﻿using System.ComponentModel.DataAnnotations;

namespace CandidateAssignment.Domain.Models.Entities
{
    public class Address : Entity
    {
        [Required]
        public string FirstLine { get; set; }

        [Required]
        public string City { get; set; }

        [Required, MaxLength(10)]
        public string Postcode { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }

        public int CustomerId { get; private set; }
        public Customer? Customer { get; private set; } = null!;

        public Address(string firstLine, string city, string postcode, string country)
        {
            FirstLine = firstLine;
            City = city;
            Postcode = postcode;
            Country = country;
        }

        public Address()
        {
        }
    }
}
