using CandidateAssignment.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateAssignment.DataAccess.Configuration
{
    internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Website).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(13).IsRequired();
        }
    }
}
