using System.ComponentModel.DataAnnotations;

namespace CandidateAssignment.Domain.Models.Entities
{
    public class Contact : Entity
    {
        [Required]
        public string FirstName { get; private set; }

        [Required]
        public string LastName { get; private set; }

        [Required, MaxLength(50)]
        public string EmailAddress { get; private set; }

        public string PhoneNumber { get; private set; }

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
