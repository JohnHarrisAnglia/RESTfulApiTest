using System.ComponentModel.DataAnnotations;

namespace CandidateAssignment.Domain.Models.Entities
{
    public class Contact : Entity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public Contact(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public Contact()
        {

        }
    }
}
