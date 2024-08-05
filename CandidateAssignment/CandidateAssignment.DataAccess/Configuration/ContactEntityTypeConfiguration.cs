using CandidateAssignment.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateAssignment.DataAccess.Configuration
{
    internal class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.EmailAddress).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(13);
        }
    }
}
