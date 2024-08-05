using CandidateAssignment.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateAssignment.DataAccess.Configuration
{
    internal class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.FirstLine).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.Postcode).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Country).HasMaxLength(100).IsRequired();
        }
    }
}
