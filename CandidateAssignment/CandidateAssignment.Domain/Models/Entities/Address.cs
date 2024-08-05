using System.ComponentModel.DataAnnotations;

namespace CandidateAssignment.Domain.Models.Entities
{
    public class Address : Entity
    {
        [Required]
        public string FirstLine { get; private set; }

        [Required]
        public string City { get; private set; }

        [Required, MaxLength(10)]
        public string Postcode { get; private set; }

        [Required, MaxLength(100)]
        public string Country { get; private set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

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
